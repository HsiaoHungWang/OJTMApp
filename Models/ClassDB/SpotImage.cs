using System;
using System.Collections.Generic;

namespace OJTMApp.Models.ClassDB;

public partial class SpotImage
{
    public int ImageId { get; set; }

    public int? SpotId { get; set; }

    public string? ImageTitle { get; set; }

    public string? ImagePath { get; set; }

    public virtual Spot? Spot { get; set; }
}
