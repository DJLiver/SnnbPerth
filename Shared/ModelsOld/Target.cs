using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class Target
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public string Query { get; set; } = null!;

    public bool Enabled { get; set; }

    public int Period { get; set; }

    public string? RemoteUnit { get; set; }

    public string? PeerUnit { get; set; }

    public string? Direction { get; set; }

    public int? DisplayOrder { get; set; }

    public string? Site { get; set; }
}
