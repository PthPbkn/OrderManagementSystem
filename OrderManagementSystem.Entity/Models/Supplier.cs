using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Entity.Models;

[Table("tbl_Suppliers")]
public partial class Supplier
{
    [Key]
    public int SupplierId { get; set; }

    public string? SupplierName { get; set; }

     public string? Address { get; set; }

    public string? City { get; set; }

    public string? PostCode { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Product> TblProducts { get; set; } = new List<Product>();
}
