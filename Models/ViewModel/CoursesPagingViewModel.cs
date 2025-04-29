using OJTMApp.Models.ClassDB;

namespace OJTMApp.Models.ViewModel
{
    public class CoursesPagingViewModel
    {
        public int TotalPage { get; set; }
        public required List<Course> Courses { get; set; }
    }
}
