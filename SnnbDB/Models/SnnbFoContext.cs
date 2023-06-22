using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SnnbDB.Models;

public partial class SnnbFoContext : DbContext
{
    public SnnbFoContext()
    {
    }

    public SnnbFoContext(DbContextOptions<SnnbFoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HSpecNetGroup> HSpecNetGroups { get; set; }

    public virtual DbSet<MControlNic> MControlNics { get; set; }

    public virtual DbSet<MDataNic> MDataNics { get; set; }

    public virtual DbSet<MDependency> MDependencies { get; set; }

    public virtual DbSet<MModule> MModules { get; set; }

    public virtual DbSet<MMulticastGroupSubscription> MMulticastGroupSubscriptions { get; set; }

    public virtual DbSet<MRfInputStream> MRfInputStreams { get; set; }

    public virtual DbSet<MRfOutputStream> MRfOutputStreams { get; set; }

    public virtual DbSet<MRoute> MRoutes { get; set; }

    public virtual DbSet<MSpectrum> MSpectrums { get; set; }

    public virtual DbSet<View1> View1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SNNB-PC02;database=snnb_FO;Trusted_Connection=true; Persist Security Info=True; TrustServerCertificate=True; User ID=Collector; Password=btp1997");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HSpecNetGroup>(entity =>
        {
            entity.ToTable("H_SpecNetGroups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChassisName).HasMaxLength(128);
            entity.Property(e => e.Direction).HasMaxLength(128);
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.GroupName).HasMaxLength(128);
            entity.Property(e => e.IpAddress).HasMaxLength(128);
            entity.Property(e => e.Location).HasMaxLength(128);
            entity.Property(e => e.PreIpAddress).HasMaxLength(128);
            entity.Property(e => e.RestQuery).HasMaxLength(128);
            entity.Property(e => e.Site).HasMaxLength(128);
            entity.Property(e => e.UnitName).HasMaxLength(128);
        });

        modelBuilder.Entity<MControlNic>(entity =>
        {
            entity
                .ToTable("M_ControlNic")
                .IsMemoryOptimized();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .HasColumnName("address");
            entity.Property(e => e.Addresses)
                .HasMaxLength(128)
                .HasColumnName("addresses");
            entity.Property(e => e.Netmask).HasColumnName("netmask");
        });

        modelBuilder.Entity<MDataNic>(entity =>
        {
            entity
                .ToTable("M_DataNic")
                .IsMemoryOptimized();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .HasColumnName("address");
            entity.Property(e => e.Addresses)
                .HasMaxLength(128)
                .HasColumnName("addresses");
            entity.Property(e => e.Netmask).HasColumnName("netmask");
        });

