using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.ViewModels
{
    public class InvoiceViewModel
    {
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }
        [Display(Name = "Unit Price")]
        
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Units in Stock")]
        public short? UnitsInStock { get; set; }
        [Display(Name ="Units on Order")]
        public int? UnitsOnOrder { get; set; }
        public int? Amount { get; set; }
        public int SupplierId { get; set; }
        [Display(Name = "Supplier Name")]
        public string? SupplierName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Phone { get; set; }

        public List<SelectListItem>? SupplierList { get; set; }
        public List<SelectListItem>? ProductsList { get; set; }




    }
}
