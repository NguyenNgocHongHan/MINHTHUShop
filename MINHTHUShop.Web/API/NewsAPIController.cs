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
    [RoutePrefix("api/News")]
    [Authorize]
    public class NewsAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_NewsService _newsService;

        public NewsAPIController(ITb_ErrorService errorService, ITb_NewsService newsService)
            : base(errorService)
        {
            this._newsService = newsService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _newsService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_News>, IEnumerable<NewsVM>>(model);
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
                var model = _newsService.GetById(id);
                var responseData = Mapper.Map<Tb_News, NewsVM>(model);
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
                var model = _newsService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_News>, IEnumerable<NewsVM>>(query.AsEnumerable());

                var paginationSet = new Pagination<NewsVM>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, NewsVM newsVM)
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
                    var newNews = new Tb_News();
                    newNews.UpdateNews(newsVM);
                    newNews.CreateDate = DateTime.Now;
                    _newsService.Create(newNews);
                    _newsService.SaveChanges();

                    var responseData = Mapper.Map<Tb_News, NewsVM>(newNews);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, NewsVM newsVM)
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
                    var dbNews = _newsService.GetById(newsVM.NewsID);
                    dbNews.UpdateNews(newsVM);
                    _newsService.Update(dbNews);
                    _newsService.SaveChanges();

                    var responseData = Mapper.Map<Tb_News, NewsVM>(dbNews);
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
                    var oldNews = _newsService.Delete(id);
                    _newsService.SaveChanges();

                    var responseData = Mapper.Map<Tb_News, NewsVM>(oldNews);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedNews)
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
                    var listNews = new JavaScriptSerializer().Deserialize<List<int>>(checkedNews);
                    foreach (var item in listNews)
                    {
                        _newsService.Delete(item);
                    }

                    _newsService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, listNews.Count);
                }
                return response;
            });
        }
    }
}