using AutoMapper;
using MINHTHUShop.Common;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.App_Start;
using MINHTHUShop.Web.Infrastructure.Core;
using MINHTHUShop.Web.Infrastructure.Extensions;
using MINHTHUShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MINHTHUShop.Web.API
{
    [RoutePrefix("api/Group")]
    [Authorize]
    public class GroupAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_GroupService _groupService;
        private ITb_RoleService _roleService;
        private ApplicationUserManager _userManager;

        public GroupAPIController(ITb_ErrorService errorService, ITb_GroupService groupService, ITb_RoleService roleService, ApplicationUserManager userManager) : base(errorService)
        {
            this._groupService = groupService; 
            _roleService = roleService;
            _userManager = userManager;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        [Authorize(Roles = "ViewGroup")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _groupService.GetAll().OrderBy(x => x.Name);
                IEnumerable<GroupVM> modelVM = Mapper.Map<IEnumerable<Tb_Group>, IEnumerable<GroupVM>>(model);
                response = request.CreateResponse(HttpStatusCode.OK, modelVM);

                return response;
            });
        }

        [Route("GetById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            if (id == 0)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không tồn tại.");
            }
            Tb_Group group = _groupService.GetById(id);
            var groupVM = Mapper.Map<Tb_Group, GroupVM>(group);
            if (group == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không tìm thấy nhóm người dùng.");
            }
            var listRole = _roleService.GetListRoleByGroupID(groupVM.GroupID);
            groupVM.RoleVMs = Mapper.Map<IEnumerable<Tb_Role>, IEnumerable<RoleVM>>(listRole);
            return request.CreateResponse(HttpStatusCode.OK, groupVM);
        }

        [Route("GetAllByPage")]
        [HttpGet]
        [Authorize(Roles = "ViewGroup")]
        public HttpResponseMessage GetAllByPage(HttpRequestMessage request, int page, int pageSize = 20, string keyword = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                var model = _groupService.GetAll(page, pageSize, out totalRow, keyword);
                totalRow = model.Count();
                var query = model.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);

                IEnumerable<GroupVM> modelVM = Mapper.Map<IEnumerable<Tb_Group>, IEnumerable<GroupVM>>(query);

                Pagination<GroupVM> pagination = new Pagination<GroupVM>()
                {
                    Item = modelVM,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagination);

                return response;
            });
        }

        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, GroupVM groupVM)
        {
            return CreateHttpResponse(request, () =>
            {
                //kiểm tra có lỗi
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newGroup = new Tb_Group();
                    newGroup.Name = groupVM.Name;
                    try
                    {
                        var group = _groupService.Create(newGroup);
                        _groupService.SaveChanges();

                        //save group
                        var listRoleGroup = new List<Tb_RoleGroup>();
                        foreach (var role in groupVM.RoleVMs)
                        {
                            listRoleGroup.Add(new Tb_RoleGroup()
                            {
                                GroupID = group.GroupID,
                                RoleID = role.Id
                            });
                        }
                        _roleService.AddRolesToGroup(listRoleGroup, group.GroupID);
                        _roleService.SaveChanges();

                        return request.CreateResponse(HttpStatusCode.OK, groupVM);
                    }
                    catch (NameDuplicatedException dex)
                    {
                        return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                    }
                }
            });
        }

        [Route("Update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request, GroupVM groupVM)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var group = _groupService.GetById(groupVM.GroupID);
                try
                {
                    group.UpdateGroup(groupVM);
                    _groupService.Update(group);
                    //_groupService.Save();

                    //save group
                    var listRoleGroup = new List<Tb_RoleGroup>();
                    foreach (var role in groupVM.RoleVMs)
                    {
                        listRoleGroup.Add(new Tb_RoleGroup()
                        {
                            GroupID = group.GroupID,
                            RoleID = role.Id
                        });
                    }
                    _roleService.AddRolesToGroup(listRoleGroup, group.GroupID);
                    _roleService.SaveChanges();

                    //add role to user
                    var listRole = _roleService.GetListRoleByGroupID(group.GroupID);
                    var listUserInGroup = _groupService.GetListUserByGroupID(group.GroupID);
                    foreach (var user in listUserInGroup)
                    {
                        var listRoleName = listRole.Select(x => x.Name).ToArray();
                        foreach (var roleName in listRoleName)
                        {
                            await _userManager.RemoveFromRoleAsync(user.Id, roleName);
                            await _userManager.AddToRoleAsync(user.Id, roleName);
                        }
                    }
                    return request.CreateResponse(HttpStatusCode.OK, groupVM);
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            var appGroup = _groupService.Delete(id);
            _groupService.SaveChanges();
            return request.CreateResponse(HttpStatusCode.OK, appGroup);
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedGroup)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listGroup = new JavaScriptSerializer().Deserialize<List<int>>(checkedGroup);
                    foreach (var item in listGroup)
                    {
                        _groupService.Delete(item);
                    }
                    _groupService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listGroup.Count);
                }
                return response;
            });
        }
    }
}