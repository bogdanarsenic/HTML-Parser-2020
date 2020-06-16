using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Diagnostics.CodeAnalysis;

namespace VirtualUI.Models
{

    [ExcludeFromCodeCoverage]
    [Table("FileContent")]
    public partial class FileContent
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string FileId { get; set; }

        [StringLength(500)]
        public string Content { get; set; }
    }
}
