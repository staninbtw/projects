using System;
using System.Collections.Generic;

namespace Bank.Models;

public partial class Check
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? Credit { get; set; }

    public virtual User? User { get; set; }
}
