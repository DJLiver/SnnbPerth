﻿using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class HSpecNetGroup
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public string Site { get; set; } = null!;

    public int UnitId { get; set; }

    public string UnitName { get; set; } = null!;

    public string ChassisName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string PreIpAddress { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public string RestQuery { get; set; } = null!;

    public string Direction { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public bool Enabled { get; set; }
}
