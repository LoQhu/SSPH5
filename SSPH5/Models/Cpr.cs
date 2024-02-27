using System;
using System.Collections.Generic;

namespace SSPH5.Models;

public partial class Cpr
{
    public int Id { get; set; }

    public string User { get; set; } = null!;

    public string Cpr1 { get; set; } = null!;

    public string? Salt { get; set; }

    public string Hash { get; set; } = null!;
}
