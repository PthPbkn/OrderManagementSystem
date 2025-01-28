using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Entity.Models;

[Table("tbl_Category")]
public partial class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Display(Name ="Category")]
    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public string? PicturePath { get; set; }

    public virtual ICollection<Product> TblProducts { get; set; } = new List<Product>();
}
