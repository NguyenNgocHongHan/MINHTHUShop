using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_FAQService : ITb_FAQService
    {
        private ITb_FAQRepository _tb_FAQRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_FAQService(ITb_FAQRepository tb_FAQRepository, IUnitOfWork unitOfWork)
        {
            this._tb_FAQRepository = tb_FAQRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_FAQ Create(Tb_FAQ tb_FAQ)
        {
            var faq = _tb_FAQRepository.Add(tb_FAQ);
            _unitOfWork.Commit();

            return faq;
        }

        public Tb_FAQ Delete(int id)
        {
            return _tb_FAQRepository.Delete(id);
        }

        public IEnumerable<Tb_FAQ> GetAll()
        {
            return _tb_FAQRepository.GetAll(new string[] { "Tb_FAQCategory" });
        }

        public IEnumerable<Tb_FAQ> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_FAQRepository.GetMulti(x => x.Question.Contains(keywork) || x.Answer.Contains(keywork));
            }
            else
            {
                return _tb_FAQRepository.GetAll();
            }
        }

        public IEnumerable<Tb_FAQ> GetAllByCategoryPaging(int cateID, int pageIndex, int pageSize, out int totalRow)
        {
            return _tb_FAQRepository.GetMultiPaging(x => x.Status == true && x.FAQCateID == cateID, out totalRow, pageIndex, pageSize, new string[] { "Tb_FAQCategory" });
        }

        public IEnumerable<Tb_FAQ> GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
            return _tb_FAQRepository.GetMultiPaging(x => x.Status == true, out totalRow, pageIndex, pageSize);
        }

        public Tb_FAQ GetById(int id)
        {
            return _tb_FAQRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_FAQ tb_FAQ)
        {
            _tb_FAQRepository.Update(tb_FAQ);
        }
    }

    public interface ITb_FAQService
    {
        Tb_FAQ Create(Tb_FAQ tb_FAQ);

        void Update(Tb_FAQ tb_FAQ);

        Tb_FAQ Delete(int id);

        void SaveChanges();

        Tb_FAQ GetById(int id);

        IEnumerable<Tb_FAQ> GetAll();

        IEnumerable<Tb_FAQ> GetAll(string keywork);

        IEnumerable<Tb_FAQ> GetAllPaging(int pageIndex, int pageSize, out int totalRow);

        IEnumerable<Tb_FAQ> GetAllByCategoryPaging(int cateID, int pageIndex, int pageSize, out int totalRow);
    }
}