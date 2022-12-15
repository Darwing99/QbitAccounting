using System;
using System.Collections.Generic;

namespace ClassLibraryEntity.Models.Accounting;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? DescriptionMenu { get; set; }

    public int? IdMenuFather { get; set; }

    public string? Icono { get; set; }

    public string? Controller { get; set; }

    public string? PageAction { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateRegistration { get; set; }

    public virtual Menu? IdMenuFatherNavigation { get; set; }

    public virtual ICollection<Menu> InverseIdMenuFatherNavigation { get; } = new List<Menu>();

    public virtual ICollection<RolMenu> RolMenus { get; } = new List<RolMenu>();
}
