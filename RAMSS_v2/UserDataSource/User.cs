﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMSS_v2.UserDataSource
{
    public class User
    {
        public String name { get; set; }
        public int year { get; set; }
        public String address { get; set; }
        public String email { get; set; }
        public String phoneNumber { get; set; }
        public String emergencyContactName { get; set; }
        public String emergencyContactPhoneNumber { get; set; }

        public Major majorProgram { get; set; }
        public Major minorProgram { get; set; }

        public List<Course> missingCoursesY1 { get; set; }
        public List<Course> takingCoursesY1 { get; set; }
        public List<Course> completedCoursesY1 { get; set; }

        public List<Course> missingCoursesY2 { get; set; }
        public List<Course> takingCoursesY2 { get; set; }
        public List<Course> completedCoursesY2 { get; set; }

        public List<Course> missingCoursesY3 { get; set; }
        public List<Course> takingCoursesY3 { get; set; }
        public List<Course> completedCoursesY3 { get; set; }

        public List<Course> missingCoursesY4 { get; set; }
        public List<Course> takingCoursesY4 { get; set; }
        public List<Course> completedCoursesY4 { get; set; }

        public User()
        {
            missingCoursesY1 = new List<Course>();
            takingCoursesY1 = new List<Course>();
            completedCoursesY1 = new List<Course>();

            missingCoursesY2 = new List<Course>();
            takingCoursesY2 = new List<Course>();
            completedCoursesY2 = new List<Course>();

            missingCoursesY3 = new List<Course>();
            takingCoursesY3 = new List<Course>();
            completedCoursesY3 = new List<Course>();

            missingCoursesY4 = new List<Course>();
            takingCoursesY4 = new List<Course>();
            completedCoursesY4 = new List<Course>();

            name = "Violet Alessia Martins";
            year = 3;
            address = "133 Woodward Ave. Apt. 10 Toronto, Ontario";
            email = "V_allesia@ryerson.ca";
            phoneNumber = "(647)-789-1483";
            emergencyContactName = "John Cara";
            emergencyContactPhoneNumber = "(416)-159-0189";

            majorProgram = new Major();

            populateMissing();
            populateTaking();
            populateCompleted();
        }

        public void populateMissing()
        {
            foreach (var semester in majorProgram.year1)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.missing == true)
                    {
                        missingCoursesY1.Add(course);
                    }
                }
            }

            foreach (var semester in majorProgram.year2)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.missing == true)
                    {
                        missingCoursesY2.Add(course);
                    }
                }
            }

            foreach (var semester in majorProgram.year3)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.missing == true)
                    {
                        missingCoursesY3.Add(course);
                    }
                }
            }

            foreach (var semester in majorProgram.year4)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.missing == true)
                    {
                        missingCoursesY4.Add(course);
                    }
                }
            }
        }

        public void populateTaking()
        {
            foreach (var semester in majorProgram.year1)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.taking == true)
                    {
                        takingCoursesY1.Add(course);
                    }
                }
            }

            foreach (var semester in majorProgram.year2)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.taking == true)
                    {
                        takingCoursesY2.Add(course);
                    }
                }
            }

            foreach (var semester in majorProgram.year3)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.taking == true)
                    {
                        takingCoursesY3.Add(course);
                    }
                }
            }

            foreach (var semester in majorProgram.year4)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.taking == true)
                    {
                        takingCoursesY4.Add(course);
                    }
                }
            }
        }

        public void populateCompleted()
        {
            foreach (var semester in majorProgram.year1)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.completed == true)
                    {
                        completedCoursesY1.Add(course);
                    }
                }
            }

            foreach (var semester in majorProgram.year2)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.completed == true)
                    {
                        completedCoursesY2.Add(course);
                    }
                }
            }

            foreach (var semester in majorProgram.year3)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.completed == true)
                    {
                        completedCoursesY3.Add(course);
                    }
                }
            }

            foreach (var semester in majorProgram.year4)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.completed == true)
                    {
                        completedCoursesY4.Add(course);
                    }
                }
            }
        }

        public void enroll(Course enroll)
        {
            
        }

        public void drop(Course drop)
        {

        }
    }
}
