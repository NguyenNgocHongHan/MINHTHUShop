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
    [RoutePrefix("api/PaymentMethod")]
    [Authorize]
    public class PaymentMethodAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_PaymentMethodService _paymentMethodService;

        public PaymentMethodAPIController(ITb_ErrorService errorService, ITb_PaymentMethodService paymentMethodService)
            : base(errorService)
        {
            this._paymentMethodService = paymentMethodService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _paymentMethodService.GetAll().OrderBy(x=>x.Name);
                var responseData = Mapper.Map<IEnumerable<Tb_PaymentMethod>, IEnumerable<PaymentMethodVM>>(model);
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
                var model = _paymentMethodService.GetById(id);
                var responseData = Mapper.Map<Tb_PaymentMethod, PaymentMethodVM>(model);
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
                var model = _paymentMethodService.GetAll(keyword);

                totalRow = model.Count();

                var query = model.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_PaymentMethod>, IEnumerable<PaymentMethodVM>>(query);

                var pagination = new Pagination<PaymentMethodVM>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, PaymentMethodVM paymentMethodVM)
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
                    var newPaymentMethod = new Tb_PaymentMethod();
                    //update
                    newPaymentMethod.UpdatePaymentMethod(paymentMethodVM);
                    _paymentMethodService.Create(newPaymentMethod);
                    _paymentMethodService.SaveChanges();

                    var responseData = Mapper.Map<Tb_PaymentMethod, PaymentMethodVM>(newPaymentMethod);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, PaymentMethodVM paymentMethodVM)
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
                    var dbPaymentMethod = _paymentMethodService.GetById(paymentMethodVM.PaymentMethodID);
                    dbPaymentMethod.UpdatePaymentMethod(paymentMethodVM);

                    _paymentMethodService.Update(dbPaymentMethod);
                    _paymentMethodService.SaveChanges();

                    var responseData = Mapper.Map<Tb_PaymentMethod, PaymentMethodVM>(dbPaymentMethod);
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
                    var oldPaymentMethod = _paymentMethodService.Delete(id);
                    _paymentMethodService.SaveChanges();

                    var responseData = Mapper.Map<Tb_PaymentMethod, PaymentMethodVM>(oldPaymentMethod);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedPaymentMethod)
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
                    var listPaymentMethod = new JavaScriptSerializer().Deserialize<List<int>>(checkedPaymentMethod);
                    foreach (var item in listPaymentMethod)
                    {
                        _paymentMethodService.Delete(item);
                    }
                    _paymentMethodService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listPaymentMethod.Count);
                }
                return response;
            });
        }
    }
}