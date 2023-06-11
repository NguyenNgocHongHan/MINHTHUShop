﻿using System;

namespace MINHTHUShop.Web.Models
{
    [Serializable]
    public class CartVM
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public ProductVM Product { get; set; }
    }
}