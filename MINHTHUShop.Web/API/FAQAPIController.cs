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
    [RoutePrefix("api/FAQ")]
    [Authorize]
    public class FAQAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_FAQService _faqService;

        public FAQAPIController(ITb_ErrorService errorService, ITb_FAQService faqService)
            : base(errorService)
        {
            this._faqService = faqService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _faqService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_FAQ>, IEnumerable<FAQVM>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            };
            return CreateHttpResponse(request, func);
        }

        [Route("GetById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _faqService.GetById(id);
                var responseData = Mapper.Map<Tb_FAQ, FAQVM>(model);
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
                var model = _faqService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderBy(x => x.Question).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_FAQ>, IEnumerable<FAQVM>>(query.AsEnumerable());

                var paginationSet = new Pagination<FAQVM>()
                {
                    Item = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }

        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, FAQVM faqVM)
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
                    var newFAQ = new Tb_FAQ();
                    newFAQ.UpdateFAQ(faqVM);
                    newFAQ.CreateDate = DateTime.Now;

                    _faqService.Create(newFAQ);
                    _faqService.SaveChanges();

                    var responseData = Mapper.Map<Tb_FAQ, FAQVM>(newFAQ);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, FAQVM faqVM)
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
                    var dbFAQ = _faqService.GetById(faqVM.FAQID);
                    dbFAQ.UpdateFAQ(faqVM);

                    _faqService.Update(dbFAQ);
                    _faqService.SaveChanges();

                    var responseData = Mapper.Map<Tb_FAQ, FAQVM>(dbFAQ);
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
                    var oldFAQ = _faqService.Delete(id);
                    _faqService.SaveChanges();

                    var responseData = Mapper.Map<Tb_FAQ, FAQVM>(oldFAQ);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedFAQ)
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
                    var listFAQ = new JavaScriptSerializer().Deserialize<List<int>>(checkedFAQ);
                    foreach (var item in listFAQ)
                    {
                        _faqService.Delete(item);
                    }

                    _faqService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, listFAQ.Count);
                }
                return response;
            });
        }
    }
}