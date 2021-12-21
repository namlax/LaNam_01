using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NamLa.Models
{
    public partial class LTQLDbContext : DbContext
    {
        public LTQLDbContext() : base("name=LTQLDbContext")
        {
        }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity <SanPham>()
		.Property(e => e.MaSanPham)
		.IsUnicode(false);
    }

        public System.Data.Entity.DbSet<NamLa.Models.SanPham> SanPhams { get; set; }

        public System.Data.Entity.DbSet<NamLa.Models.Account> Accounts { get; set; }
    }
}