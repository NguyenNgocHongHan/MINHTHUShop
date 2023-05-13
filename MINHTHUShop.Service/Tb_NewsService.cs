using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_NewsService : ITb_NewsService
    {
        private ITb_NewsRepository _tb_NewsRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_NewsService(ITb_NewsRepository tb_NewsRepository, IUnitOfWork unitOfWork)
        {
            this._tb_NewsRepository = tb_NewsRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_News Create(Tb_News tb_News)
        {
            return _tb_NewsRepository.Add(tb_News);
        }

        public Tb_News Delete(int id)
        {
            return _tb_NewsRepository.Delete(id);
        }

        public IEnumerable<Tb_News> GetAll()
        {
            return _tb_NewsRepository.GetAll(new string[] { "Tb_NewsCategory" });
        }

        public IEnumerable<Tb_News> GetAllByCategoryPaging(int cateID, int pageIndex, int pageSize, out int totalRow)
        {
            return _tb_NewsRepository.GetMultiPaging(x => x.Status == true && x.NewsCateID == cateID, out totalRow, pageIndex, pageSize, new string[] { "Tb_NewsCategory" });
        }

        //lấy ra tất cả các bài viết theo thẻ tag
        public IEnumerable<Tb_News> GetAllByTagPaging(string tagID, int pageIndex, int pageSize, out int totalRow)
        {
            return _tb_NewsRepository.GetAllByTag(tagID, pageIndex, pageSize, out totalRow);
        }

        public IEnumerable<Tb_News> GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
            return _tb_NewsRepository.GetMultiPaging(x => x.Status == true, out totalRow, pageIndex, pageSize);
        }

        public Tb_News GetById(int id)
        {
            return _tb_NewsRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_News tb_News)
        {
            _tb_NewsRepository.Update(tb_News);
        }
    }

    public interface ITb_NewsService
    {
        Tb_News Create(Tb_News tb_News);

        void Update(Tb_News tb_News);

        Tb_News Delete(int id);

        void SaveChanges();

        Tb_News GetById(int id);

        IEnumerable<Tb_News> GetAll();

        IEnumerable<Tb_News> GetAllPaging(int pageIndex, int pageSize, out int totalRow);

        IEnumerable<Tb_News> GetAllByCategoryPaging(int cateID, int pageIndex, int pageSize, out int totalRow);

        IEnumerable<Tb_News> GetAllByTagPaging(string tagID, int pageIndex, int pageSize, out int totalRow);
    }
}