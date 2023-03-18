using System;
using System.Collections.Generic;

namespace ConsoleApp2.Models;

public partial class Usertable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public int? AddressId { get; set; }

    public string Email { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public virtual Address? Address { get; set; }
}
