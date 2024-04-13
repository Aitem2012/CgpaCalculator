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
            Console.WriteLine($"Your CGPA is {student.CalcCgpa()}");
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

        private decimal GetCourseScorePoint(int score, int unit)
        {
            decimal resultScale = 0;
            if (score >= 75)
            {
                resultScale = 4;
            }
            else if (score >= 70 && score <= 74)
            {
                resultScale = 3.5M;
            }
            else if (score >= 65 && score <= 69)
                resultScale = 3.25M;
            else if (score >= 60 && score <= 64)
            {
                resultScale = 3;
            }
            else if (score >= 55 && score <= 59)
                resultScale = 2.75M;
            else if (score >= 50 && score <= 54)
                resultScale = 2.5M;
            else if (score >= 45 && score <= 49)
            {
                resultScale = 2.25M;
            }
            else if (score >= 40 && score <= 44)
                resultScale = 2;
            else
            {
                resultScale = 0;
            }
            return resultScale * unit;
        }

        private int SumTotalUnit()
        {
            int totalUnit = 0;
            for (int i = 0; i < Courses.Count; i++)
            {
                totalUnit += Courses[i].CourseUnit;
            }
            return totalUnit;
        }

        public decimal CalcCgpa()
        {
            decimal result = 0;
            for (int i = 0; i < Courses.Count; i++)
            {
                result += GetCourseScorePoint(Courses[i].Score, Courses[i].CourseUnit);
            }

            result /= SumTotalUnit();
            return result;
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