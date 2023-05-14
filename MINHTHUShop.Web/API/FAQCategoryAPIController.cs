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
    [RoutePrefix("api/FAQCategory")]
    public class FAQCategoryAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_FAQCategoryService _faqCategoryService;

        public FAQCategoryAPIController(ITb_ErrorService errorService, ITb_FAQCategoryService faqCategoryService)
            : base(errorService)
        {
            this._faqCategoryService = faqCategoryService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _faqCategoryService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_FAQCategory>, IEnumerable<FAQCategoryVM>>(model);
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
                var model = _faqCategoryService.GetById(id);
                var responseData = Mapper.Map<Tb_FAQCategory, FAQCategoryVM>(model);
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
                var model = _faqCategoryService.GetAll(keyword);

                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_FAQCategory>, IEnumerable<FAQCategoryVM>>(query);

                var pagination = new Pagination<FAQCategoryVM>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, FAQCategoryVM faqCategoryVM)
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
                    var newFAQCategory = new Tb_FAQCategory();
                    //update
                    newFAQCategory.UpdateFAQCategory(faqCategoryVM);
                    _faqCategoryService.Create(newFAQCategory);
                    _faqCategoryService.SaveChanges();

                    var responseData = Mapper.Map<Tb_FAQCategory, FAQCategoryVM>(newFAQCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, FAQCategoryVM faqCategoryVM)
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
                    var dbFAQCategory = _faqCategoryService.GetById(faqCategoryVM.FAQCateID);
                    dbFAQCategory.UpdateFAQCategory(faqCategoryVM);

                    _faqCategoryService.Update(dbFAQCategory);
                    _faqCategoryService.SaveChanges();

                    var responseData = Mapper.Map<Tb_FAQCategory, FAQCategoryVM>(dbFAQCategory);
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
                    var oldFAQCategory = _faqCategoryService.Delete(id);
                    _faqCategoryService.SaveChanges();

                    var responseData = Mapper.Map<Tb_FAQCategory, FAQCategoryVM>(oldFAQCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedFAQCategory)
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
                    var listFAQCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedFAQCategory);
                    foreach (var item in listFAQCategory)
                    {
                        _faqCategoryService.Delete(item);
                    }
                    _faqCategoryService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listFAQCategory.Count);
                }
                return response;
            });
        }
    }
}