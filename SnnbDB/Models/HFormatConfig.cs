using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class HFormatConfig
{
    public string? Table { get; set; }

    public string? Attribute { get; set; }

    public string? Access { get; set; }

    public string? Normal { get; set; }

    public string? Scale { get; set; }

    public string? Format { get; set; }

    public string? Units { get; set; }

    public string? Help { get; set; }
}
