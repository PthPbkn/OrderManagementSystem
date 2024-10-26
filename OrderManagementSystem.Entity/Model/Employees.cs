using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.Model
{
    [Table("tbl_Employees")]
    public class Employees
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
        [Display(Name ="Title of Courtesy")]
        public string? TitleofCourtesy { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }
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
        public string? Country { get; set; }
        [Required]
        public int? Phone { get; set; }
        public string? Photo { get; set; }
        public string? Notes { get; set; }
        public string? ReportsTo { get; set; }
        public string? PhotoPath { get; set; }
    }
}
