using System;
using System.Collections.Generic;

namespace ClassLibraryEntity.Models.Accounting;

public partial class Person
{
    public int IdPerson { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public bool? Status { get; set; }
}
