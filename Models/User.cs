using System;
using System.Collections.Generic;

namespace AdminMVC.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string? UserRole { get; set; }

    public string UserEmail { get; set; } = null!;

    public DateOnly? CreatedAt { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
