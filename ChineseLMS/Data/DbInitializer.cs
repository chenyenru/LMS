using ChineseLMS.Models;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ChineseLMS.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }


            var rebecca = new Student
            {
                FirstMidName = "Rebecca",
                LastName = "Chen",
                EnrollmentDate = DateTime.Parse("2017-09-01"),
                ClassOf = 2023
            };

            var megan = new Student
            {
                FirstMidName = "Megan",
                LastName = "Liao",
                EnrollmentDate = DateTime.Parse("2017-09-01"),
                ClassOf = 2023
            };

            var anezka = new Student
            {
                FirstMidName = "Anezka",
                LastName = "Chang",
                EnrollmentDate = DateTime.Parse("2017-09-01"),
                ClassOf = 2023
            };

            var nicole = new Student
            {
                FirstMidName = "Nicole",
                LastName = "Wu",
                EnrollmentDate = DateTime.Parse("2017-09-01"),
                ClassOf = 2023
            };

            var aaron = new Student
            {
                FirstMidName = "Aaron",
                LastName = "Wang",
                EnrollmentDate = DateTime.Parse("2017-09-01"),
                ClassOf = 2023
            };


            var preston = new Student
            {
                FirstMidName = "Preston",
                LastName = "Gu",
                EnrollmentDate = DateTime.Parse("2017-09-01"),
                ClassOf = 2023
            };

            var enen = new Student
            {
                FirstMidName = "Enen",
                LastName = "Tai",
                EnrollmentDate = DateTime.Parse("2021-09-01"),
                ClassOf = 2023
            };

            var sean = new Student
            {
                FirstMidName = "Sean",
                LastName = "Ho",
                EnrollmentDate = DateTime.Parse("2020-09-01"),
                ClassOf = 2023
            };

            var larry = new Instructor
            {
                FirstMidName = "Larry",
                LastName = "Allen",
                HireDate = DateTime.Parse("2020-08-01")
            };

            var abdul = new Instructor
            {
                FirstMidName = "Abdul",
                LastName = "Shabbir",
                HireDate = DateTime.Parse("2019-08-01")
            };

            var blythe = new Instructor
            {
                FirstMidName = "Blythe",
                LastName = "lin",
                HireDate = DateTime.Parse("2016-08-01")
            };

            var andy = new Instructor
            {
                FirstMidName = "Andy",
                LastName = "Chen",
                HireDate = DateTime.Parse("2019-08-01")
            };

            var brent = new Instructor
            {
                FirstMidName = "Brent",
                LastName = "Parker",
                HireDate = DateTime.Parse("2012-08-01")
            };

            var jared = new Instructor
            {
                FirstMidName = "Jared",
                LastName = "Westin",
                HireDate = DateTime.Parse("2016-08-01")
            };

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    Instructor = brent,
                    Location = "7-2 Classroom" },
                new OfficeAssignment {
                    Instructor = larry,
                    Location = "7F Teacher Office" },
                new OfficeAssignment {
                    Instructor = jared,
                    Location = "8F Teacher Office or 6F Literature CLassroom. Come at your own risk" },
            };

            context.AddRange(officeAssignments);

            var english = new Department
            {
                Name = "English",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = jared
            };
            context.AddRange(english);


            var mathematics = new Department
            {
                Name = "Mathematics",
                Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = abdul
            };
            context.AddRange(mathematics);


            var glopol = new Department
            {
                Name = "Global Politics",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = larry,
            };
            context.AddRange(glopol);


            var english2023 = new Course
            {
                CourseID = 1050,
                Title = "English HL/SL",
                Credits = 3,
                Department = english,
                Instructors = new List<Instructor> { jared }
            };
            context.AddRange(english2023);


            var english2024 = new Course
            {
                CourseID = 1051,
                Title = "English HL",
                Credits = 3,
                Department = english,
                Instructors = new List<Instructor> { jared }
            };
            context.AddRange(english2024);

            var glopol2023 = new Course
            {
                CourseID = 1051,
                Title = "Global Politics HL Class of 2023",
                Credits = 3,
                Department = glopol,
                Instructors = new List<Instructor> { larry }
            };
            context.AddRange(english2024);

            var calculus = new Course
            {
                CourseID = 1045,
                Title = "Calculus",
                Credits = 4,
                Department = mathematics,
                Instructors = new List<Instructor> { abdul, brent }
            };
            context.AddRange(calculus);


            var trigonometry = new Course
            {
                CourseID = 3141,
                Title = "Trigonometry",
                Credits = 4,
                Department = mathematics,
                Instructors = new List<Instructor> { abdul, brent }
            };
            context.AddRange(trigonometry);


            var composition = new Course
            {
                CourseID = 2021,
                Title = "English Composition",
                Credits = 3,
                Department = english,
                Instructors = new List<Instructor> { jared }
            };
            context.AddRange(composition);


            var en_literature = new Course
            {
                CourseID = 2042,
                Title = "English Literature",
                Credits = 4,
                Department = english,
                Instructors = new List<Instructor> { jared }
            };


            var zh_literature = new Course
            {
                CourseID = 2042,
                Title = "Literature",
                Credits = 4,
                Department = english,
                Instructors = new List<Instructor> { blythe }
            };

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    Student = rebecca,
                    Course = english2023,
                    Grade = Grade.A
                },
                    new Enrollment {
                    Student = aaron,
                    Course = calculus,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    Student = preston,
                    Course = zh_literature,
                    Grade = Grade.A
                    },
                    new Enrollment {
                    Student = anezka,
                    Course = calculus,
                    Grade = Grade.A
                    },
                    new Enrollment {
                        Student = nicole,
                    Course = trigonometry,
                    Grade = Grade.A
                    },
                    new Enrollment {
                    Student = megan,
                    Course = composition,
                    Grade = Grade.A
                    },
            };
            context.AddRange(enrollments);


            // Serializing
            
            var task1 = new SchoolAssignment
            {
                CourseID = 2042,
                Title = "Biology Summative Paper 3",
                SchoolAssignmentDetails = "LOL I'm not actually going to test you on this. Be prepare to be tested on all topics",
                TaskCreateDate = DateTime.Parse("2022-11-01"),
                TaskDueStartTime = DateTime.Parse("2022-12-01 22:10"),
                TaskDueEndTime = DateTime.Parse("2022-12-01 22:20"),

            };
            

            var task2 = new SchoolAssignment
            {
                CourseID = 2042,
                Title = "Biology Summative Paper 2",
                SchoolAssignmentDetails = "Be prepare to be tested on Topic 1, 2, 6",
                TaskCreateDate = DateTime.Parse("2022-11-01"),
                TaskDueStartTime = DateTime.Parse("2022-12-01 21:10"),
                TaskDueEndTime = DateTime.Parse("2022-12-01 21:20")
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            task1.JSONString = JsonSerializer.Serialize<SchoolAssignment>(
                task1,
                options);
            task2.JSONString = JsonSerializer.Serialize<SchoolAssignment>(
                task2,
                options);

            var tasks = new SchoolAssignment[]
            {
                task1,
                task2
            };
            context.AddRange(tasks);


            var messages = new CourseMessage[]
            {
                new CourseMessage
                {
                    CourseID  = 2042,
                    InstructorID = 5,
                    MessageTitle = "Submit your assignment on time!",
                    MessageContent = "After you submitted the internal assessment, we will be starting the next unit! There's no time to waste.",
                    MessageCreateDate = DateTime.Parse("2022-11-01"),
                    MessageEditDate = DateTime.Parse("2022-11-03")
                },
                new CourseMessage
                {
                    CourseID  = 2042,
                    InstructorID = 5,
                    MessageTitle = "Some notes regarding to the Maclaurin Series",
                    MessageContent = "I'd love to talk about our latest design.",
                    MessageCreateDate = DateTime.Parse("2022-11-01"),
                    MessageEditDate = DateTime.Parse("2022-11-03")
                }
            };
            context.AddRange(messages);


            //var todos = new Todo
            //{
            //    TodoName = "Do Research",
            //    TodoDueDate = DateTime.Parse("2022-11-01"),
            //    ConnectedToSchoolAssignment = true,
            //    Checked = true,
            //    ByTeacher = true
            //};

            //context.AddRange(todos);

            context.SaveChanges();
        }
    }
}