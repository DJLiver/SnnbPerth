using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class FormatConfig
{
    public int Id { get; set; }

    public string? Attr { get; set; }

    public string? Normal { get; set; }

    public string? Format { get; set; }

    public int? Scale { get; set; }

    public string? Units { get; set; }
}
