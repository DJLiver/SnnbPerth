﻿using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.newModels;

public partial class MDependency
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string? Dependant { get; set; }
}
