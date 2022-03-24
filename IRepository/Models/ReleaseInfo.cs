using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRepository.Models
{
    public partial class ReleaseInfo
    {
        public ReleaseInfo()
        {
            ChangeInfo = new HashSet<ChangeInfo>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ReleaseDate { get; set; }
        public int? PublishStatus { get; set; }
        public int ReleaseTypeId { get; set; }
        public int ChangeLogTypeId { get; set; }

        [InverseProperty("Release")]
        public virtual ICollection<ChangeInfo> ChangeInfo { get; set; }
    }
}
