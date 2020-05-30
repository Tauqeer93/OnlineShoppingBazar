﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingBazar.Models
{
    public class ShippingDetail
    {
        public int ShippinDetailId { get; set; }
        [Required]
        public Nullable<int> MemberId { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public Nullable<int> OrderId { get; set; }
        [Required]
        public Nullable<decimal> AmountPaid { get; set; }
        [Required]
        public string PaymentType { get; set; }
    }
}