namespace Demo.Models
{
    public class Course : BaseEntity
    {
        public int Degree { get; set; }

        public int MinDegree { get; set; }


        // 1 Course With M Instructors
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();



        // M Course With M Trainee
        public ICollection<CourseResult> CourseResults { get; set; } = new List<CourseResult>();


        // 1 Department With M Courses
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = default!;
    }
}
