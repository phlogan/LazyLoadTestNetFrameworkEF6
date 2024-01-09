using System;
using System.Collections.Generic;

namespace LazyLoadTestNetFrameworkEF6.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
    }
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public virtual ICollection<Course> CoursesTaught { get; set; }
    }
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
