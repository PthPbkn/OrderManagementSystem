using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.Models
{
    [Table("tbl_Country")]
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string? CountryName { get; set; }
    }
}
