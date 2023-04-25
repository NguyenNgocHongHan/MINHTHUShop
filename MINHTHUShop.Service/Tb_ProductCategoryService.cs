using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_ProductCategoryService : ITb_ProductCategoryService
    {
        private ITb_ProductCategoryRepository _tb_ProductCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_ProductCategoryService(ITb_ProductCategoryRepository tb_ProductCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._tb_ProductCategoryRepository = tb_ProductCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_ProductCategory Create(Tb_ProductCategory tb_ProductCategory)
        {
            return _tb_ProductCategoryRepository.Add(tb_ProductCategory);
        }

        public Tb_ProductCategory Delete(int id)
        {
            return _tb_ProductCategoryRepository.Delete(id);
        }

        public IEnumerable<Tb_ProductCategory> GetAll()
        {
            return _tb_ProductCategoryRepository.GetAll();
        }

        public IEnumerable<Tb_ProductCategory> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_ProductCategoryRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                return _tb_ProductCategoryRepository.GetAll();
            }
        }

        public IEnumerable<Tb_ProductCategory> GetAllByParentId(int parentID)
        {
            return _tb_ProductCategoryRepository.GetMulti(x => x.ParentID == parentID);
        }

        public Tb_ProductCategory GetById(int id)
        {
            return _tb_ProductCategoryRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_ProductCategory tb_ProductCategory)
        {
            _tb_ProductCategoryRepository.Update(tb_ProductCategory);
        }
    }

    public interface ITb_ProductCategoryService
    {
        Tb_ProductCategory Create(Tb_ProductCategory tb_ProductCategory);

        void Update(Tb_ProductCategory tb_ProductCategory);

        Tb_ProductCategory Delete(int id);

        Tb_ProductCategory GetById(int id);

        void SaveChanges();

        IEnumerable<Tb_ProductCategory> GetAll();

        IEnumerable<Tb_ProductCategory> GetAll(string keywork);

        IEnumerable<Tb_ProductCategory> GetAllByParentId(int parentID);
    }
}