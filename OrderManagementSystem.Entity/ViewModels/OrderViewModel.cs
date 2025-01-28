using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagementSystem.Entity.Models;
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
        public int? EmployeeID { get; set; }
        public int InvoiceID { get; set; }
        public int SupplierId { get; set; }
        public int OrderID { get; set; }
        public Nullable<DateTime> OrderDate { get; set; }

        [Display(Name = "Product Name")]
           public string? ProductName { get; set; }

        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Units in Stock")]
        public int? UnitsInStock { get; set; }
        public int? Quantity { get; set; }
        public float? ItemTotal { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        [Display(Name = "Supplier")]

        public string? SupplierName { get; set; }

        [Display(Name = "Customer")]

        public string? CustomerName { get; set; }
        public string? UserID { get; set; }
        public string? UserName { get; set; }

        public List<SelectListItem>? SupplierList { get; set; }

        public List<SelectListItem>? ProductsList { get; set; }

        public List<SelectListItem>? CustomersList { get; set; }
        public Order? Order { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
