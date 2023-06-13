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

        public bool Create(Tb_Order order, List<Tb_OrderDetail> orderDetails)
        {
            try
            {
                _tb_OrderRepository.Add(order);
                _unitOfWork.Commit();

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = order.OrderID;
                    _tb_OrderDetailRepository.Add(orderDetail);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
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
        bool Create(Tb_Order order, List<Tb_OrderDetail> orderDetails);

        void UpdateStatus(int orderID);

        void SaveChanges();
    }
}