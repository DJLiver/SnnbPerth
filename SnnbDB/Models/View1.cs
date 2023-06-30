using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class View1
{
    public int UnitId { get; set; }

    public string UnitName { get; set; } = null!;

    public int GroupId { get; set; }

    public DateTime DateStamp { get; set; }

    public string GroupName { get; set; } = null!;

    public string Site { get; set; } = null!;

    public string ChassisName { get; set; } = null!;

    public string SourceIpAddress { get; set; } = null!;

    public string SourcePort { get; set; } = null!;

    public decimal StreamId { get; set; }

    public double CenterFrequency { get; set; }
}
