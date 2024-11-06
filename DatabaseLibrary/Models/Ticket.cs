using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class Ticket
{
    public int IdTicket { get; set; }

    public int IdSession { get; set; }

    public int IdVisitor { get; set; }

    public byte Row { get; set; }

    public byte? Place { get; set; }

    public virtual Visitor IdVisitorNavigation { get; set; } = null!;
}
