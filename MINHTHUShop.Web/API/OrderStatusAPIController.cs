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
    [RoutePrefix("api/OrderStatus")]
    [Authorize]
    public class OrderStatusAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_OrderStatusService _orderStatusService;

        public OrderStatusAPIController(ITb_ErrorService errorService, ITb_OrderStatusService orderStatusService)
            : base(errorService)
        {
            this._orderStatusService = orderStatusService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _orderStatusService.GetAll().OrderBy(x => x.Name);
                var responseData = Mapper.Map<IEnumerable<Tb_OrderStatus>, IEnumerable<OrderStatusVM>>(model);
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
                var model = _orderStatusService.GetById(id);
                var responseData = Mapper.Map<Tb_OrderStatus, OrderStatusVM>(model);
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
                var model = _orderStatusService.GetAll(keyword);

                totalRow = model.Count();

                var query = model.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_OrderStatus>, IEnumerable<OrderStatusVM>>(query);

                var pagination = new Pagination<OrderStatusVM>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, OrderStatusVM orderStatusVM)
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
                    var newOrderStatus = new Tb_OrderStatus();
                    //update
                    newOrderStatus.UpdateOrderStatus(orderStatusVM);
                    _orderStatusService.Create(newOrderStatus);
                    _orderStatusService.SaveChanges();

                    var responseData = Mapper.Map<Tb_OrderStatus, OrderStatusVM>(newOrderStatus);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, OrderStatusVM orderStatusVM)
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
                    var dbOrderStatus = _orderStatusService.GetById(orderStatusVM.OrderStatusID);
                    dbOrderStatus.UpdateOrderStatus(orderStatusVM);

                    _orderStatusService.Update(dbOrderStatus);
                    _orderStatusService.SaveChanges();

                    var responseData = Mapper.Map<Tb_OrderStatus, OrderStatusVM>(dbOrderStatus);
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
                    var oldOrderStatus = _orderStatusService.Delete(id);
                    _orderStatusService.SaveChanges();

                    var responseData = Mapper.Map<Tb_OrderStatus, OrderStatusVM>(oldOrderStatus);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedOrderStatus)
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
                    var listOrderStatus = new JavaScriptSerializer().Deserialize<List<int>>(checkedOrderStatus);
                    foreach (var item in listOrderStatus)
                    {
                        _orderStatusService.Delete(item);
                    }
                    _orderStatusService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listOrderStatus.Count);
                }
                return response;
            });
        }
    }
}