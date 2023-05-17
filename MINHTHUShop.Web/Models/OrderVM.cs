﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Web.Models
{
    public class OrderVM
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string StaffID { get; set; }
        public int OrderStatusID { get; set; }
        public int ShippingMethodID { get; set; }
        public int PaymentMethodID { get; set; }
        public decimal? Total { get; set; }
        public DateTime CreateDate { get; set; }
        public string Note { get; set; }
        public bool IsCancel { get; set; }

        public virtual CustomerVM CustomerVM { get; set; }
        public virtual StaffVM StaffVM { get; set; }
        public virtual OrderStatusVM OrderStatusVM { get; set; }
        public virtual ShippingMethodVM ShippingMethodVM { get; set; }
        public virtual PaymentMethodVM PaymentMethodVM { get; set; }

        public virtual IEnumerable<OrderDetailVM> OrderDetailVMs { get; set; }
    }
}