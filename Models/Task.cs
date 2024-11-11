using System;
using System.Collections.Generic;

namespace AdminMVC.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public double? EstimatedTime { get; set; }

    public double? ActualTime { get; set; }

    public string? TaskState { get; set; }

    public DateOnly? CreationDate { get; set; }

    public int? UserId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User? User { get; set; }
}
