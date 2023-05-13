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
    [RoutePrefix("api/Brand")]
    public class BrandAPIController : APIControllerBase
    {
        #region Khởi tạo

        private ITb_BrandService _brandService;

        public BrandAPIController(ITb_ErrorService errorService, ITb_BrandService brandService)
            : base(errorService)
        {
            this._brandService = brandService;
        }

        #endregion Khởi tạo

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _brandService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_Brand>, IEnumerable<BrandVM>>(model);
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
                var model = _brandService.GetById(id);
                var responseData = Mapper.Map<Tb_Brand, BrandVM>(model);
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
                var model = _brandService.GetAll(keyword);

                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_Brand>, IEnumerable<BrandVM>>(query);

                var pagination = new Pagination<BrandVM>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, BrandVM brandVM)
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
                    var newBrand = new Tb_Brand();
                    //update
                    newBrand.UpdateBrand(brandVM);
                    _brandService.Create(newBrand);
                    _brandService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Brand, BrandVM>(newBrand);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, BrandVM brandVM)
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
                    var dbBrand = _brandService.GetById(brandVM.BrandID);
                    dbBrand.UpdateBrand(brandVM);

                    _brandService.Update(dbBrand);
                    _brandService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Brand, BrandVM>(dbBrand);
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
                    var oldBrand = _brandService.Delete(id);
                    _brandService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Brand, BrandVM>(oldBrand);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedBrand)
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
                    var listBrand = new JavaScriptSerializer().Deserialize<List<int>>(checkedBrand);
                    foreach (var item in listBrand)
                    {
                        _brandService.Delete(item);
                    }
                    _brandService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listBrand.Count);
                }
                return response;
            });
        }
    }
}