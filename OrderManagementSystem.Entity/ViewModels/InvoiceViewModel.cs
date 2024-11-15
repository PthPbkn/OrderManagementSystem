using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.ViewModels
{
    public class InvoiceViewModel
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Phone { get; set; }
    }
}
