using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace VirtualUI.Models
{
   

    [Table("Delta")]
    public partial class Delta
    {
        [Key]
        [StringLength(50)]
        public string FileId { get; set; }

        [StringLength(50)]
        public string LineRange { get; set; }

        [StringLength(100)]
        public string Content { get; set; }
    }
}
