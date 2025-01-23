using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Entity.Models;

[Table("tbl_OrderDetails")]
public partial class OrderDetail
{
    [Key]
    public int OrderDetailsID { get; set; }
    public int OrderID { get; set; }
    public int? ProductID { get; set; }
    public int? CustomerID { get; set; }
    public int? InvoiceID { get; set; }
    public DateTime? OrderDate { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? Quantity { get; set; }
    public decimal? ItemTotal { get; set; } 

}
