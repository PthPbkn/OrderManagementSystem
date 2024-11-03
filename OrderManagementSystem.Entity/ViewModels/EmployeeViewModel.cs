using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.ViewModels
{
    public class EmployeeViewModel
    {
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
        [Display(Name = "Country")]
        public int CountryID { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }
        public String  DepartName { get; set; }
        public String  CountryName { get; set; }
        public string? ImagePath { get; set; }
    }
}
