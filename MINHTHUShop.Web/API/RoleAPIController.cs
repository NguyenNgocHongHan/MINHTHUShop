using AutoMapper;
using MINHTHUShop.Common;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Infrastructure.Core;
using MINHTHUShop.Web.Infrastructure.Extensions;
using MINHTHUShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MINHTHUShop.Web.API
{
    [RoutePrefix("api/Role")]
    [Authorize]
    public class ApplicationRoleController : APIControllerBase
    {
        private ITb_RoleService _roleService;

        public ApplicationRoleController(ITb_ErrorService errorService, ITb_RoleService roleService) : base(errorService)
        {
            _roleService = roleService;
        }

        [Route("GetAllByPage")]
        [HttpGet]
        [Authorize(Roles = "ViewRole")]
        public HttpResponseMessage GetAllByPage(HttpRequestMessage request, int page, int pageSize = 20, string keyword = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                var model = _roleService.GetAll(page, pageSize, out totalRow, keyword);
                IEnumerable<RoleVM> modelVM = Mapper.Map<IEnumerable<Tb_Role>, IEnumerable<RoleVM>>(model);

                Pagination<RoleVM> pagination = new Pagination<RoleVM>()
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

        [Route("GetAll")]
        [HttpGet]
        [Authorize(Roles = "ViewRole")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _roleService.GetAll().OrderBy(x => x.Name);
                IEnumerable<RoleVM> modelVM = Mapper.Map<IEnumerable<Tb_Role>, IEnumerable<RoleVM>>(model);

                response = request.CreateResponse(HttpStatusCode.OK, modelVM);

                return response;
            });
        }

        [Route("GetById/{id}")]
        [HttpGet]
        [Authorize(Roles = "ViewRole")]
        public HttpResponseMessage GetById(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không tồn tại.");
            }
            Tb_Role role = _roleService.GetById(id);
            if (role == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không tìm thấy quyền.");
            }
            return request.CreateResponse(HttpStatusCode.OK, role);
        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(HttpRequestMessage request, RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                var newRole = new Tb_Role();
                newRole.UpdateRole(roleVM);
                try
                {
                    _roleService.Create(newRole);
                    _roleService.SaveChanges();
                    return request.CreateResponse(HttpStatusCode.OK, roleVM);
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

        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(HttpRequestMessage request, RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                var role = _roleService.GetById(roleVM.Id);
                try
                {
                    role.UpdateRole(roleVM, "update");
                    _roleService.Update(role);
                    _roleService.SaveChanges();
                    return request.CreateResponse(HttpStatusCode.OK, role);
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
        public HttpResponseMessage Delete(HttpRequestMessage request, string id)
        {
            _roleService.Delete(id);
            _roleService.SaveChanges();
            return request.CreateResponse(HttpStatusCode.OK, id);
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedRole)
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
                    var listRole = new JavaScriptSerializer().Deserialize<List<string>>(checkedRole);
                    foreach (var item in listRole)
                    {
                        _roleService.Delete(item);
                    }

                    _roleService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listRole.Count);
                }

                return response;
            });
        }
    }
}