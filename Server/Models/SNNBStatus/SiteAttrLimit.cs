using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnnbFailover.Server.Models.SNNBStatus
{
    [Table("SiteAttrLimits", Schema = "dbo")]
    public partial class SiteAttrLimit
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Attr { get; set; }

        [Required]
        public double Lower { get; set; }

        [Required]
        public double Upper { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public bool InRange { get; set; }

    }
}