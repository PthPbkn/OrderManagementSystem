using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.ViewModels
{
    public class AddRemoveRoleViewModel
    {
        public required string RoleId { get; set; }

        public required string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
