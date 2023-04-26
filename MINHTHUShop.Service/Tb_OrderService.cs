using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_OrderService : ITb_OrderService
    {
        private ITb_OrderRepository _tb_OrderRepository;
        private ITb_OrderDetailRepository _tb_OrderDetailRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_OrderService(ITb_OrderRepository tb_OrderRepository, ITb_OrderDetailRepository tb_OrderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._tb_OrderRepository = tb_OrderRepository;
            this._tb_OrderDetailRepository = tb_OrderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_Order Create(ref Tb_Order tb_Order, List<Tb_OrderDetail> tb_OrderDetails)
        {
            try
            {
                _tb_OrderRepository.Add(tb_Order);
                _unitOfWork.Commit();
                foreach (var tb_OrderDetail in tb_OrderDetails)
                {
                    tb_OrderDetail.OrderID = tb_Order.OrderID;
                    _tb_OrderDetailRepository.Add(tb_OrderDetail);
                }
                return tb_Order;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void UpdateStatus(int orderID)
        {
            var order = _tb_OrderRepository.GetById(orderID);
            _tb_OrderRepository.Update(order);
        }
    }

    public interface ITb_OrderService
    {
        Tb_Order Create(ref Tb_Order tb_Order, List<Tb_OrderDetail> tb_OrderDetails);

        void UpdateStatus(int orderID);

        void SaveChanges();
    }
}