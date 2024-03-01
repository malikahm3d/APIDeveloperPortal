using System;
using System.Collections.Generic;

namespace APIDeveloperPortal.API.Models;

public partial class Product
{
    public int Id { get; }

    public string? ProductName { get; set; }

    public virtual ICollection<ProductService> ProductServices { get; set; } = new List<ProductService>();

    public virtual ICollection<UsersProductsBridge> UsersProductsBridges { get; set; } = new List<UsersProductsBridge>();
}
