using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_OrderDetailService : ITb_OrderDetailService
    {
        private ITb_OrderDetailRepository _tb_OrderDetailRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_OrderDetailService(ITb_OrderDetailRepository tb_OrderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._tb_OrderDetailRepository = tb_OrderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Tb_OrderDetail> GetAll()
        {
            return _tb_OrderDetailRepository.GetAll();
        }
    }

    public interface ITb_OrderDetailService
    {
        IEnumerable<Tb_OrderDetail> GetAll();
    }
}