﻿using Erpfyp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RelevantPizza.ViewModels
{
    public class OrderAddViewModel
    {
        //public int OrderID { get; set; }

        [DisplayName("Customer")]
        public int CustomerID { get; set; }

        public OrderType OrderType { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }

        public IEnumerable<SelectListItem> CustomerList { get; set; }
    }
}
