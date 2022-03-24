using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRepository.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermissions>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(128)]
        public string Name { get; set; }

        [InverseProperty("Permission")]
        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
    }
}
