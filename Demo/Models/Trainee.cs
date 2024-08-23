namespace Demo.Models
{
    public class Trainee : BaseEntity
    {
        public string ImageUrl { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int Grade { get; set; }


        // M Courses With M Trainee
        public ICollection<CourseResult> CourseResults { get; set; } = new List<CourseResult>();


        // M Trainee With 1 Department
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = default!;
    }
}
