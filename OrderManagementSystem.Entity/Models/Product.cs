using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Entity.Models;

[Table("tbl_Products")]
public partial class Product
{
    [Key]
    public int ProductId { get; set; }
    [Display(Name = "Product Name")]
    public string? ProductName { get; set; }
    [Display(Name ="Supplier")]
    public int? SupplierId { get; set; }
    [Display(Name = "Category")]
    public int? CategoryId { get; set; }
    [Display(Name = "Quantity")]
    public int? QuantityPerUnit { get; set; }
    [Display(Name = "Unit Price")]
    public decimal? UnitPrice { get; set; }
    [Display(Name = "Units in Stock")]
    public int? UnitsInStock { get; set; }
    [Display(Name = "Units on Order")]
    public short? UnitsOnOrder { get; set; }

    public short? RecorderLevel { get; set; }

    public bool? Discontinued { get; set; }
    public string? ImagePath { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Supplier? Supplier { get; set; }
    [NotMapped]
    public IFormFile? File { get; set; }

    [NotMapped]
    public List<SelectListItem>? CategoryList { get; set; }
    [NotMapped]
    public List<SelectListItem>? SupplierList { get; set; }

    public virtual ICollection<OrderDetail> TblOrderDetails { get; set; } = new List<OrderDetail>();
}
