using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;

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

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }

    public interface ITb_FeedbackService
    {
        Tb_Feedback Create(Tb_Feedback tb_Feedback);

        void SaveChanges();
    }
}