using Microsoft.VisualStudio.TestTools.UnitTesting;
using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using Moq;
using System.Collections.Generic;

namespace MINHTHUShop.UnitTest.ServiceTest
{
    [TestClass]
    public class Tb_ProductCategoryServiceTest
    {
        //khởi tạo đối tượng ảo để test
        private Mock<ITb_ProductCategoryRepository> mockRepo;

        private Mock<IUnitOfWork> mockUnit;
        private ITb_ProductCategoryService productCateService;
        private List<Tb_ProductCategory> list;

        //phương thức khởi tạo
        [TestInitialize]
        public void Initialize()
        {
            mockRepo = new Mock<ITb_ProductCategoryRepository>();
            mockUnit = new Mock<IUnitOfWork>();
            productCateService = new Tb_ProductCategoryService(mockRepo.Object, mockUnit.Object);
            list = new List<Tb_ProductCategory>()
            {
                new Tb_ProductCategory(){Name = "Tẩy Trang"},
                new Tb_ProductCategory(){Name="Mặt Nạ"},
                new Tb_ProductCategory(){Name = "Toner"},
                new Tb_ProductCategory(){Name = "Xịt Khoáng"},
            };
        }

        [TestMethod]
        public void Create()
        {
            Tb_ProductCategory productCategory = new Tb_ProductCategory();
            productCategory.Name = "test";

            //phương pháp thiết lập
            mockRepo.Setup(m => m.Add(productCategory)).Returns(productCategory);

            //thực thi test tạo mới danh mục
            var result = productCateService.Create(productCategory);

            //so sánh kết quả test
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAll()
        {
            mockRepo.Setup(m => m.GetAll(null)).Returns(list);

            var result = productCateService.GetAll() as List<Tb_ProductCategory>;

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
        }
    }
}