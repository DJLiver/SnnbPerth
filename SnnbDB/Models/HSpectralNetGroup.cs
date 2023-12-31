﻿using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class HSpectralNetGroup
{
    public int Id { get; set; }

    public int ClusterId { get; set; }

    public string ClusterName { get; set; } = null!;

    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public string Site { get; set; } = null!;

    public int UnitId { get; set; }

    public string UnitName { get; set; } = null!;

    public string RemoteUnit { get; set; } = null!;

    public string PeerUnit { get; set; } = null!;

    public string ChassisName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public string NetworkPath { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public int Timeout { get; set; }

    public bool Enabled { get; set; }
}
