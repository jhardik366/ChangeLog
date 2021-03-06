using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRepository.Models
{
    public partial class ChangeType
    {
        public ChangeType()
        {
            ChangeInfo = new HashSet<ChangeInfo>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Type")]
        public virtual ICollection<ChangeInfo> ChangeInfo { get; set; }
    }
}
