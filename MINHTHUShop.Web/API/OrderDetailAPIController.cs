using AutoMapper;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Infrastructure.Core;
using MINHTHUShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MINHTHUShop.Web.API
{
    [RoutePrefix("api/OrderDetail")]
    [Authorize]
    public class OrderDetailAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_OrderDetailService _OrderDetailService;

        public OrderDetailAPIController(ITb_ErrorService errorService, ITb_OrderDetailService OrderDetailService)
            : base(errorService)
        {
            this._OrderDetailService = OrderDetailService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _OrderDetailService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_OrderDetail>, IEnumerable<OrderDetailVM>>(model);
                //nếu không dùng View Model thì mình có thể dùng câu lệnh bên dưới, nhưng có nhiều dữ liệu không cần thiết cũng được lấy ra theo
                //vì vậy sử dụng View Model để lấy ra những trường cần thiết
                //var response = request.CreateResponse(HttpStatusCode.OK, model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}