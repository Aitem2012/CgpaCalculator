using System;
using System.Collections.Generic;

namespace CgpaCalculator
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Student student = new Student
            {
                FirstName = "Ibrahim",
                LastName = "Temitope",
                MatricNumber = "26764367"
            };

            student.GetCourses();
            Console.WriteLine($"The student has registered {student.GetStudentRegisteredCourses()} courses");
        }
    }

    public abstract class BaseClass
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }

    public class Student : BaseClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MatricNumber { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

        public void GetCourses()
        {
            Console.WriteLine("How many courses are you offering? ");
            string courses = Console.ReadLine();
            int coursesCount = int.Parse(courses);

            for (int i = 0; i < coursesCount; i++)
            {
                Console.WriteLine($"Enter course {i + 1} code: ");
                string courseCode = Console.ReadLine();
                Console.WriteLine($"Enter course {i + 1} unit: ");
                string courseUnit = Console.ReadLine();
                Console.WriteLine($"Enter course {i + 1} score");
                string score = Console.ReadLine();

                Courses.Add(new Course
                {
                    Id = Guid.NewGuid(),
                    CourseCode = courseCode,
                    CourseUnit = int.Parse(courseUnit),
                    Score = int.Parse(score)
                });
            }
        }

        public int GetStudentRegisteredCourses()
        {
            int registeredCourses = Courses.Count;
            return registeredCourses;
        }
    }

    public class Course : BaseClass
    {
        public string CourseCode { get; set; }
        public int CourseUnit { get; set; }
        public int Score { get; set; }
    }

    public class Result : BaseClass
    {
        public int Score { get; set; }
        public string Grade { get; set; }
    }
}