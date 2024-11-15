﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Entity.Models;

public partial class OrderDetail
{
    [Key]
    public int OrderId { get; set; }

    public int? ProductId { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? Quantity { get; set; }

    public float? Discount { get; set; }

    public virtual Product? Product { get; set; }
}
