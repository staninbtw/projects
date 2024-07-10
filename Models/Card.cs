using System;
using System.Collections.Generic;

namespace Bank.Models;

public partial class Card
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Number { get; set; }

    public int? Money { get; set; }

    public string? Validity { get; set; }

    public int? Cardowner { get; set; }

    public DateTime? Term { get; set; }

    public int? Cvc { get; set; }

    public byte[]? Picture { get; set; }

    public virtual User? CardownerNavigation { get; set; }
}
