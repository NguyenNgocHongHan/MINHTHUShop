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
    [RoutePrefix("api/About")]
    [Authorize]
    public class AboutAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_AboutService _aboutService;

        public AboutAPIController(ITb_ErrorService errorService, ITb_AboutService aboutService)
            : base(errorService)
        {
            this._aboutService = aboutService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _aboutService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_About>, IEnumerable<AboutVM>>(model);
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
                var model = _aboutService.GetById(id);
                var responseData = Mapper.Map<Tb_About, AboutVM>(model);
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
                var model = _aboutService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_About>, IEnumerable<AboutVM>>(query.AsEnumerable());

                var paginationSet = new Pagination<AboutVM>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, AboutVM aboutVM)
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
                    var newAbout = new Tb_About();
                    newAbout.UpdateAbout(aboutVM);
                    newAbout.CreateDate = DateTime.Now;
                    _aboutService.Create(newAbout);
                    _aboutService.SaveChanges();

                    var responseData = Mapper.Map<Tb_About, AboutVM>(newAbout);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, AboutVM aboutVM)
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
                    var dbAbout = _aboutService.GetById(aboutVM.AboutID);
                    dbAbout.UpdateAbout(aboutVM);
                    _aboutService.Update(dbAbout);
                    _aboutService.SaveChanges();

                    var responseData = Mapper.Map<Tb_About, AboutVM>(dbAbout);
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
                    var oldAbout = _aboutService.Delete(id);
                    _aboutService.SaveChanges();

                    var responseData = Mapper.Map<Tb_About, AboutVM>(oldAbout);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedAbout)
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
                    var listAbout = new JavaScriptSerializer().Deserialize<List<int>>(checkedAbout);
                    foreach (var item in listAbout)
                    {
                        _aboutService.Delete(item);
                    }

                    _aboutService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, listAbout.Count);
                }
                return response;
            });
        }
    }
}