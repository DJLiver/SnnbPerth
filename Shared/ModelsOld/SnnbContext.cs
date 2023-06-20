using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SnnbFailover.Shared.Models;

public partial class SnnbContext : DbContext
{
    public SnnbContext()
    {
    }

    public SnnbContext(DbContextOptions<SnnbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatabaseMaint> DatabaseMaints { get; set; }

    public virtual DbSet<FormatConfig> FormatConfigs { get; set; }

    public virtual DbSet<MetricAlarm> MetricAlarms { get; set; }

    public virtual DbSet<MetricConfig> MetricConfigs { get; set; }

    public virtual DbSet<MetricCount> MetricCounts { get; set; }

    public virtual DbSet<MetricEvent> MetricEvents { get; set; }

    public virtual DbSet<MetricMonitor> MetricMonitors { get; set; }

    public virtual DbSet<MetricSite1Summary> MetricSite1Summaries { get; set; }

    public virtual DbSet<MetricSite2Summary> MetricSite2Summaries { get; set; }

    public virtual DbSet<RangeConfig> RangeConfigs { get; set; }

    public virtual DbSet<Target> Targets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(@"Server=SNNB-PC02;database=snnb;Trusted_Connection=true; Persist Security Info=True; TrustServerCertificate=True; User ID=Collector; Password=btp1997");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatabaseMaint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Database__3214EC077D3560EA");

            entity.ToTable("DatabaseMaint");

            entity.Property(e => e.DBtable)
                .HasMaxLength(50)
                .HasColumnName("dBTable");
        });

        modelBuilder.Entity<FormatConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FormatCo__3214EC07CB630337");

            entity.ToTable("FormatConfig");

            entity.Property(e => e.Attr).HasMaxLength(50);
            entity.Property(e => e.Format).HasMaxLength(50);
            entity.Property(e => e.Normal).HasMaxLength(50);
            entity.Property(e => e.Units).HasMaxLength(50);
        });

        modelBuilder.Entity<MetricAlarm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MetricAl__3214EC072B14D9D1");

            entity.ToTable("MetricAlarm");

            entity.Property(e => e.Attribute).HasMaxLength(50);
            entity.Property(e => e.Message).HasMaxLength(250);
            entity.Property(e => e.Target).HasMaxLength(50);
        });

        modelBuilder.Entity<MetricConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ConfigCh__3214EC07B0F2333C");

            entity.ToTable("MetricConfig");

            entity.Property(e => e.Attribute).HasMaxLength(50);
            entity.Property(e => e.Message).HasMaxLength(250);
            entity.Property(e => e.Target).HasMaxLength(50);
        });

        modelBuilder.Entity<MetricCount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MetricCo__3214EC0792CC760C");

            entity.Property(e => e.ComDiscardedPackets).HasColumnName("Com_discardedPackets");
            entity.Property(e => e.RfOutDroppedPackets).HasColumnName("RfOut_droppedPackets");
            entity.Property(e => e.RfOutGapCount).HasColumnName("RfOut_gapCount");
            entity.Property(e => e.RfOutPfecMissingSets).HasColumnName("RfOut_pfecMissingSets");
            entity.Property(e => e.RfOutPfecRepairedPackets).HasColumnName("RfOut_pfecRepairedPackets");
            entity.Property(e => e.RfOutPfecTotalPackets).HasColumnName("RfOut_pfecTotalPackets");
            entity.Property(e => e.RfOutPfecUnrepairablePackets).HasColumnName("RfOut_pfecUnrepairablePackets");
            entity.Property(e => e.RfOutPreserveLatencyLatePackets).HasColumnName("RfOut_preserveLatencyLatePackets");
            entity.Property(e => e.RfOutPreserveLatencyMaxBurstLoss).HasColumnName("RfOut_preserveLatencyMaxBurstLoss");
            entity.Property(e => e.RfOutPreserveLatencyMissingPackets).HasColumnName("RfOut_preserveLatencyMissingPackets");
            entity.Property(e => e.RfOutPreserveLatencyOutOfOrderPackets).HasColumnName("RfOut_preserveLatencyOutOfOrderPackets");
            entity.Property(e => e.RfOutUnderflowCount).HasColumnName("RfOut_underflowCount");
            entity.Property(e => e.Target).HasMaxLength(50);
        });

        modelBuilder.Entity<MetricEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MetricEv__3214EC07EE96F174");

            entity.Property(e => e.Attribute).HasMaxLength(50);
            entity.Property(e => e.Message).HasMaxLength(250);
            entity.Property(e => e.Target).HasMaxLength(50);
        });

        modelBuilder.Entity<MetricMonitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Monitor__3214EC0771021307");

            entity.ToTable("MetricMonitor");

            entity.Property(e => e.Target).HasMaxLength(50);
        });

        modelBuilder.Entity<MetricSite1Summary>(entity =>
        {
            entity.ToTable("MetricSite1Summary");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComAddress).HasMaxLength(50);
            entity.Property(e => e.ComCompositeStatus).HasMaxLength(50);
            entity.Property(e => e.ComCompositeStatusMsg).HasMaxLength(512);
            entity.Property(e => e.ComContextPacketState).HasMaxLength(100);
            entity.Property(e => e.ComReplyWaitTime).HasMaxLength(50);
            entity.Property(e => e.ComRequiredReadPrivilege).HasMaxLength(50);
            entity.Property(e => e.ComRequiredWritePrivilege).HasMaxLength(50);
            entity.Property(e => e.ComRfOutputSource).HasMaxLength(50);
            entity.Property(e => e.ComSecuritySource).HasMaxLength(50);
            entity.Property(e => e.ComSerialNumber).HasMaxLength(50);
            entity.Property(e => e.ComShortDescription).HasMaxLength(250);
            entity.Property(e => e.ComSystemTimeSource).HasMaxLength(50);
            entity.Property(e => e.ComVersion).HasMaxLength(50);
            entity.Property(e => e.ComgainMode).HasMaxLength(50);
            entity.Property(e => e.Comgateway).HasMaxLength(50);
            entity.Property(e => e.ComhealthStatus).HasMaxLength(50);
            entity.Property(e => e.ComhealthStatusMsg).HasMaxLength(512);
            entity.Property(e => e.CominputRfBandwidth).HasMaxLength(50);
            entity.Property(e => e.CominputRfPortSelect).HasMaxLength(50);
            entity.Property(e => e.Comlabel).HasMaxLength(50);
            entity.Property(e => e.ComlogLevel).HasMaxLength(50);
            entity.Property(e => e.CommoduleState).HasMaxLength(50);
            entity.Property(e => e.CommoduleType).HasMaxLength(50);
            entity.Property(e => e.ComntpStatus).HasMaxLength(50);
            entity.Property(e => e.ComoutputRfPortSelect).HasMaxLength(50);
            entity.Property(e => e.ExtDestUnit).HasMaxLength(50);
            entity.Property(e => e.ExtDirection).HasMaxLength(50);
            entity.Property(e => e.ExtSourceUnit).HasMaxLength(50);
            entity.Property(e => e.RfinbitRate).HasColumnName("RFinbitRate");
            entity.Property(e => e.RfindataSampleWidth).HasColumnName("RFindataSampleWidth");
            entity.Property(e => e.RfindestinationHost)
                .HasMaxLength(50)
                .HasColumnName("RFindestinationHost");
            entity.Property(e => e.RfindestinationPort).HasColumnName("RFindestinationPort");
            entity.Property(e => e.RfinfrequencyOffset).HasColumnName("RFinfrequencyOffset");
            entity.Property(e => e.RfinmaximumPacketSize).HasColumnName("RFinmaximumPacketSize");
            entity.Property(e => e.RfinmeasuredNetworkRate).HasColumnName("RFinmeasuredNetworkRate");
            entity.Property(e => e.RfinmeasuredPacketRate).HasColumnName("RFinmeasuredPacketRate");
            entity.Property(e => e.RfinminimumProcessingDelay).HasColumnName("RFinminimumProcessingDelay");
            entity.Property(e => e.Rfinname)
                .HasMaxLength(50)
                .HasColumnName("RFinname");
            entity.Property(e => e.RfinpacketOverhead).HasColumnName("RFinpacketOverhead");
            entity.Property(e => e.RfinpfecEnable).HasColumnName("RFinpfecEnable");
            entity.Property(e => e.RfinrouteSearch)
                .HasMaxLength(50)
                .HasColumnName("RFinrouteSearch");
            entity.Property(e => e.RfinsourcePort).HasColumnName("RFinsourcePort");
            entity.Property(e => e.RfinstreamBandwidth).HasColumnName("RFinstreamBandwidth");
            entity.Property(e => e.RfinstreamEnable).HasColumnName("RFinstreamEnable");
            entity.Property(e => e.RfinstreamGain).HasColumnName("RFinstreamGain");
            entity.Property(e => e.RfinstreamId).HasColumnName("RFinstreamId");
            entity.Property(e => e.RfinstreamSampleRate).HasColumnName("RFinstreamSampleRate");
            entity.Property(e => e.RfoutcurrentBuffer).HasColumnName("RFoutcurrentBuffer");
            entity.Property(e => e.RfoutdataSampleWidth).HasColumnName("RFoutdataSampleWidth");
            entity.Property(e => e.RfoutdataSource)
                .HasMaxLength(50)
                .HasColumnName("RFoutdataSource");
            entity.Property(e => e.RfoutdesiredBuffer).HasColumnName("RFoutdesiredBuffer");
            entity.Property(e => e.RfoutdesiredDelay).HasColumnName("RFoutdesiredDelay");
            entity.Property(e => e.RfoutdestinationPort).HasColumnName("RFoutdestinationPort");
            entity.Property(e => e.RfoutdroppedPackets).HasColumnName("RFoutdroppedPackets");
            entity.Property(e => e.RfoutfrequencyOffset).HasColumnName("RFoutfrequencyOffset");
            entity.Property(e => e.RfoutgapCount).HasColumnName("RFoutgapCount");
            entity.Property(e => e.RfoutmeasuredDelay).HasColumnName("RFoutmeasuredDelay");
            entity.Property(e => e.RfoutmeasuredNetworkRate).HasColumnName("RFoutmeasuredNetworkRate");
            entity.Property(e => e.RfoutmeasuredPacketRate).HasColumnName("RFoutmeasuredPacketRate");
            entity.Property(e => e.Rfoutname)
                .HasMaxLength(50)
                .HasColumnName("RFoutname");
            entity.Property(e => e.RfoutnetStreamGain).HasColumnName("RFoutnetStreamGain");
            entity.Property(e => e.RfoutnetworkDelay).HasColumnName("RFoutnetworkDelay");
            entity.Property(e => e.RfoutpacketOverhead).HasColumnName("RFoutpacketOverhead");
            entity.Property(e => e.RfoutpfecDecoderStatus)
                .HasMaxLength(50)
                .HasColumnName("RFoutpfecDecoderStatus");
            entity.Property(e => e.RfoutpfecMissingSets).HasColumnName("RFoutpfecMissingSets");
            entity.Property(e => e.RfoutpfecRepairedPackets).HasColumnName("RFoutpfecRepairedPackets");
            entity.Property(e => e.RfoutpfecTotalPackets).HasColumnName("RFoutpfecTotalPackets");
            entity.Property(e => e.RfoutpfecUnrepairablePackets).HasColumnName("RFoutpfecUnrepairablePackets");
            entity.Property(e => e.RfoutpreserveLatency).HasColumnName("RFoutpreserveLatency");
            entity.Property(e => e.RfoutpreserveLatencyLatePackets).HasColumnName("RFoutpreserveLatencyLatePackets");
            entity.Property(e => e.RfoutpreserveLatencyMaxBurstLoss).HasColumnName("RFoutpreserveLatencyMaxBurstLoss");
            entity.Property(e => e.RfoutpreserveLatencyMissingPackets).HasColumnName("RFoutpreserveLatencyMissingPackets");
            entity.Property(e => e.RfoutpreserveLatencyOutOfOrderPackets).HasColumnName("RFoutpreserveLatencyOutOfOrderPackets");
            entity.Property(e => e.RfoutpreserveLatencyReleaseMargin).HasColumnName("RFoutpreserveLatencyReleaseMargin");
            entity.Property(e => e.RfoutreleaseMode)
                .HasMaxLength(50)
                .HasColumnName("RFoutreleaseMode");
            entity.Property(e => e.RfoutsourceHost)
                .HasMaxLength(50)
                .HasColumnName("RFoutsourceHost");
            entity.Property(e => e.RfoutsourcePort).HasColumnName("RFoutsourcePort");
            entity.Property(e => e.RfoutstreamBandwidth).HasColumnName("RFoutstreamBandwidth");
            entity.Property(e => e.RfoutstreamEnable).HasColumnName("RFoutstreamEnable");
            entity.Property(e => e.RfoutstreamId).HasColumnName("RFoutstreamId");
            entity.Property(e => e.RfoutstreamSampleRate).HasColumnName("RFoutstreamSampleRate");
            entity.Property(e => e.RfoutunderflowCount).HasColumnName("RFoutunderflowCount");
            entity.Property(e => e.RfoutupstreamIrigLocked).HasColumnName("RFoutupstreamIrigLocked");
            entity.Property(e => e.RfoutupstreamOnePpsLocked).HasColumnName("RFoutupstreamOnePpsLocked");
            entity.Property(e => e.RfoutupstreamPathGain).HasColumnName("RFoutupstreamPathGain");
            entity.Property(e => e.RfoutupstreamTenMhzLocked).HasColumnName("RFoutupstreamTenMhzLocked");
            entity.Property(e => e.RfoutuseLocalReference).HasColumnName("RFoutuseLocalReference");
        });

        modelBuilder.Entity<MetricSite2Summary>(entity =>
        {
            entity.ToTable("MetricSite2Summary");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComAddress).HasMaxLength(50);
            entity.Property(e => e.ComCompositeStatus).HasMaxLength(50);
            entity.Property(e => e.ComCompositeStatusMsg).HasMaxLength(512);
            entity.Property(e => e.ComContextPacketState).HasMaxLength(100);
            entity.Property(e => e.ComReplyWaitTime).HasMaxLength(50);
            entity.Property(e => e.ComRequiredReadPrivilege).HasMaxLength(50);
            entity.Property(e => e.ComRequiredWritePrivilege).HasMaxLength(50);
            entity.Property(e => e.ComRfOutputSource).HasMaxLength(50);
            entity.Property(e => e.ComSecuritySource).HasMaxLength(50);
            entity.Property(e => e.ComSerialNumber).HasMaxLength(50);
            entity.Property(e => e.ComShortDescription).HasMaxLength(250);
            entity.Property(e => e.ComSystemTimeSource).HasMaxLength(50);
            entity.Property(e => e.ComVersion).HasMaxLength(50);
            entity.Property(e => e.ComgainMode).HasMaxLength(50);
            entity.Property(e => e.Comgateway).HasMaxLength(50);
            entity.Property(e => e.ComhealthStatus).HasMaxLength(50);
            entity.Property(e => e.ComhealthStatusMsg).HasMaxLength(512);
            entity.Property(e => e.CominputRfBandwidth).HasMaxLength(50);
            entity.Property(e => e.CominputRfPortSelect).HasMaxLength(50);
            entity.Property(e => e.Comlabel).HasMaxLength(50);
            entity.Property(e => e.ComlogLevel).HasMaxLength(50);
            entity.Property(e => e.CommoduleState).HasMaxLength(50);
            entity.Property(e => e.CommoduleType).HasMaxLength(50);
            entity.Property(e => e.ComntpStatus).HasMaxLength(50);
            entity.Property(e => e.ComoutputRfPortSelect).HasMaxLength(50);
            entity.Property(e => e.ExtDestUnit).HasMaxLength(50);
            entity.Property(e => e.ExtDirection).HasMaxLength(50);
            entity.Property(e => e.ExtSourceUnit).HasMaxLength(50);
            entity.Property(e => e.RfinbitRate).HasColumnName("RFinbitRate");
            entity.Property(e => e.RfindataSampleWidth).HasColumnName("RFindataSampleWidth");
            entity.Property(e => e.RfindestinationHost)
                .HasMaxLength(50)
                .HasColumnName("RFindestinationHost");
            entity.Property(e => e.RfindestinationPort).HasColumnName("RFindestinationPort");
            entity.Property(e => e.RfinfrequencyOffset).HasColumnName("RFinfrequencyOffset");
            entity.Property(e => e.RfinmaximumPacketSize).HasColumnName("RFinmaximumPacketSize");
            entity.Property(e => e.RfinmeasuredNetworkRate).HasColumnName("RFinmeasuredNetworkRate");
            entity.Property(e => e.RfinmeasuredPacketRate).HasColumnName("RFinmeasuredPacketRate");
            entity.Property(e => e.RfinminimumProcessingDelay).HasColumnName("RFinminimumProcessingDelay");
            entity.Property(e => e.Rfinname)
                .HasMaxLength(50)
                .HasColumnName("RFinname");
            entity.Property(e => e.RfinpacketOverhead).HasColumnName("RFinpacketOverhead");
            entity.Property(e => e.RfinpfecEnable).HasColumnName("RFinpfecEnable");
            entity.Property(e => e.RfinrouteSearch)
                .HasMaxLength(50)
                .HasColumnName("RFinrouteSearch");
            entity.Property(e => e.RfinsourcePort).HasColumnName("RFinsourcePort");
            entity.Property(e => e.RfinstreamBandwidth).HasColumnName("RFinstreamBandwidth");
            entity.Property(e => e.RfinstreamEnable).HasColumnName("RFinstreamEnable");
            entity.Property(e => e.RfinstreamGain).HasColumnName("RFinstreamGain");
            entity.Property(e => e.RfinstreamId).HasColumnName("RFinstreamId");
            entity.Property(e => e.RfinstreamSampleRate).HasColumnName("RFinstreamSampleRate");
            entity.Property(e => e.RfoutcurrentBuffer).HasColumnName("RFoutcurrentBuffer");
            entity.Property(e => e.RfoutdataSampleWidth).HasColumnName("RFoutdataSampleWidth");
            entity.Property(e => e.RfoutdataSource)
                .HasMaxLength(50)
                .HasColumnName("RFoutdataSource");
            entity.Property(e => e.RfoutdesiredBuffer).HasColumnName("RFoutdesiredBuffer");
            entity.Property(e => e.RfoutdesiredDelay).HasColumnName("RFoutdesiredDelay");
            entity.Property(e => e.RfoutdestinationPort).HasColumnName("RFoutdestinationPort");
            entity.Property(e => e.RfoutdroppedPackets).HasColumnName("RFoutdroppedPackets");
            entity.Property(e => e.RfoutfrequencyOffset).HasColumnName("RFoutfrequencyOffset");
            entity.Property(e => e.RfoutgapCount).HasColumnName("RFoutgapCount");
            entity.Property(e => e.RfoutmeasuredDelay).HasColumnName("RFoutmeasuredDelay");
            entity.Property(e => e.RfoutmeasuredNetworkRate).HasColumnName("RFoutmeasuredNetworkRate");
            entity.Property(e => e.RfoutmeasuredPacketRate).HasColumnName("RFoutmeasuredPacketRate");
            entity.Property(e => e.Rfoutname)
                .HasMaxLength(50)
                .HasColumnName("RFoutname");
            entity.Property(e => e.RfoutnetStreamGain).HasColumnName("RFoutnetStreamGain");
            entity.Property(e => e.RfoutnetworkDelay).HasColumnName("RFoutnetworkDelay");
            entity.Property(e => e.RfoutpacketOverhead).HasColumnName("RFoutpacketOverhead");
            entity.Property(e => e.RfoutpfecDecoderStatus)
                .HasMaxLength(50)
                .HasColumnName("RFoutpfecDecoderStatus");
            entity.Property(e => e.RfoutpfecMissingSets).HasColumnName("RFoutpfecMissingSets");
            entity.Property(e => e.RfoutpfecRepairedPackets).HasColumnName("RFoutpfecRepairedPackets");
            entity.Property(e => e.RfoutpfecTotalPackets).HasColumnName("RFoutpfecTotalPackets");
            entity.Property(e => e.RfoutpfecUnrepairablePackets).HasColumnName("RFoutpfecUnrepairablePackets");
            entity.Property(e => e.RfoutpreserveLatency).HasColumnName("RFoutpreserveLatency");
            entity.Property(e => e.RfoutpreserveLatencyLatePackets).HasColumnName("RFoutpreserveLatencyLatePackets");
            entity.Property(e => e.RfoutpreserveLatencyMaxBurstLoss).HasColumnName("RFoutpreserveLatencyMaxBurstLoss");
            entity.Property(e => e.RfoutpreserveLatencyMissingPackets).HasColumnName("RFoutpreserveLatencyMissingPackets");
            entity.Property(e => e.RfoutpreserveLatencyOutOfOrderPackets).HasColumnName("RFoutpreserveLatencyOutOfOrderPackets");
            entity.Property(e => e.RfoutpreserveLatencyReleaseMargin).HasColumnName("RFoutpreserveLatencyReleaseMargin");
            entity.Property(e => e.RfoutreleaseMode)
                .HasMaxLength(50)
                .HasColumnName("RFoutreleaseMode");
            entity.Property(e => e.RfoutsourceHost)
                .HasMaxLength(50)
                .HasColumnName("RFoutsourceHost");
            entity.Property(e => e.RfoutsourcePort).HasColumnName("RFoutsourcePort");
            entity.Property(e => e.RfoutstreamBandwidth).HasColumnName("RFoutstreamBandwidth");
            entity.Property(e => e.RfoutstreamEnable).HasColumnName("RFoutstreamEnable");
            entity.Property(e => e.RfoutstreamId).HasColumnName("RFoutstreamId");
            entity.Property(e => e.RfoutstreamSampleRate).HasColumnName("RFoutstreamSampleRate");
            entity.Property(e => e.RfoutunderflowCount).HasColumnName("RFoutunderflowCount");
            entity.Property(e => e.RfoutupstreamIrigLocked).HasColumnName("RFoutupstreamIrigLocked");
            entity.Property(e => e.RfoutupstreamOnePpsLocked).HasColumnName("RFoutupstreamOnePpsLocked");
            entity.Property(e => e.RfoutupstreamPathGain).HasColumnName("RFoutupstreamPathGain");
            entity.Property(e => e.RfoutupstreamTenMhzLocked).HasColumnName("RFoutupstreamTenMhzLocked");
            entity.Property(e => e.RfoutuseLocalReference).HasColumnName("RFoutuseLocalReference");
        });

        modelBuilder.Entity<RangeConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RangeCon__3214EC071F66AA41");

            entity.ToTable("RangeConfig");

            entity.Property(e => e.Attr).HasMaxLength(50);
            entity.Property(e => e.Unit).HasMaxLength(50);
        });

        modelBuilder.Entity<Target>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Target__3214EC07C6D81793");

            entity.ToTable("Target");

            entity.Property(e => e.Direction).HasMaxLength(50);
            entity.Property(e => e.IpAddress).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PeerUnit).HasMaxLength(50);
            entity.Property(e => e.Query).HasMaxLength(250);
            entity.Property(e => e.RemoteUnit).HasMaxLength(50);
            entity.Property(e => e.Site).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
