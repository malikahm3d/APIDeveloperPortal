using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIDeveloperPortal.API.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    public string? ProductName { get; set; }








    public virtual List<ProductService> ProductServices { get; set; } = new List<ProductService>();













    public virtual ICollection<UsersProductsBridge> UsersProductsBridges { get; set; } = new List<UsersProductsBridge>();
}
