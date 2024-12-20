using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.ViewModels
{
    public class OrderViewModel
    {
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int InvoiceID { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }


        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }


        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }


        [Display(Name = "Units in Stock")]
        public short? UnitsInStock { get; set; }


        public int? Quantity { get; set; }


        public decimal? ItemTotal { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TotalAmount { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Phone { get; set; }

        public string? SupplierName { get; set; }

        public List<SelectListItem>? SupplierList { get; set; }
        public List<SelectListItem>? ProductsList { get; set; }

    }
}
