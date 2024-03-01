using System;
using System.Collections.Generic;

namespace APIDeveloperPortal.Client.Models;

public partial class UsersProductsBridge
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
