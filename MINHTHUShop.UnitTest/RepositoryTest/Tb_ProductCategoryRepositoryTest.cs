using Microsoft.VisualStudio.TestTools.UnitTesting;
using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Linq;

namespace MINHTHUShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class Tb_ProductCategoryRepositoryTest
    {
        private IDbFactory dbFactory;
        private ITb_ProductCategoryRepository tb_ProductCategoryRepository;
        private IUnitOfWork unitOfWork;

        //khởi tạo đối tượng
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            tb_ProductCategoryRepository = new Tb_ProductCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        //Test phương thức tạo mới một danh mục sản phẩm, có thay đổi csdl trên DB
        [TestMethod]
        public void Create()
        {
            //khởi tạo 1 danh mục sản phẩm
            Tb_ProductCategory productCategory = new Tb_ProductCategory();
            //khởi tạo giá trị cho các thuộc tính trong bảng Tb_ProductCategory
            //lưu ý: các thuộc tính NOT NULL phải có giá trị, các thuộc tính NULL có thể không nhập giá trị
            productCategory.Name = "Sữa Rửa Mặt";

            //lệnh thêm và lưu vào db
            var result = tb_ProductCategoryRepository.Add(productCategory);
            unitOfWork.Commit();

            //điều kiện kiểm tra TestCase
            //kiểm tra dữ liệu được thêm vào có khác NULL không
            Assert.IsNotNull(result);
            //kiểm tra id mới tạo có bằng 1 không
            //Assert.AreEqual(1, result.CateID);
        }

        //test case lấy ra danh mục sản phẩm
        [TestMethod]
        public void GetAll()
        {
            //lấy ra danh sách các danh mục
            var list = tb_ProductCategoryRepository.GetAll().ToList();

            //kiểm tra xem tất cả các danh mục sản phẩm trong danh sách có bằng 1 không
            Assert.AreEqual(1, list.Count);
        }
    }
}