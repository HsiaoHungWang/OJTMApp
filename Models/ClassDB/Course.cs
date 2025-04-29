using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTMApp.Models.ClassDB;

public partial class Course
{
    [Display(Name ="課程編號")]
    public int CourseId { get; set; }

    public int? CategoryId { get; set; }

    [Display(Name = "課程名稱")]
    public string? CourseName { get; set; }

    public string? CourseImage { get; set; }  //IFormFile

    public int? CoursePrice { get; set; }

    public int? CourseHour { get; set; }

    public string? Description { get; set; }

    public string? Objectives { get; set; }

    public string? Suitable { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? DaysOfWeek { get; set; }  //List<string>

    public string? TimePeriods { get; set; }

    public string? Location { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
