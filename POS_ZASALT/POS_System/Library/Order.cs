﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Order
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public decimal TotalPrice
        {
            get;set;
        }

        public double amount;
        public double change;


    }

    }
