using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.Models
{
    [Table("tbl_Invoice")]
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public string? CreationDate { get; set; }
        public int? SupplierId { get; set; }
        public int? ProductId { get; set; }
        public int? UnitsOrdered { get; set; }
        public string? SubTotal { get; set; }
        public string? Tax { get; set; }
        public string? TotalAmt { get; set; }
        public string? Amount { get; set; }

    }
}
