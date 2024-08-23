namespace Demo.Models
{
    public class Instructor : BaseEntity
    {
        public string imageUrl { get; set; } = string.Empty;

        public int Grade { get; set; }



        // 1 Course With M Instructor
        public int CourseId { get; set; }

        public Course Course { get; set; } = default!;



        // M Instractor With 1 Department
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = default!;

    }
}
