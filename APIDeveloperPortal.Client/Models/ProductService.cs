using System;
using System.Collections.Generic;

namespace APIDeveloperPortal.Client.Models;

public partial class ProductService
{
    public int Id { get; set; }

    public string? FunctionName { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
