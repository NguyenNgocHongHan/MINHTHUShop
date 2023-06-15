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

namespace MINHTHUShop.Web.API
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class ApplicationUserController : APIControllerBase
    {
        private ApplicationUserManager _userManager;
        private ITb_GroupService _groupService;
        private ITb_RoleService _roleService;

        public ApplicationUserController(ITb_GroupService groupService, ITb_RoleService roleService, ApplicationUserManager userManager, ITb_ErrorService errorService) : base(errorService)
        {
            _roleService = roleService;
            _groupService = groupService;
            _userManager = userManager;
        }

        [Route("GetAllByPage")]
        [Authorize(Roles = "ViewUser")]
        [HttpGet]
        public HttpResponseMessage GetAllByPage(HttpRequestMessage request, int page, int pageSize = 20, string keyword = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                var model = _userManager.Users;
                IEnumerable<UserVM> modelVM = Mapper.Map<IEnumerable<Tb_User>, IEnumerable<UserVM>>(model);

                Pagination<UserVM> pagination = new Pagination<UserVM>()
                {
                    Page = page,
                    TotalCount = totalRow,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    Item = modelVM
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagination);

                return response;
            });
        }

        [Route("GetById/{id}")]
        [HttpGet]
        [Authorize(Roles = "ViewUser")]
        public HttpResponseMessage GetById(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không tồn tại.");
            }

            var user = _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không tìm thấy người dùng.");
            }
            else
            {
                var userVM = Mapper.Map<Tb_User, UserVM>(user.Result);
                var listGroup = _groupService.GetListGroupByUserID(userVM.Id);
                userVM.GroupVMs = Mapper.Map<IEnumerable<Tb_Group>, IEnumerable<GroupVM>>(listGroup);
                return request.CreateResponse(HttpStatusCode.OK, userVM);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<HttpResponseMessage> Create(HttpRequestMessage request, UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var newUser = new Tb_User();
                newUser.UpdateUser(userVM);
                try
                {
                    newUser.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(newUser, userVM.Password);
                    if (result.Succeeded)
                    {
                        var listUserGroup = new List<Tb_UserGroup>();
                        foreach (var group in userVM.GroupVMs)
                        {
                            listUserGroup.Add(new Tb_UserGroup()
                            {
                                GroupID = group.GroupID,
                                UserID = newUser.Id
                            });
                            //add role to user
                            var listRole = _roleService.GetListRoleByGroupID(group.GroupID);
                            foreach (var role in listRole)
                            {
                                await _userManager.RemoveFromRoleAsync(newUser.Id, role.Name);
                                await _userManager.AddToRoleAsync(newUser.Id, role.Name);
                            }
                        }
                        _groupService.AddUserToGroups(listUserGroup, newUser.Id);
                        _groupService.SaveChanges();


                        return request.CreateResponse(HttpStatusCode.OK, userVM);

                    }
                    else
                        return request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(",", result.Errors));
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
                catch (Exception ex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request, UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userVM.Id);
                try
                {
                    user.UpdateUser(userVM);
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var listUserGroup = new List<Tb_UserGroup>();
                        foreach (var group in userVM.GroupVMs)
                        {
                            listUserGroup.Add(new Tb_UserGroup()
                            {
                                GroupID = group.GroupID,
                                UserID = userVM.Id
                            });
                            //add role to user
                            var listRole = _roleService.GetListRoleByGroupID(group.GroupID);
                            foreach (var role in listRole)
                            {
                                await _userManager.RemoveFromRoleAsync(user.Id, role.Name);
                                await _userManager.AddToRoleAsync(user.Id, role.Name);
                            }
                        }
                        _groupService.AddUserToGroups(listUserGroup, userVM.Id);
                        _groupService.SaveChanges();
                        return request.CreateResponse(HttpStatusCode.OK, userVM);

                    }
                    else
                        return request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(",", result.Errors));
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return request.CreateResponse(HttpStatusCode.OK, id);
            else
                return request.CreateErrorResponse(HttpStatusCode.OK, string.Join(",", result.Errors));
        }

    }
}