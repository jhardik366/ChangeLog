using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IManager
{
    public class ReleaseInfoDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int? PublishStatus { get; set; }
    }
}
