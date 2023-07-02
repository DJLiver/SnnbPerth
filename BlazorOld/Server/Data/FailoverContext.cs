using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using SnnbFailover.Server.Models.Failover;

namespace SnnbFailover.Server.Data
{
    public partial class FailoverContext : DbContext
    {
        public FailoverContext()
        {
        }

        public FailoverContext(DbContextOptions<FailoverContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=SNNB-PC02;database=SnnbFailover;Trusted_Connection=true; Persist Security Info=True; TrustServerCertificate=True; User ID=Collector; Password=btp1997");
            //            optionsBuilder.UseSqlServer(_configuration.);
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.OnModelBuilding(builder);
        }

        public DbSet<SnnbFailover.Server.Models.Failover.Control> Controls { get; set; }

        public DbSet<SnnbFailover.Server.Models.Failover.EventLog> EventLogs { get; set; }
    }
}