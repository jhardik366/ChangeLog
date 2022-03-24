using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRepository.Models
{
    public partial class RolePermissions
    {
        [Key]
        public Guid RoleId { get; set; }
        [Key]
        public Guid PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        [InverseProperty("RolePermissions")]
        public virtual Permission Permission { get; set; }
    }
}
