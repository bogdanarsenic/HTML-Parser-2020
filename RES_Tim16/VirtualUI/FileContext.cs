using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using VirtualUI.Models;
using System.Diagnostics.CodeAnalysis;

namespace VirtualUI
{
    [ExcludeFromCodeCoverage]
    public class FileContext : DbContext
    {
        public FileContext()
            : base("FileDatabase")
        {
        }

        public virtual DbSet<Delta> Deltas { get; set; }
        public virtual DbSet<FileContent> FileContents { get; set; }
        public virtual DbSet<Files> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
