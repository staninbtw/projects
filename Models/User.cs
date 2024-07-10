using System;
using System.Collections.Generic;

namespace Bank.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Mail { get; set; }

    public string? Password { get; set; }

    public int? Role { get; set; }

    public virtual ICollection<Card> Cards { get; } = new List<Card>();

    public virtual ICollection<Check> Checks { get; } = new List<Check>();

    public virtual Role? RoleNavigation { get; set; }
}
