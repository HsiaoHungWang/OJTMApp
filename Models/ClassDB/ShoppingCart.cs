using System;
using System.Collections.Generic;

namespace OJTMApp.Models.ClassDB;

public partial class ShoppingCart
{
    public int RecordId { get; set; }

    public string? CartId { get; set; }

    public int Quantity { get; set; }

    public int CourseId { get; set; }

    public DateTime DateCreated { get; set; }
}
