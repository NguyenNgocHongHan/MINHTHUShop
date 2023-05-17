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
    [RoutePrefix("api/NewsCategory")]
    [Authorize]
    public class NewsCategoryAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_NewsCategoryService _newsCategoryService;

        public NewsCategoryAPIController(ITb_ErrorService errorService, ITb_NewsCategoryService newsCategoryService)
            : base(errorService)
        {
            this._newsCategoryService = newsCategoryService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _newsCategoryService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_NewsCategory>, IEnumerable<NewsCategoryVM>>(model);
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
                var model = _newsCategoryService.GetById(id);
                var responseData = Mapper.Map<Tb_NewsCategory, NewsCategoryVM>(model);
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
                var model = _newsCategoryService.GetAll(keyword);

                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_NewsCategory>, IEnumerable<NewsCategoryVM>>(query);

                var pagination = new Pagination<NewsCategoryVM>()
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
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, NewsCategoryVM newsCategoryVM)
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
                    var newNewsCategory = new Tb_NewsCategory();
                    //update
                    newNewsCategory.UpdateNewsCategory(newsCategoryVM);
                    _newsCategoryService.Create(newNewsCategory);
                    _newsCategoryService.SaveChanges();

                    var responseData = Mapper.Map<Tb_NewsCategory, NewsCategoryVM>(newNewsCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, NewsCategoryVM newsCategoryVM)
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
                    var dbNewsCategory = _newsCategoryService.GetById(newsCategoryVM.NewsCateID);
                    dbNewsCategory.UpdateNewsCategory(newsCategoryVM);

                    _newsCategoryService.Update(dbNewsCategory);
                    _newsCategoryService.SaveChanges();

                    var responseData = Mapper.Map<Tb_NewsCategory, NewsCategoryVM>(dbNewsCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Delete")]
        [HttpDelete]
        [AllowAnonymous]
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
                    var oldNewsCategory = _newsCategoryService.Delete(id);
                    _newsCategoryService.SaveChanges();

                    var responseData = Mapper.Map<Tb_NewsCategory, NewsCategoryVM>(oldNewsCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedNewsCategory)
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
                    var listNewsCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedNewsCategory);
                    foreach (var item in listNewsCategory)
                    {
                        _newsCategoryService.Delete(item);
                    }
                    _newsCategoryService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listNewsCategory.Count);
                }
                return response;
            });
        }
    }
}