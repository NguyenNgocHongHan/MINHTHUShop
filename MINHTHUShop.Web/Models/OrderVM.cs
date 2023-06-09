﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Web.Models
{
    public class OrderVM
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerMobile { get; set; }
        public int OrderStatusID { get; set; }
        public int ShippingMethodID { get; set; }
        public int PaymentMethodID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Note { get; set; }

        [ForeignKey("CustomerID")]
        public virtual UserVM CustomerVM { get; set; }
        public virtual OrderStatusVM OrderStatusVM { get; set; }
        public virtual ShippingMethodVM ShippingMethodVM { get; set; }
        public virtual PaymentMethodVM PaymentMethodVM { get; set; }

        public virtual IEnumerable<OrderDetailVM> OrderDetailVMs { get; set; }
        public IEnumerable<PaymentMethodVM> PaymentMethodVMs { get; set; }
        public IEnumerable<ShippingMethodVM> ShippingMethodVMs { get; set; }
    }
}