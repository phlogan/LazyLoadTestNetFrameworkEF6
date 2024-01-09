namespace LazyLoadTestNetFrameworkEFCore.ViewModels
{
    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }
        public ICollection<CourseViewModel> Courses { get; set; }
    }
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int SchoolId { get; set; }
        public SchoolViewModel School { get; set; }

        public ICollection<EnrollmentViewModel> Enrollments { get; set; }
    }
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

        public int SchoolId { get; set; }
        public SchoolViewModel School { get; set; }

        public int TeacherId { get; set; }
        public TeacherViewModel Teacher { get; set; }

        public ICollection<EnrollmentViewModel> Enrollments { get; set; }
    }
    public class EnrollmentViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public StudentViewModel Student { get; set; }

        public int CourseId { get; set; }
        public CourseViewModel Course { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int GradeId { get; set; }
        public GradeViewModel Grade { get; set; }
    }
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public int SchoolId { get; set; }
        public SchoolViewModel School { get; set; }

        public ICollection<CourseViewModel> CoursesTaught { get; set; }
    }
    public class GradeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EnrollmentViewModel> Enrollments { get; set; }

    }
}
