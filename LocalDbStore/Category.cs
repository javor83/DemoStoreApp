using System;
using System.Collections.Generic;

namespace RestoreApp.LocalDbStore;

public partial class Category
{
    public int Id { get; set; }

    public string Cname { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
