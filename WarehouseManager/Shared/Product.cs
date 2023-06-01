﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehouseManager.Shared
{
    public class Product
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }
		
		public string? Manufacturer { get; set; }
		
		public double PurchasePrice { get; set; }

        public double SalePrice { get; set; }
        
        public int Quantity { get; set; }

		public Product() { }
        public Product(int id, string name, string manufacturer, double purchasePrice, double salePrice, int quantity)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            Quantity = quantity;
        }
    }
}
