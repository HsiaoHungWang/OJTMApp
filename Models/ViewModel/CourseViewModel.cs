using System;
using System.Collections.Generic;

namespace OJTMApp.Models.ViewModel;

public partial class CourseViewModel
{
     public int? CategoryId { get; set; }

    public string? CourseName { get; set; }

    public IFormFile? CourseImage { get; set; }

    public int? CoursePrice { get; set; }

    public int? CourseHour { get; set; }

    public string? Description { get; set; }

    public string? Objectives { get; set; }

    public string? Suitable { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public List<string>? DaysOfWeek { get; set; }

    public string? TimePeriods { get; set; }

    public string? Location { get; set; }
   
}
