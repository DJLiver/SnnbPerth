using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnnbFailover.Server.Models.Failover
{
    [Table("Control", Schema = "dbo")]
    public partial class Control
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public bool AutoMode { get; set; }

        [Required]
        public bool AltCommand { get; set; }

    }
}