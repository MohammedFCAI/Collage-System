namespace Demo.Models
{
    public class Department : BaseEntity
    {
        public string ManagerName { get; set; } = string.Empty;


        // 1 Department With Many Instructor

        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();


        // 1 Department With M Courses
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();



        // 1 Department With Many Trainee
        public ICollection<Trainee> Trainees { get; set; } = new HashSet<Trainee>();
    }
}
