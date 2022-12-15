using System;
using System.Collections.Generic;

namespace ClassLibraryEntity.Models.Accounting;

public class UserPerson
{
    public int IdUser { get; set; }

    public string? NameUser { get; set; }

    public string? CorreoUser { get; set; }

    public string? TelephoneUser { get; set; }

    public int? IdRol { get; set; }

    public string? Clave { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateRegistro { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
