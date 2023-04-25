using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_NewsCategoryService : ITb_NewsCategoryService
    {
        private ITb_NewsCategoryRepository _tb_NewsCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_NewsCategoryService(ITb_NewsCategoryRepository tb_NewsCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._tb_NewsCategoryRepository = tb_NewsCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_NewsCategory Create(Tb_NewsCategory tb_NewsCategory)
        {
            return _tb_NewsCategoryRepository.Add(tb_NewsCategory);
        }

        public Tb_NewsCategory Delete(int id)
        {
            return _tb_NewsCategoryRepository.Delete(id);
        }

        public IEnumerable<Tb_NewsCategory> GetAll()
        {
            return _tb_NewsCategoryRepository.GetAll();
        }

        public IEnumerable<Tb_NewsCategory> GetAllByParentId(int parentID)
        {
            return _tb_NewsCategoryRepository.GetMulti(x => x.ParentID == parentID);
        }

        public Tb_NewsCategory GetById(int id)
        {
            return _tb_NewsCategoryRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_NewsCategory tb_NewsCategory)
        {
            _tb_NewsCategoryRepository.Update(tb_NewsCategory);
        }
    }

    public interface ITb_NewsCategoryService
    {
        Tb_NewsCategory Create(Tb_NewsCategory tb_NewsCategory);

        void Update(Tb_NewsCategory tb_NewsCategory);

        Tb_NewsCategory Delete(int id);

        void SaveChanges();

        Tb_NewsCategory GetById(int id);

        IEnumerable<Tb_NewsCategory> GetAll();

        IEnumerable<Tb_NewsCategory> GetAllByParentId(int parentID);
    }
}