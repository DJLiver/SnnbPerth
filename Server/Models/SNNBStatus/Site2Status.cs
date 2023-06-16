using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnnbFailover.Server.Models.SNNBStatus
{
    [Table("Site2Status", Schema = "dbo")]
    public partial class Site2Status
    {
        [Column(TypeName="datetime2")]
        public DateTime? DateStamp { get; set; }

        public string Source { get; set; }

        public bool? CommOk { get; set; }

        [Column("RfOut Enable")]
        public bool? RfOutEnable { get; set; }

        [Column("Measured delay")]
        public double? Measureddelay { get; set; }

        [Column("RFout NetIn")]
        public double? RFoutNetIn { get; set; }

        public bool? RFinstreamEnable { get; set; }

        [Column("RFin Netout")]
        public double? RFinNetout { get; set; }

        [Required]
        public string IpAddress { get; set; }

        public string RemoteUnit { get; set; }

        public string PeerUnit { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public string Site { get; set; }

    }
}