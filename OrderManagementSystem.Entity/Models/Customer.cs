﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Entity.Models;

public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    public string? CompanyName { get; set; }

    public string? ContactName { get; set; }

    public string? ContactTitle { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? PostCode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Order> TblOrders { get; set; } = new List<Order>();
}