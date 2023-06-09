﻿using MINHTHUShop.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace MINHTHUShop.Web.Infrastructure.Core
{
    public class Pagination<T>
    {
        public int Page { get; set; }// số trang

        public int Count //số item lấy ra
        {
            get
            {
                return (Item != null) ? Item.Count() : 0;
            }
        }

        public int TotalPage { get; set; }//tổng số trang

        public int TotalCount { get; set; }//tổng số bản ghi

        public int MaxPage { get; set; } //tổng số trang hiển thị

        public IEnumerable<BrandVM> Brand { get; set; }

        public IEnumerable<T> Item { get; set; }
    }
}