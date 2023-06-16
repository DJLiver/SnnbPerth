using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnnbFailover.Server.Models.Failover
{
    [Table("EventLog", Schema = "dbo")]
    public partial class EventLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName="datetime2")]
        [Required]
        public DateTime DateStamp { get; set; }

        [Required]
        public string System { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public string Message { get; set; }

    }
}