﻿using System;
using System.Collections.Generic;

namespace OJTMApp.Models.ClassDB;

public partial class SpotsCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Spot> Spots { get; set; } = new List<Spot>();
}
