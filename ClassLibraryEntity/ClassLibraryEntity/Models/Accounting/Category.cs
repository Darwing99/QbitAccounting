using System;
using System.Collections.Generic;

namespace ClassLibraryEntity.Models.Accounting;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? DescriptionCategory { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateRegistration { get; set; }
}
