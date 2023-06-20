using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_FeedbackService : ITb_FeedbackService
    {
        private ITb_FeedbackRepository _tb_FeedbackRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_FeedbackService(ITb_FeedbackRepository tb_FeedbackRepository, IUnitOfWork unitOfWork)
        {
            this._tb_FeedbackRepository = tb_FeedbackRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_Feedback Create(Tb_Feedback tb_Feedback)
        {
            return _tb_FeedbackRepository.Add(tb_Feedback);
        }

        public Tb_Feedback Delete(int id)
        {
            return _tb_FeedbackRepository.Delete(id);
        }

        public IEnumerable<Tb_Feedback> GetAll()
        {
            return _tb_FeedbackRepository.GetAll();
        }

        public IEnumerable<Tb_Feedback> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_FeedbackRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                return _tb_FeedbackRepository.GetAll();
            }
        }

        public IEnumerable<Tb_Feedback> GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
            return _tb_FeedbackRepository.GetMultiPaging(x => x.IsRead == false, out totalRow, pageIndex, pageSize);
        }

        public Tb_Feedback GetById(int id)
        {
            return _tb_FeedbackRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_Feedback tb_Feedback)
        {
            _tb_FeedbackRepository.Update(tb_Feedback);
        }
    }

    public interface ITb_FeedbackService
    {
        Tb_Feedback Create(Tb_Feedback tb_Feedback);

        void SaveChanges();

        void Update(Tb_Feedback tb_Feedback);

        Tb_Feedback Delete(int id);

        Tb_Feedback GetById(int id);

        IEnumerable<Tb_Feedback> GetAll();

        IEnumerable<Tb_Feedback> GetAll(string keywork);

        IEnumerable<Tb_Feedback> GetAllPaging(int pageIndex, int pageSize, out int totalRow);
    }
}