        modelBuilder.Entity<MDependency>(entity =>
        {
            entity
                .ToTable("M_Dependencies")
                .IsMemoryOptimized();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dependant)
                .HasMaxLength(128)
                .HasColumnName("dependant");
        });

        modelBuilder.Entity<MModule>(entity =>
        {
            entity
                .ToTable("M_Modules")
                .IsMemoryOptimized();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .HasColumnName("address");
            entity.Property(e => e.CompositeStatus)
                .HasMaxLength(128)
                .HasColumnName("compositeStatus");
            entity.Property(e => e.CompositeStatusMsg)
                .HasMaxLength(128)
                .HasColumnName("compositeStatusMsg");
            entity.Property(e => e.ContextPacketState)
                .HasMaxLength(128)
                .HasColumnName("contextPacketState");
            entity.Property(e => e.DiscardedPackets)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("discardedPackets");
            entity.Property(e => e.EnableMulticastGroupSubscriptions).HasColumnName("enableMulticastGroupSubscriptions");
            entity.Property(e => e.FanSpeed)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("fanSpeed");
            entity.Property(e => e.GainMode)
                .HasMaxLength(128)
                .HasColumnName("gainMode");
            entity.Property(e => e.Gateway)
                .HasMaxLength(128)
                .HasColumnName("gateway");
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(128)
                .HasColumnName("healthStatus");
            entity.Property(e => e.HealthStatusMsg)
                .HasMaxLength(128)
                .HasColumnName("healthStatusMsg");
            entity.Property(e => e.InputRfAdcSaturation).HasColumnName("inputRfAdcSaturation");
            entity.Property(e => e.InputRfAdcSaturationPercent).HasColumnName("inputRfAdcSaturationPercent");
            entity.Property(e => e.InputRfBandwidth)
                .HasMaxLength(128)
                .HasColumnName("inputRfBandwidth");
            entity.Property(e => e.InputRfCenterFrequency).HasColumnName("inputRfCenterFrequency");
            entity.Property(e => e.InputRfPort1AdcSaturation).HasColumnName("inputRfPort1AdcSaturation");
            entity.Property(e => e.InputRfPort1AdcSaturationPercent).HasColumnName("inputRfPort1AdcSaturationPercent");
            entity.Property(e => e.InputRfPort1MinimumGain).HasColumnName("inputRfPort1MinimumGain");
            entity.Property(e => e.InputRfPort1Power).HasColumnName("inputRfPort1Power");
            entity.Property(e => e.InputRfPort2AdcSaturation).HasColumnName("inputRfPort2AdcSaturation");
            entity.Property(e => e.InputRfPort2AdcSaturationPercent).HasColumnName("inputRfPort2AdcSaturationPercent");
            entity.Property(e => e.InputRfPort2MinimumGain).HasColumnName("inputRfPort2MinimumGain");
            entity.Property(e => e.InputRfPort2Power).HasColumnName("inputRfPort2Power");
            entity.Property(e => e.InputRfPortSelect)
                .HasMaxLength(128)
                .HasColumnName("inputRfPortSelect");
            entity.Property(e => e.InputRfPower).HasColumnName("inputRfPower");
            entity.Property(e => e.InputRfSampleRate)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("inputRfSampleRate");
            entity.Property(e => e.InvertRfOutputSpectrum).HasColumnName("invertRfOutputSpectrum");
            entity.Property(e => e.IrigDcLocked).HasColumnName("irigDcLocked");
            entity.Property(e => e.IrigLocked).HasColumnName("irigLocked");
            entity.Property(e => e.Label)
                .HasMaxLength(128)
                .HasColumnName("label");
            entity.Property(e => e.LogLevel)
                .HasMaxLength(128)
                .HasColumnName("logLevel");
            entity.Property(e => e.ManualGain).HasColumnName("manualGain");
            entity.Property(e => e.MinimumGain).HasColumnName("minimumGain");
            entity.Property(e => e.ModuleState)
                .HasMaxLength(128)
                .HasColumnName("moduleState");
            entity.Property(e => e.ModuleType)
                .HasMaxLength(128)
                .HasColumnName("moduleType");
            entity.Property(e => e.NtpStatus)
                .HasMaxLength(128)
                .HasColumnName("ntpStatus");
            entity.Property(e => e.OnePpsPresent).HasColumnName("onePpsPresent");
            entity.Property(e => e.OutputAttenuation).HasColumnName("outputAttenuation");
            entity.Property(e => e.OutputRfCenterFrequency).HasColumnName("outputRfCenterFrequency");
            entity.Property(e => e.OutputRfDacSaturation).HasColumnName("outputRfDacSaturation");
            entity.Property(e => e.OutputRfDacSaturationPercent).HasColumnName("outputRfDacSaturationPercent");
            entity.Property(e => e.OutputRfPort1DacSaturation).HasColumnName("outputRfPort1DacSaturation");
            entity.Property(e => e.OutputRfPort1DacSaturationPercent).HasColumnName("outputRfPort1DacSaturationPercent");
            entity.Property(e => e.OutputRfPort1Power).HasColumnName("outputRfPort1Power");
            entity.Property(e => e.OutputRfPort2DacSaturation).HasColumnName("outputRfPort2DacSaturation");
            entity.Property(e => e.OutputRfPort2DacSaturationPercent).HasColumnName("outputRfPort2DacSaturationPercent");
            entity.Property(e => e.OutputRfPort2Power).HasColumnName("outputRfPort2Power");
            entity.Property(e => e.OutputRfPortSelect)
                .HasMaxLength(128)
                .HasColumnName("outputRfPortSelect");
            entity.Property(e => e.OutputRfPower).HasColumnName("outputRfPower");
            entity.Property(e => e.OverrideOutputFrequency).HasColumnName("overrideOutputFrequency");
            entity.Property(e => e.OverrideOutputFrequencyEnable).HasColumnName("overrideOutputFrequencyEnable");
            entity.Property(e => e.PollInterval)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("pollInterval");
            entity.Property(e => e.PosixNanoseconds)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("posixNanoseconds");
            entity.Property(e => e.PosixSeconds)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("posixSeconds");
            entity.Property(e => e.RebootRequired).HasColumnName("rebootRequired");
            entity.Property(e => e.ReplyWaitTime).HasColumnName("replyWaitTime");
            entity.Property(e => e.RequiredReadPrivilege)
                .HasMaxLength(128)
                .HasColumnName("requiredReadPrivilege");
            entity.Property(e => e.RequiredWritePrivilege)
                .HasMaxLength(128)
                .HasColumnName("requiredWritePrivilege");
            entity.Property(e => e.RfOutputEnable).HasColumnName("rfOutputEnable");
            entity.Property(e => e.RfOutputSource)
                .HasMaxLength(128)
                .HasColumnName("rfOutputSource");
            entity.Property(e => e.SecuritySource)
                .HasMaxLength(128)
                .HasColumnName("securitySource");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(128)
                .HasColumnName("serialNumber");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(128)
                .HasColumnName("shortDescription");
            entity.Property(e => e.Simulate).HasColumnName("simulate");
            entity.Property(e => e.SquelchEnabled).HasColumnName("squelchEnabled");
            entity.Property(e => e.SystemTemperature).HasColumnName("systemTemperature");
            entity.Property(e => e.SystemTimeSource)
                .HasMaxLength(128)
                .HasColumnName("systemTimeSource");
            entity.Property(e => e.TenMhzLocked).HasColumnName("tenMhzLocked");
            entity.Property(e => e.Version)
                .HasMaxLength(128)
                .HasColumnName("version");
        });

        modelBuilder.Entity<MMulticastGroupSubscription>(entity =>
        {
            entity
                .ToTable("M_MulticastGroupSubscriptions")
                .IsMemoryOptimized();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dependant)
                .HasMaxLength(128)
                .HasColumnName("dependant");
        });

        modelBuilder.Entity<MRfInputStream>(entity =>
        {
            entity
                .ToTable("M_RfInputStream")
                .IsMemoryOptimized();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BitRate)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("bitRate");
            entity.Property(e => e.DataSampleWidth)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("dataSampleWidth");
            entity.Property(e => e.DestinationHost)
                .HasMaxLength(128)
                .HasColumnName("destinationHost");
            entity.Property(e => e.DestinationPort)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("destinationPort");
            entity.Property(e => e.FrequencyOffset).HasColumnName("frequencyOffset");
            entity.Property(e => e.MaximumPacketSize)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("maximumPacketSize");
            entity.Property(e => e.MeasuredNetworkRate)
                .HasColumnType("numeric(20, 0)")
                .HasColumnName("measuredNetworkRate");
            entity.Property(e => e.MeasuredPacketRate)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("measuredPacketRate");
            entity.Property(e => e.MinimumProcessingDelay).HasColumnName("minimumProcessingDelay");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.PacketOverhead).HasColumnName("packetOverhead");
            entity.Property(e => e.PfecEnable).HasColumnName("pfecEnable");
            entity.Property(e => e.RouteSearch)
                .HasMaxLength(128)
                .HasColumnName("routeSearch");
            entity.Property(e => e.SourcePort)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("sourcePort");
            entity.Property(e => e.StreamBandwidth)
                .HasColumnType("numeric(20, 0)")
                .HasColumnName("streamBandwidth");
            entity.Property(e => e.StreamEnable).HasColumnName("streamEnable");
            entity.Property(e => e.StreamGain).HasColumnName("streamGain");
            entity.Property(e => e.StreamId)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("streamId");
            entity.Property(e => e.StreamSampleRate).HasColumnName("streamSampleRate");
        });

        modelBuilder.Entity<MRfOutputStream>(entity =>
        {
            entity
                .ToTable("M_RfOutputStream")
                .IsMemoryOptimized();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurrentBuffer).HasColumnName("currentBuffer");
            entity.Property(e => e.DataSampleWidth)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("dataSampleWidth");
            entity.Property(e => e.DataSource)
                .HasMaxLength(128)
                .HasColumnName("dataSource");
            entity.Property(e => e.DesiredBuffer)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("desiredBuffer");
            entity.Property(e => e.DesiredDelay)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("desiredDelay");
            entity.Property(e => e.DestinationPort)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("destinationPort");
            entity.Property(e => e.DroppedPackets)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("droppedPackets");
            entity.Property(e => e.FrequencyOffset).HasColumnName("frequencyOffset");
            entity.Property(e => e.GapCount)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("gapCount");
            entity.Property(e => e.MeasuredDelay)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("measuredDelay");
            entity.Property(e => e.MeasuredNetworkRate)
                .HasColumnType("numeric(20, 0)")
                .HasColumnName("measuredNetworkRate");
            entity.Property(e => e.MeasuredPacketRate)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("measuredPacketRate");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.NetStreamGain).HasColumnName("netStreamGain");
            entity.Property(e => e.NetworkDelay).HasColumnName("networkDelay");
            entity.Property(e => e.PacketOverhead).HasColumnName("packetOverhead");
            entity.Property(e => e.PfecDecoderStatus)
                .HasMaxLength(128)
                .HasColumnName("pfecDecoderStatus");
            entity.Property(e => e.PfecMissingSets)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("pfecMissingSets");
            entity.Property(e => e.PfecRepairedPackets)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("pfecRepairedPackets");
            entity.Property(e => e.PfecTotalPackets)
                .HasColumnType("numeric(20, 0)")
                .HasColumnName("pfecTotalPackets");
            entity.Property(e => e.PfecUnrepairablePackets)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("pfecUnrepairablePackets");
            entity.Property(e => e.PreserveLatency).HasColumnName("preserveLatency");
            entity.Property(e => e.PreserveLatencyLatePackets)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("preserveLatencyLatePackets");
            entity.Property(e => e.PreserveLatencyMaxBurstLoss)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("preserveLatencyMaxBurstLoss");
            entity.Property(e => e.PreserveLatencyMissingPackets)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("preserveLatencyMissingPackets");
            entity.Property(e => e.PreserveLatencyOutOfOrderPackets)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("preserveLatencyOutOfOrderPackets");
            entity.Property(e => e.PreserveLatencyReleaseMargin)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("preserveLatencyReleaseMargin");
            entity.Property(e => e.ReleaseMode)
                .HasMaxLength(128)
                .HasColumnName("releaseMode");
            entity.Property(e => e.SourceHost)
                .HasMaxLength(128)
                .HasColumnName("sourceHost");
            entity.Property(e => e.SourcePort)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("sourcePort");
            entity.Property(e => e.StreamBandwidth).HasColumnName("streamBandwidth");
            entity.Property(e => e.StreamEnable).HasColumnName("streamEnable");
            entity.Property(e => e.StreamId)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("streamId");
            entity.Property(e => e.StreamSampleRate).HasColumnName("streamSampleRate");
            entity.Property(e => e.UnderflowCount)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("underflowCount");
            entity.Property(e => e.UpstreamIrigLocked).HasColumnName("upstreamIrigLocked");
            entity.Property(e => e.UpstreamOnePpsLocked).HasColumnName("upstreamOnePpsLocked");
            entity.Property(e => e.UpstreamPathGain).HasColumnName("upstreamPathGain");
            entity.Property(e => e.UpstreamTenMhzLocked).HasColumnName("upstreamTenMhzLocked");
            entity.Property(e => e.UseLocalReference).HasColumnName("useLocalReference");
        });

        modelBuilder.Entity<MRoute>(entity =>
        {
            entity
                .ToTable("M_Routes")
                .IsMemoryOptimized();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Destination)
                .HasMaxLength(128)
                .HasColumnName("destination");
            entity.Property(e => e.Gateway)
                .HasMaxLength(128)
                .HasColumnName("gateway");
            entity.Property(e => e.Netmask).HasColumnName("netmask");
        });

        modelBuilder.Entity<MSpectrum>(entity =>
        {
            entity
                .ToTable("M_Spectrum")
                .IsMemoryOptimized();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InputRfPort1Spectrum).HasColumnName("inputRfPort1Spectrum");
            entity.Property(e => e.SpectrumType).HasMaxLength(128);
        });

        modelBuilder.Entity<View1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_1");

            entity.Property(e => e.InputRfPort1Spectrum).HasColumnName("inputRfPort1Spectrum");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
