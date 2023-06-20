using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_FAQCategoryService : ITb_FAQCategoryService
    {
        private ITb_FAQCategoryRepository _tb_FAQCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_FAQCategoryService(ITb_FAQCategoryRepository tb_FAQCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._tb_FAQCategoryRepository = tb_FAQCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_FAQCategory Create(Tb_FAQCategory tb_FAQCategory)
        {
            return _tb_FAQCategoryRepository.Add(tb_FAQCategory);
        }

        public Tb_FAQCategory Delete(int id)
        {
            return _tb_FAQCategoryRepository.Delete(id);
        }

        public IEnumerable<Tb_FAQCategory> GetAll()
        {
            return _tb_FAQCategoryRepository.GetAll();
        }

        public IEnumerable<Tb_FAQCategory> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_FAQCategoryRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                return _tb_FAQCategoryRepository.GetAll();
            }
        }

        public IEnumerable<Tb_FAQCategory> GetAllByParentId(int parentID)
        {
            return _tb_FAQCategoryRepository.GetMulti(x => x.ParentID == parentID);
        }

        public Tb_FAQCategory GetById(int id)
        {
            return _tb_FAQCategoryRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_FAQCategory tb_FAQCategory)
        {
            _tb_FAQCategoryRepository.Update(tb_FAQCategory);
        }
    }

    public interface ITb_FAQCategoryService
    {
        Tb_FAQCategory Create(Tb_FAQCategory tb_FAQCategory);

        void Update(Tb_FAQCategory tb_FAQCategory);

        Tb_FAQCategory Delete(int id);

        void SaveChanges();

        Tb_FAQCategory GetById(int id);

        IEnumerable<Tb_FAQCategory> GetAll();

        IEnumerable<Tb_FAQCategory> GetAll(string keywork);

        IEnumerable<Tb_FAQCategory> GetAllByParentId(int parentID);
    }
}