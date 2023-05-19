using MINHTHUShop.Common;
using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINHTHUShop.Service
{
    public class Tb_ProductService : ITb_ProductService
    {
        private ITb_ProductRepository _tb_ProductRepository;
        private ITb_TagRepository _tb_TagRepository;
        private ITb_TagProductRepository _tb_TagProductRepository;
        private IUnitOfWork _unitOfWork;

        public  Tb_ProductService(ITb_ProductRepository tb_ProductRepository, ITb_TagRepository tb_TagRepository, ITb_TagProductRepository tb_TagProductRepository, IUnitOfWork unitOfWork)
        {
            this._tb_ProductRepository = tb_ProductRepository;
            this._tb_TagRepository = tb_TagRepository;
            this._tb_TagProductRepository = tb_TagProductRepository;
            this._unitOfWork = unitOfWork;
        }
        public Tb_Product Create(Tb_Product tb_Product)
        {
            var product = _tb_ProductRepository.Add(tb_Product);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(tb_Product.Tag))
            {
                string[] tags = tb_Product.Tag.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tb_TagRepository.Count(x => x.TagID == tagId) == 0)
                    {
                        Tb_Tag tag = new Tb_Tag();
                        tag.TagID = tagId;
                        tag.Name = tags[i].ToUpper();
                        tag.Type = CommonConstants.ProductTag;
                        _tb_TagRepository.Add(tag);
                    }

                    Tb_TagProduct productTag = new Tb_TagProduct();
                    productTag.ProductID = tb_Product.ProductID;
                    productTag.TagID = tagId;
                    _tb_TagProductRepository.Add(productTag);
                }
            }
            return product;
        }

        public Tb_Product Delete(int id)
        {
            return _tb_ProductRepository.Delete(id);
        }

        public IEnumerable<Tb_Product> GetAll()
        {
            return _tb_ProductRepository.GetAll();
        }

        public IEnumerable<Tb_Product> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_ProductRepository.GetMulti(x => x.Name.Contains(keywork) || x.Description.Contains(keywork));
            }
            else
            {
                return _tb_ProductRepository.GetAll();
            }
        }

        public Tb_Product GetById(int id)
        {
            return _tb_ProductRepository.GetById(id);
        }

        public IEnumerable<Tb_Product> GetLastest(int top)
        {
            return _tb_ProductRepository.GetMulti(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public IEnumerable<Tb_Product> GetListProduct(string keywork)
        {
            IEnumerable<Tb_Product> query;
            if (!string.IsNullOrEmpty(keywork))
            {
                query = _tb_ProductRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                query = _tb_ProductRepository.GetAll();
            }
            return query;
        }

        public IEnumerable<string> GetListProductByName(string name)
        {
            return _tb_ProductRepository.GetMulti(x => x.Status == true && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Tb_Product> GetListProductByTag(string tagID, int pageIndex, int pageSize, out int totalRow)
        {
            var model = _tb_ProductRepository.GetListProductByTag(tagID, pageIndex, pageSize, out totalRow);
            return model;
        }

        public IEnumerable<Tb_Product> GetRelatedProduct(int id, int top)
        {
            var product = _tb_ProductRepository.GetById(id);
            return _tb_ProductRepository.GetMulti(x => x.Status == true && x.ProductID != id && x.CateID == product.CateID).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public Tb_Tag GetTag(string tagID)
        {
            return _tb_TagRepository.GetSingleByCondition(x => x.TagID == tagID);
        }

        public IEnumerable<Tb_Product> GetProductByCateId(int cateID)
        {
            var query = _tb_ProductRepository.GetMulti(x => x.Status == true && x.CateID == cateID);

            return query;
        }

        public IEnumerable<Tb_Product> GetListProductByCateIdPaging(int cateID, int pageIndex, int pageSize, string sort, out int totalRow)
        {
            var query = _tb_ProductRepository.GetMulti(x => x.Status && x.CateID == cateID);
            switch (sort)
            {
                case "new":
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
                case "lowToHigh":
                    query = query.OrderBy(x => x.PromotionPrice);
                    break;
                case "highToLow":
                    query = query.OrderByDescending(x => x.PromotionPrice);
                    break;
                default:
                    query = query.OrderBy(x => x.Name);
                    break;
            }
            totalRow = query.Count();

            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Tb_Product> Search(string keywork, int pageIndex, int pageSize, string sort, out int totalRow)
        {
            var query = _tb_ProductRepository.GetMulti(x => x.Status == true && x.Name.Contains(keywork));
            switch (sort)
            {
                case "new":
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
                case "lowToHigh":
                    query = query.OrderBy(x => x.PromotionPrice);
                    break;
                case "highToLow":
                    query = query.OrderByDescending(x => x.PromotionPrice);
                    break;
                default:
                    query = query.OrderBy(x => x.Name);
                    break;
            }
            totalRow = query.Count();
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public void Update(Tb_Product tb_Product)
        {
            _tb_ProductRepository.Update(tb_Product);

            if (!string.IsNullOrEmpty(tb_Product.Tag))
            {
                string[] tags = tb_Product.Tag.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tb_TagRepository.Count(x => x.TagID == tagId) == 0)
                    {
                        Tb_Tag tag = new Tb_Tag();
                        tag.TagID = tagId;
                        tag.Name = tags[i].ToUpper();
                        tag.Type = CommonConstants.ProductTag;
                        _tb_TagRepository.Add(tag);
                    }

                    _tb_TagProductRepository.DeleteMulti(x => x.ProductID == tb_Product.ProductID);
                    Tb_TagProduct productTag = new Tb_TagProduct();
                    productTag.ProductID = tb_Product.ProductID;
                    productTag.TagID = tagId;
                    _tb_TagProductRepository.Add(productTag);
                }
            }
        }
    }

    public interface ITb_ProductService
    {
        Tb_Product Create(Tb_Product tb_Product);
        void Update(Tb_Product tb_Product);
        Tb_Product Delete(int id); 
        Tb_Product GetById(int id);
        Tb_Tag GetTag(string tagID);
        void SaveChanges();
        IEnumerable<Tb_Product> GetAll();
        IEnumerable<Tb_Product> GetAll(string keywork);
        IEnumerable<Tb_Product> GetLastest(int top);
        IEnumerable<Tb_Product> GetProductByCateId(int cateID);
        IEnumerable<Tb_Product> Search(string keywork, int pageIndex, int pageSize, string sort, out int totalRow);
        IEnumerable<Tb_Product> GetRelatedProduct(int id, int top);
        IEnumerable<Tb_Product> GetListProduct(string keywork);
        IEnumerable<string> GetListProductByName(string name);
        IEnumerable<Tb_Product> GetListProductByTag(string tagID, int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Tb_Product> GetListProductByCateIdPaging(int cateID, int pageIndex, int pageSize, string sort, out int totalRow);
    }
}
