﻿using AutoMapper;
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
    [RoutePrefix("api/ProductCategory")]
    [Authorize]
    public class ProductCategoryAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_ProductCategoryService _productCategoryService;

        public ProductCategoryAPIController(ITb_ErrorService errorService, ITb_ProductCategoryService productCategoryService)
            : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAll().OrderBy(x=>x.Name);
                var responseData = Mapper.Map<IEnumerable<Tb_ProductCategory>, IEnumerable<ProductCategoryVM>>(model);
                //nếu không dùng View Model thì mình có thể dùng câu lệnh bên dưới, nhưng có nhiều dữ liệu không cần thiết cũng được lấy ra theo
                //vì vậy sử dụng View Model để lấy ra những trường cần thiết
                //var response = request.CreateResponse(HttpStatusCode.OK, model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("GetAllChildCate")]
        [HttpGet]
        public HttpResponseMessage GetAllChildCate(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAllChildCate().OrderBy(x => x.Name);
                var responseData = Mapper.Map<IEnumerable<Tb_ProductCategory>, IEnumerable<ProductCategoryVM>>(model);
                //nếu không dùng View Model thì mình có thể dùng câu lệnh bên dưới, nhưng có nhiều dữ liệu không cần thiết cũng được lấy ra theo
                //vì vậy sử dụng View Model để lấy ra những trường cần thiết
                //var response = request.CreateResponse(HttpStatusCode.OK, model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("GetAllParentCate")]
        [HttpGet]
        public HttpResponseMessage GetAllParentCate(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAllParentCate().OrderBy(x => x.Name);
                var responseData = Mapper.Map<IEnumerable<Tb_ProductCategory>, IEnumerable<ProductCategoryVM>>(model);
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
                var model = _productCategoryService.GetById(id);
                var responseData = Mapper.Map<Tb_ProductCategory, ProductCategoryVM>(model);
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
                var model = _productCategoryService.GetAll(keyword);

                totalRow = model.Count();

                var query = model.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_ProductCategory>, IEnumerable<ProductCategoryVM>>(query);

                var pagination = new Pagination<ProductCategoryVM>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryVM productCategoryVM)
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
                    var newProductCategory = new Tb_ProductCategory();
                    //update
                    newProductCategory.UpdateProductCategory(productCategoryVM);
                    _productCategoryService.Create(newProductCategory);
                    _productCategoryService.SaveChanges();

                    var responseData = Mapper.Map<Tb_ProductCategory, ProductCategoryVM>(newProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryVM productCategoryVM)
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
                    var dbProductCategory = _productCategoryService.GetById(productCategoryVM.CateID);
                    dbProductCategory.UpdateProductCategory(productCategoryVM);

                    _productCategoryService.Update(dbProductCategory);
                    _productCategoryService.SaveChanges();

                    var responseData = Mapper.Map<Tb_ProductCategory, ProductCategoryVM>(dbProductCategory);
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
                    var oldProductCategory = _productCategoryService.Delete(id);
                    _productCategoryService.SaveChanges();

                    var responseData = Mapper.Map<Tb_ProductCategory, ProductCategoryVM>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategory)
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
                    var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategory);
                    foreach (var item in listProductCategory)
                    {
                        _productCategoryService.Delete(item);
                    }
                    _productCategoryService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
                }
                return response;
            });
        }
    }
}