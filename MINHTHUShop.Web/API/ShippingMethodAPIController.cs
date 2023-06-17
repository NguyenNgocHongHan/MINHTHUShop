using AutoMapper;
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
    [RoutePrefix("api/ShippingMethod")]
    [Authorize]
    public class ShippingMethodAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_ShippingMethodService _shippingMethodService;

        public ShippingMethodAPIController(ITb_ErrorService errorService, ITb_ShippingMethodService shippingMethodService)
            : base(errorService)
        {
            this._shippingMethodService = shippingMethodService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _shippingMethodService.GetAll().OrderBy(x => x.Name);
                var responseData = Mapper.Map<IEnumerable<Tb_ShippingMethod>, IEnumerable<ShippingMethodVM>>(model);
                //nếu không dùng View Model thì mình có thể dùng câu lệnh bên dưới, nhưng có nhiều dữ liệu không cần thiết cũng được lấy ra theo
                //vì vậy sử dụng View Model để lấy ra những trường cần thiết
                //var response = request.CreateResponse(HttpStatusCode.OK, model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("GetById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _shippingMethodService.GetById(id);
                var responseData = Mapper.Map<Tb_ShippingMethod, ShippingMethodVM>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("GetAllByPage")]
        [HttpGet]
        public HttpResponseMessage GetAllByPage(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _shippingMethodService.GetAll(keyword);

                totalRow = model.Count();

                var query = model.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_ShippingMethod>, IEnumerable<ShippingMethodVM>>(query);

                var pagination = new Pagination<ShippingMethodVM>()
                {
                    Item = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, pagination);

                return response;
            });
        }

        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ShippingMethodVM shippingMethodVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                //kiểm tra có lỗi
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newShippingMethod = new Tb_ShippingMethod();
                    //update
                    newShippingMethod.UpdateShippingMethod(shippingMethodVM);
                    _shippingMethodService.Create(newShippingMethod);
                    _shippingMethodService.SaveChanges();

                    var responseData = Mapper.Map<Tb_ShippingMethod, ShippingMethodVM>(newShippingMethod);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ShippingMethodVM shippingMethodVM)
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
                    var dbShippingMethod = _shippingMethodService.GetById(shippingMethodVM.ShippingMethodID);
                    dbShippingMethod.UpdateShippingMethod(shippingMethodVM);

                    _shippingMethodService.Update(dbShippingMethod);
                    _shippingMethodService.SaveChanges();

                    var responseData = Mapper.Map<Tb_ShippingMethod, ShippingMethodVM>(dbShippingMethod);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    var oldShippingMethod = _shippingMethodService.Delete(id);
                    _shippingMethodService.SaveChanges();

                    var responseData = Mapper.Map<Tb_ShippingMethod, ShippingMethodVM>(oldShippingMethod);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedShippingMethod)
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
                    var listShippingMethod = new JavaScriptSerializer().Deserialize<List<int>>(checkedShippingMethod);
                    foreach (var item in listShippingMethod)
                    {
                        _shippingMethodService.Delete(item);
                    }
                    _shippingMethodService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listShippingMethod.Count);
                }
                return response;
            });
        }
    }
}