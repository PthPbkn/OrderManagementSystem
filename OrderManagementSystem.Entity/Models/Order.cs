using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Entity.Models;

public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? RequiredDate { get; set; }

    public DateOnly? ShippedDate { get; set; }

    public string? ShippVia { get; set; }

    public decimal? Freight { get; set; }

    public string? ShippName { get; set; }

    public string? ShippAddress { get; set; }

    public string? ShippCity { get; set; }

    public string? ShippPostCode { get; set; }

    public string? ShippCountry { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }
}
