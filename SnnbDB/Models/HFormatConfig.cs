using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class HFormatConfig
{
    public int Id { get; set; }

    public string? Table { get; set; }

    public string? Attribute { get; set; }

    public string? Access { get; set; }

    public string? Normal { get; set; }

    public int? Scale { get; set; }

    public string? Format { get; set; }

    public string? Units { get; set; }

    public string? Help { get; set; }
}
