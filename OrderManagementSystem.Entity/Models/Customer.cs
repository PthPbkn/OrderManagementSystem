using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Entity.Models;

[Table("tbl_Customer")]
public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? Title { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? PostCode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Order> TblOrders { get; set; } = new List<Order>();
}
