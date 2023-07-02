using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using SnnbFailover.Server.Models.SNNBStatus;

namespace SnnbFailover.Server.Data
{
    public partial class SNNBStatusContext : DbContext
    {
        public SNNBStatusContext()
        {
        }

        public SNNBStatusContext(DbContextOptions<SNNBStatusContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=SNNB-PC02;database=snnb;Trusted_Connection=true; Persist Security Info=True; TrustServerCertificate=True; User ID=Collector; Password=btp1997");
            //            optionsBuilder.UseSqlServer(_configuration.);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SnnbFailover.Server.Models.SNNBStatus.Site1Status>().HasNoKey();

            builder.Entity<SnnbFailover.Server.Models.SNNBStatus.Site2Status>().HasNoKey();

            builder.Entity<SnnbFailover.Server.Models.SNNBStatus.SiteAttrLimit>().HasNoKey();
            this.OnModelBuilding(builder);
        }

        public DbSet<SnnbFailover.Server.Models.SNNBStatus.Site1Status> Site1Statuses { get; set; }

        public DbSet<SnnbFailover.Server.Models.SNNBStatus.Site2Status> Site2Statuses { get; set; }

        public DbSet<SnnbFailover.Server.Models.SNNBStatus.SiteAttrLimit> SiteAttrLimits { get; set; }
    }
}