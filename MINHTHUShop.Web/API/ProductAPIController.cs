using AutoMapper;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Infrastructure.Core;
using MINHTHUShop.Web.Infrastructure.Extensions;
using MINHTHUShop.Web.Models;
using NWebsec.Helpers;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MINHTHUShop.Web.API
{
    [RoutePrefix("api/Product")]
    //[Authorize]
    public class ProductAPIController : APIControllerBase
    {
        #region Khởi tạo
        private ITb_ProductService _productService;

        public ProductAPIController(ITb_ErrorService errorService, ITb_ProductService productService)
            : base(errorService)
        {
            this._productService = productService;
        }
        #endregion

        [Route("GetAllParents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _productService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Tb_Product>, IEnumerable<ProductVM>>(model);
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
                var model = _productService.GetById(id);
                var responseData = Mapper.Map<Tb_Product, ProductVM>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        /*[Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int pageIndex, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _productService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.CreateDate).Skip(pageIndex * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Tb_Product>, IEnumerable<ProductVM>>(query.AsEnumerable());

                var paginationSet = new PaginationSet<ProductVM>()
                {
                    Items = responseData,
                    Page = pageIndex,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }*/


        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductVM productCategoryVM)
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
                    var newProduct = new Tb_Product();
                    newProduct.UpdateProduct(productCategoryVM);
                    newProduct.CreateDate = DateTime.Now;
                    _productService.Create(newProduct);
                    _productService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Product, ProductVM>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductVM productVM)
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
                    var dbProduct = _productService.GetById(productVM.ProductID);
                    dbProduct.UpdateProduct(productVM);
                    _productService.Update(dbProduct);
                    _productService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Product, ProductVM>(dbProduct);
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
                    var oldProduct = _productService.Delete(id);
                    _productService.SaveChanges();

                    var responseData = Mapper.Map<Tb_Product, ProductVM>(oldProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("DeleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProducts)
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
                    var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProducts);
                    foreach (var item in listProductCategory)
                    {
                        _productService.Delete(item);
                    }

                    _productService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
                }
                return response;
            });
        }

        [Route("import")]
        [HttpPost]
        public async Task<HttpResponseMessage> Import()
        {
            //kiểm tra xem request có chứa multipart/form-data không
            if (!Request.Content.IsMimeMultipartContent())
            {
                Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "Định dạng không được hỗ trợ");
            }

            var root = HttpContext.Current.Server.MapPath("~/UploadedFiles/Excels");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            //đọc dữ liệu từ một form sử dụng định dạng multipart/form-data
            var provider = new MultipartFormDataStreamProvider(root);
            //đọc dữ liệu từ form data và trả về task Async 
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            //thực hiện thao tác với file theo mong muốn
            if (result.FormData["CateID"] == null)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bạn chưa chọn danh mục sản phẩm.");
            }

            //Upload files
            int addedCount = 0;
            int cateId = 0;
            int.TryParse(result.FormData["CateID"], out cateId);
            //lấy file name
            foreach (MultipartFileData fileData in result.FileData)
            {
                if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
                {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Yêu cầu không đúng định dạng");
                }
                string fileName = fileData.Headers.ContentDisposition.FileName;
                if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                {
                    fileName = fileName.Trim('"');
                }
                if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                {
                    fileName = Path.GetFileName(fileName);
                }

                var fullPath = Path.Combine(root, fileName);
                File.Copy(fileData.LocalFileName, fullPath, true);

                //insert to DB
                var listProduct = this.ReadProductFromExcel(fullPath, cateId);
                if (listProduct.Count > 0)
                {
                    foreach (var product in listProduct)
                    {
                        _productService.Create(product);
                        addedCount++;
                    }
                    _productService.SaveChanges();
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Đã nhập thành công " + addedCount + " sản phẩm thành công.");
        }

        /*[HttpGet]
        [Route("ExportXls")]
        public async Task<HttpResponseMessage> ExportXls(HttpRequestMessage request, string filter = null)
        {
            string fileName = string.Concat("Product_" + DateTime.Now.ToString("yyyyMMddhhmmsss") + ".xlsx");
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fullPath = Path.Combine(filePath, fileName);
            try
            {
                var data = _productService.GetListProduct(filter).ToList();
                await ReportHelper.GenerateXls(data, fullPath);
                return request.CreateErrorResponse(HttpStatusCode.OK, Path.Combine(folderReport, fileName));
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }*/

       /* [HttpGet]
        [Route("ExportPdf")]
        public async Task<HttpResponseMessage> ExportPdf(HttpRequestMessage request, int id)
        {
            string fileName = string.Concat("Product" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".pdf");
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fullPath = Path.Combine(filePath, fileName);
            try
            {
                var template = File.ReadAllText(HttpContext.Current.Server.MapPath("/Assets/admin/templates/product-detail.html"));
                var replaces = new Dictionary<string, string>();
                var product = _productService.GetById(id);

                replaces.Add("{{ProductName}}", product.Name);
                replaces.Add("{{Price}}", product.Price.ToString("N0"));
                replaces.Add("{{Description}}", product.Description);

                template = template.Parse(replaces);

                await ReportHelper.GeneratePdf(template, fullPath);
                return request.CreateErrorResponse(HttpStatusCode.OK, Path.Combine(folderReport, fileName));
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }*/

        private List<Tb_Product> ReadProductFromExcel(string fullPath, int categoryId)
        {
            using (var package = new ExcelPackage(new FileInfo(fullPath)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                List<Tb_Product> listProduct = new List<Tb_Product>();
                ProductVM productViewModel;
                Tb_Product product;

                decimal price = 0;
                decimal promotionPrice;


                bool status = false;

                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    productViewModel = new ProductVM();
                    product = new Tb_Product();

                    productViewModel.Name = workSheet.Cells[i, 1].Value.ToString();
                    //productViewModel.Alias = StringHelper.ToUnsignString(productViewModel.Name);
                    productViewModel.Description = workSheet.Cells[i, 2].Value.ToString();

                    decimal.TryParse(workSheet.Cells[i, 5].Value.ToString().Replace(",", ""), out price);
                    productViewModel.Price = price;

                    if (decimal.TryParse(workSheet.Cells[i, 6].Value.ToString(), out promotionPrice))
                    {
                        productViewModel.PromotionPrice = promotionPrice;

                    }

                    productViewModel.Description = workSheet.Cells[i, 7].Value.ToString();
                    productViewModel.MetaKeywords = workSheet.Cells[i, 8].Value.ToString();
                    productViewModel.MetaDescriptions = workSheet.Cells[i, 9].Value.ToString();

                    productViewModel.CateID = categoryId;

                    bool.TryParse(workSheet.Cells[i, 10].Value.ToString(), out status);
                    productViewModel.Status = status;

                    product.UpdateProduct(productViewModel);
                    listProduct.Add(product);
                }
                return listProduct;
            }
        }
    }
}