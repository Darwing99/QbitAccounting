using System;
using System.Collections.Generic;

namespace ClassLibraryEntity.Models.Accounting;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateRegistration { get; set; }

    public virtual ICollection<RolMenu> RolMenus { get; } = new List<RolMenu>();

    public virtual ICollection<UserPerson> UserPeople { get; } = new List<UserPerson>();
}
