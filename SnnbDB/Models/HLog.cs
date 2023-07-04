﻿using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class HLog
{
    public int Id { get; set; }

    public DateTime DateStamp { get; set; }

    public string Application { get; set; } = null!;

    public string MemberName { get; set; } = null!;

    public int LineNumber { get; set; }

    public string Message { get; set; } = null!;

    public string Additional { get; set; } = null!;
}
