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
    [RoutePrefix("api/Banner")]
    [Authorize]
    public class BannerAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_BannerService _bannerService;

        public BannerAPIController(ITb_ErrorService errorService, ITb_BannerService bannerService)
            : base(errorService)
        {
            this._bannerService = bannerService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _bannerService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_Banner>, IEnumerable<BannerVM>>(model);
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
                var model = _bannerService.GetById(id);
                var responseData = Mapper.Map<Tb_Banner, BannerVM>(model);
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
                var model = _bannerService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_Banner>, IEnumerable<BannerVM>>(query.AsEnumerable());

                var paginationSet = new Pagination<BannerVM>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, BannerVM bannerVM)
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
                    var newBanner = new Tb_Banner();
                    newBanner.UpdateBanner(bannerVM);
                    newBanner.CreateDate = DateTime.Now;
                    _bannerService.Create(newBanner);
                    _bannerService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Banner, BannerVM>(newBanner);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, BannerVM bannerVM)
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
                    var dbBanner = _bannerService.GetById(bannerVM.BannerID);
                    dbBanner.UpdateBanner(bannerVM);
                    _bannerService.Update(dbBanner);
                    _bannerService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Banner, BannerVM>(dbBanner);
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
                    var oldBanner = _bannerService.Delete(id);
                    _bannerService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Banner, BannerVM>(oldBanner);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedBanner)
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
                    var listBanner = new JavaScriptSerializer().Deserialize<List<int>>(checkedBanner);
                    foreach (var item in listBanner)
                    {
                        _bannerService.Delete(item);
                    }

                    _bannerService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, listBanner.Count);
                }
                return response;
            });
        }
    }
}