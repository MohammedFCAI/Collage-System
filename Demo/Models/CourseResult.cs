namespace Demo.Models
{
    public class CourseResult
    {

        public int CourseId { get; set; }

        public int TraineeId { get; set; }

        public Course Course { get; set; } = default!;

        public Trainee Trainee { get; set; } = default!;

        public int Degree { get; set; }
    }
}
