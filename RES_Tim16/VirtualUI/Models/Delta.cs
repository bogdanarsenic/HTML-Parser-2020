using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Diagnostics.CodeAnalysis;

namespace VirtualUI.Models
{

    [ExcludeFromCodeCoverage]
    [Table("Delta")]
    public partial class Delta
    {
        [Key]
        [StringLength(50)]
        public virtual string FileId { get; set; }

        [StringLength(50)]
        public virtual string LineRange { get; set; }

        [StringLength(500)]
        public virtual string Content { get; set; }
    }
}
