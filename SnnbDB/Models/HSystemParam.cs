﻿using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class HSystemParam
{
    public int Id { get; set; }

    public string PreIpAddress { get; set; } = null!;

    public string RestQuery { get; set; } = null!;

    public int PollPeriod { get; set; }

    public int Timeout { get; set; }

    public bool Verbose { get; set; }

    public bool AutoOn { get; set; }

    public bool SwitchAll { get; set; }

    public int SwitchDelay { get; set; }

    public bool OnAPath { get; set; }
}
