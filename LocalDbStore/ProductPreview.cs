using System;
using System.Collections.Generic;

namespace RestoreApp.LocalDbStore;

public partial class ProductPreview
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string Preview { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
