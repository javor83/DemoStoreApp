using System;
using System.Collections.Generic;

namespace DemoStoreApp.db;

public partial class Product
{
    public int Id { get; set; }

    public string Pname { get; set; } = null!;

    public string Pdesc { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Pcategory { get; set; }

    public virtual Category? PcategoryNavigation { get; set; }
}
