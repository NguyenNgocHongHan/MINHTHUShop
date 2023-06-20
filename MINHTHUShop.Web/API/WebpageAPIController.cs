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
    [RoutePrefix("api/Webpage")]
    [Authorize]
    public class WebpageAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_WebpageService _webpageService;

        public WebpageAPIController(ITb_ErrorService errorService, ITb_WebpageService webpageService)
            : base(errorService)
        {
            this._webpageService = webpageService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _webpageService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_Webpage>, IEnumerable<WebpageVM>>(model);
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
                var model = _webpageService.GetById(id);
                var responseData = Mapper.Map<Tb_Webpage, WebpageVM>(model);
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
                var model = _webpageService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_Webpage>, IEnumerable<WebpageVM>>(query.AsEnumerable());

                var paginationSet = new Pagination<WebpageVM>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, WebpageVM webpageVM)
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
                    var newWebpage = new Tb_Webpage();
                    newWebpage.UpdateWebpage(webpageVM);
                    newWebpage.CreateDate = DateTime.Now;
                    _webpageService.Create(newWebpage);
                    _webpageService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Webpage, WebpageVM>(newWebpage);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, WebpageVM webpageVM)
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
                    var dbWebpage = _webpageService.GetById(webpageVM.PageID);
                    dbWebpage.UpdateWebpage(webpageVM);
                    _webpageService.Update(dbWebpage);
                    _webpageService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Webpage, WebpageVM>(dbWebpage);
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
                    var oldWebpage = _webpageService.Delete(id);
                    _webpageService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Webpage, WebpageVM>(oldWebpage);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedWebpage)
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
                    var listWebpage = new JavaScriptSerializer().Deserialize<List<int>>(checkedWebpage);
                    foreach (var item in listWebpage)
                    {
                        _webpageService.Delete(item);
                    }

                    _webpageService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, listWebpage.Count);
                }
                return response;
            });
        }
    }
}