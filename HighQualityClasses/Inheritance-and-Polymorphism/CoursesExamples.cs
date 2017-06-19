using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases",
                                                      "Svetlin Nakov",
                                                      "Enterprise");
            Console.WriteLine(localCourse);

            LocalCourse otherLocalCourse = new LocalCourse("Databases",
                                                           "Svetlin Nakov",
                                                           "Enterprise",
                                                           new List<string>() { "Peter", "Maria" });
            Console.WriteLine(otherLocalCourse);

            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse);

            otherLocalCourse.Students.Add("Milena");
            otherLocalCourse.Students.Add("Todor");
            Console.WriteLine(otherLocalCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse("PHP and WordPress Development",
                                                            "Mario Peshev",
                                                            "Sofia");
            Console.WriteLine(offsiteCourse);
            offsiteCourse.Students.Add("Pesho");
            offsiteCourse.Students.Add("Gosho");
            Console.WriteLine(offsiteCourse);

            OffsiteCourse otherOffsiteCourse = new OffsiteCourse("PHP and WordPress Development",
                                                                 "Mario Peshev",
                                                                 "Vratsa",
                                                                 new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(otherOffsiteCourse);
            otherOffsiteCourse.Students.Add("Damian");
            otherOffsiteCourse.Students.Add("Zhana");
            Console.WriteLine(otherOffsiteCourse);

            List<Course> courses = new List<Course>() { localCourse, offsiteCourse, otherLocalCourse, otherOffsiteCourse };
            foreach (var course in courses)
            {
                Console.WriteLine(course);
            }
        }
    }
}
