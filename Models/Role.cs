﻿using System;
using System.Collections.Generic;

namespace Bank.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Role1 { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
