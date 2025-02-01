using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.ViewModels
{
    public class ProductViewModel
    {        

        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }

        [Display(Name = "Category")]
        public string? CategoryName { get; set; }
        [Display(Name = "Supplier")]
        public string? SupplierName { get; set; }
        [Display(Name = "Quantity")]
        public int? QuantityPerUnit { get; set; }
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Units in Stock")]
        public int? UnitsInStock { get; set; }
        [Display(Name = "Units on Order")]
        public short? UnitsOnOrder { get; set; }

        public bool? Discontinued { get; set; }
        public string? ImagePath { get; set; }

        public IFormFile? file { get; set; }


    }
}
