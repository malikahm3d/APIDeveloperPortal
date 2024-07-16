using System;
using System.Collections.Generic;

namespace APIDeveloperPortal.API.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }


    public string FullName { get; set; }











    public virtual ICollection<UsersProductsBridge> UsersProductsBridges { get; set; } = new List<UsersProductsBridge>();
}
