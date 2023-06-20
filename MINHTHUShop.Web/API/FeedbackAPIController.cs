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
    [RoutePrefix("api/Feedback")]
    [Authorize]
    public class FeedbackAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_FeedbackService _feedbackService;

        public FeedbackAPIController(ITb_ErrorService errorService, ITb_FeedbackService feedbackService)
            : base(errorService)
        {
            this._feedbackService = feedbackService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _feedbackService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_Feedback>, IEnumerable<FeedbackVM>>(model);
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
                var model = _feedbackService.GetById(id);
                var responseData = Mapper.Map<Tb_Feedback, FeedbackVM>(model);
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
                var model = _feedbackService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_Feedback>, IEnumerable<FeedbackVM>>(query.AsEnumerable());

                var paginationSet = new Pagination<FeedbackVM>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, FeedbackVM feedbackVM)
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
                    var newFeedback = new Tb_Feedback();
                    newFeedback.UpdateFeedback(feedbackVM);
                    newFeedback.CreateDate = DateTime.Now;

                    _feedbackService.Create(newFeedback);
                    _feedbackService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Feedback, FeedbackVM>(newFeedback);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, FeedbackVM feedbackVM)
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
                    var dbFeedback = _feedbackService.GetById(feedbackVM.FeedbackID);
                    dbFeedback.UpdateFeedback(feedbackVM);

                    _feedbackService.Update(dbFeedback);
                    _feedbackService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Feedback, FeedbackVM>(dbFeedback);
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
                    var oldFeedback = _feedbackService.Delete(id);
                    _feedbackService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Feedback, FeedbackVM>(oldFeedback);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedFeedback)
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
                    var listFeedback = new JavaScriptSerializer().Deserialize<List<int>>(checkedFeedback);
                    foreach (var item in listFeedback)
                    {
                        _feedbackService.Delete(item);
                    }

                    _feedbackService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, listFeedback.Count);
                }
                return response;
            });
        }
    }
}