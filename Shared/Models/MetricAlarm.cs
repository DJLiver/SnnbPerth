using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class MetricAlarm
{
    public int Id { get; set; }

    public DateTime DateStamp { get; set; }

    public string Target { get; set; } = null!;

    public string Attribute { get; set; } = null!;

    public string Message { get; set; } = null!;

    public bool Status { get; set; }
}
