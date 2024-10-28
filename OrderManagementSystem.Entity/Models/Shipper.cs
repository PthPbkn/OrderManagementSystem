using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Entity.Models;

public partial class Shipper
{
    [Key]
    public int ShipperId { get; set; }

    public string? CompanyName { get; set; }

    public string? Phone { get; set; }
}
