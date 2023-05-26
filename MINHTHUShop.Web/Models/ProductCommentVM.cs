﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Web.Models
{
    public class ProductCommentVM
    {
        public int CommentID { get; set; }
        public int ProductID { get; set; }
        public string CustomerID { get; set; }
        public float Vote { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        public virtual ProductVM ProductVM { get; set; }
        [ForeignKey("CustomerID")]
        public virtual UserVM CustomerVM { get; set; }
    }
}