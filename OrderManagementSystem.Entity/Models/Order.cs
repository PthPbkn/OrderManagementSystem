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
    public int? CustomerID { get; set; }
    public int? EmployeeID { get; set; }
    public int? InvoiceID { get; set; }
    public DateOnly? OrderDate { get; set; }
    public float? SubTotal { get; set; }
    public float? Tax { get; set; }
    public float? Discount { get; set; }
    public float? TotalAmount { get; set; }

}
