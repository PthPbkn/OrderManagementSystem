using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Entity.Models;

[Table("tbl_Employee")]
public partial class Employee
{
    [Key]
    public int EmployeeID { get; set; }
    [Required]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    [Required]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }
    [Required]
    public string? Title { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateOnly? BirthDate { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Hire Date")]
    public DateOnly? HireDate { get; set; }
    [Required]
    [Display(Name = "House Number")]
    public int? HouseNumber { get; set; }
    [Required]
    [Display(Name = "Street Name")]
    public string? StreetName { get; set; }
    [Required]
    public string? City { get; set; }
    [Required]
    [Display(Name = "Post Code")]
    public string? PostCode { get; set; }
    [Required]
    [Display(Name ="Country")]
    public int CountryID { get; set; }
    [Required]
    public int Phone { get; set; }
    [Required]
    public string? Gender { get; set; }
    [Required]
    [Display(Name ="Department")]
    public int? DepartmentID { get; set; }
    [NotMapped]
    public List<SelectListItem>? DepartmentList { get; set; }

    public virtual ICollection<Order> TblOrders { get; set; } = new List<Order>();
}
