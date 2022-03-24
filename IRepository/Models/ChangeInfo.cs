using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRepository.Models
{
    public partial class ChangeInfo
    {
        [Key]
        public int Id { get; set; }
        public int ReleaseId { get; set; }
        public int? AreaId { get; set; }
        public int TypeId { get; set; }
        [Required]
        [StringLength(2000)]
        public string Details { get; set; }
        [StringLength(200)]
        public string ReferenceLink { get; set; }
        public int? ContentCategoryId { get; set; }
        public int? Sequence { get; set; }

        [ForeignKey(nameof(AreaId))]
        [InverseProperty(nameof(ChangeArea.ChangeInfo))]
        public virtual ChangeArea Area { get; set; }
        [ForeignKey(nameof(ReleaseId))]
        [InverseProperty(nameof(ReleaseInfo.ChangeInfo))]
        public virtual ReleaseInfo Release { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(ChangeType.ChangeInfo))]
        public virtual ChangeType Type { get; set; }
    }
}
