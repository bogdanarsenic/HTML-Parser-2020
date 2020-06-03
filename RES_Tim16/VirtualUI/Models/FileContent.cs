using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace VirtualUI.Models
{
   

    [Table("FileContent")]
    public partial class FileContent
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string FileId { get; set; }

        [StringLength(100)]
        public string Content { get; set; }
    }
}
