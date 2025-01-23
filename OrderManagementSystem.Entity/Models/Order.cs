using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Entity.Models;

[Table("tbl_Order")]
public partial class Order
{
    [Key]
    public int OrderID { get; set; }
    public string? UserID { get; set; }
    public int? CustomerID { get; set; }
    public int? EmployeeID { get; set; }
    public int? InvoiceID { get; set; }    
    public Nullable<DateTime> OrderDate { get; set; }
    public decimal? SubTotal { get; set; }
    public decimal? Tax { get; set; }
    public decimal? Discount { get; set; }
    public decimal? TotalAmount { get; set; }

}
