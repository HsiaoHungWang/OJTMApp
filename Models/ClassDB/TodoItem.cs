using System;
using System.Collections.Generic;

namespace OJTMApp.Models.ClassDB;

public partial class TodoItem
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Priority { get; set; }

    public bool? IsDone { get; set; }
}
