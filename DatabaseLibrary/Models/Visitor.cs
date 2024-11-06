using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class Visitor
{
    public int IdVisitor { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
