﻿using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class MMulticastGroupSubscription
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string? Dependant { get; set; }
}