using System;
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

        public List<KeyValuePair<int, Course>> missingCoursesY1 { get; set; }
        public List<KeyValuePair<int, Course>> takingCoursesY1 { get; set; }
        public List<KeyValuePair<int, Course>> completedCoursesY1 { get; set; }

        public List<KeyValuePair<int, Course>> missingCoursesY2 { get; set; }
        public List<KeyValuePair<int, Course>> takingCoursesY2 { get; set; }
        public List<KeyValuePair<int, Course>> completedCoursesY2 { get; set; }

        public List<KeyValuePair<int, Course>> missingCoursesY3 { get; set; }
        public List<KeyValuePair<int, Course>> takingCoursesY3 { get; set; }
        public List<KeyValuePair<int, Course>> completedCoursesY3 { get; set; }

        public List<KeyValuePair<int, Course>> missingCoursesY4 { get; set; }
        public List<KeyValuePair<int, Course>> takingCoursesY4 { get; set; }
        public List<KeyValuePair<int, Course>> completedCoursesY4 { get; set; }

        public User()
        {
            missingCoursesY1 = new List<KeyValuePair<int, Course>>();
            takingCoursesY1 = new List<KeyValuePair<int,Course>>();
            completedCoursesY1 = new List<KeyValuePair<int, Course>>();

            missingCoursesY2 = new List<KeyValuePair<int, Course>>();
            takingCoursesY2 = new List<KeyValuePair<int, Course>>();
            completedCoursesY2 = new List<KeyValuePair<int, Course>>();

            missingCoursesY3 = new List<KeyValuePair<int, Course>>();
            takingCoursesY3 = new List<KeyValuePair<int, Course>>();
            completedCoursesY3 = new List<KeyValuePair<int, Course>>();

            missingCoursesY4 = new List<KeyValuePair<int, Course>>();
            takingCoursesY4 = new List<KeyValuePair<int, Course>>();
            completedCoursesY4 = new List<KeyValuePair<int, Course>>();

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
            foreach (var semester in majorProgram.year1) //search through year 1 semeseters 1 and 2
            {
                foreach (var course in semester.Value.courseList) //search through semesters courses
                {
                    if (course.missing == true && semester.Key == 1)
                    {
                        missingCoursesY1.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if (course.missing == true && semester.Key == 2)
                    {
                        missingCoursesY1.Add(new KeyValuePair<int, Course>(2, course));
                    }
                }
            }

            foreach (var semester in majorProgram.year2)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.missing == true && semester.Key == 1)
                    {
                        missingCoursesY2.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if (course.missing == true && semester.Key == 2)
                    {
                        missingCoursesY2.Add(new KeyValuePair<int, Course>(2, course));
                    }
                }
            }

            foreach (var semester in majorProgram.year3)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.missing == true && semester.Key == 1)
                    {
                        missingCoursesY3.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if (course.missing == true && semester.Key == 2)
                    {
                        missingCoursesY3.Add(new KeyValuePair<int, Course>(2, course));
                    }
                }
            }

            foreach (var semester in majorProgram.year4)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.missing == true && semester.Key == 1)
                    {
                        missingCoursesY4.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if (course.missing == true && semester.Key == 2)
                    {
                        missingCoursesY4.Add(new KeyValuePair<int, Course>(2, course));
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
                    if (course.taking == true && semester.Key == 1)
                    {
                        takingCoursesY1.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if(course.taking == true && semester.Key == 2)
                    {
                        takingCoursesY1.Add(new KeyValuePair<int, Course>(2, course));
                    }   
                }
            }

            foreach (var semester in majorProgram.year2)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.taking == true && semester.Key == 1)
                    {
                        takingCoursesY2.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if (course.taking == true && semester.Key == 2)
                    {
                        takingCoursesY2.Add(new KeyValuePair<int, Course>(2, course));
                    }
                }
            }

            foreach (var semester in majorProgram.year3)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.taking == true && semester.Key == 1)
                    {
                        takingCoursesY3.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if (course.taking == true && semester.Key == 2)
                    {
                        takingCoursesY3.Add(new KeyValuePair<int, Course>(2, course));
                    }
                }
            }

            foreach (var semester in majorProgram.year4)
            {
                foreach (var course in semester.Value.courseList)
                {
                    if (course.taking == true && semester.Key == 1)
                    {
                        takingCoursesY4.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if (course.taking == true && semester.Key == 2)
                    {
                        takingCoursesY4.Add(new KeyValuePair<int, Course>(2, course));
                    }
                }
            }
        }

        public void populateCompleted()
        {
            foreach (var semester in majorProgram.year1) //search through year 1 semesters 1 and 2
            {
                foreach (var course in semester.Value.courseList) //search through semesters courses 
                {
                    if(course.completed == true && semester.Key == 1)
                    {
                        completedCoursesY1.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if(course.completed == true && semester.Key == 2)
                    {
                        completedCoursesY1.Add(new KeyValuePair<int, Course>(2, course));
                    }
                }
            }

            foreach (var semester in majorProgram.year2) //search through year 2 semesters 1 and 2
            {
                foreach (var course in semester.Value.courseList) //search through semesters 
                {
                    if (course.completed == true && semester.Key == 1)
                    {
                        completedCoursesY2.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if (course.completed == true && semester.Key == 2)
                    {
                        completedCoursesY2.Add(new KeyValuePair<int, Course>(2, course));
                    }
                }
            }

            foreach (var semester in majorProgram.year3) //search through year 3 semesters 1 and 2
            {
                foreach (var course in semester.Value.courseList) //search through semesters 
                {
                    if (course.completed == true && semester.Key == 1)
                    {
                        completedCoursesY3.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if (course.completed == true && semester.Key == 2)
                    {
                        completedCoursesY3.Add(new KeyValuePair<int, Course>(2, course));
                    }
                }
            }

            foreach (var semester in majorProgram.year4) //search through year 4 semesters 1 and 2
            {
                foreach (var course in semester.Value.courseList) //search through semesters 
                {
                    if (course.completed == true && semester.Key == 1)
                    {
                        completedCoursesY4.Add(new KeyValuePair<int, Course>(1, course));
                    }
                    else if (course.completed == true && semester.Key == 2)
                    {
                        completedCoursesY4.Add(new KeyValuePair<int, Course>(2, course));
                    }
                }
            }
        }

        public void enroll(int semesterNum, Course course)
        {

            switch (semesterNum)
            {
                case 1:
                    takingCoursesY1.Add(new KeyValuePair<int, Course>(1, course));
                    return;
                case 2:
                    takingCoursesY1.Add(new KeyValuePair<int, Course>(2, course));
                    return;
                case 3:
                    takingCoursesY2.Add(new KeyValuePair<int, Course>(1, course));
                    return;
                case 4:
                    takingCoursesY2.Add(new KeyValuePair<int, Course>(2, course));
                    return;
                case 5:
                    takingCoursesY3.Add(new KeyValuePair<int, Course>(1, course));
                    return;
                case 6:
                    takingCoursesY3.Add(new KeyValuePair<int, Course>(2, course));
                    return;
                case 7:
                    takingCoursesY4.Add(new KeyValuePair<int, Course>(1, course));
                    return;
                case 8:
                    takingCoursesY4.Add(new KeyValuePair<int, Course>(2, course));
                    return;

            }

        }

        public void drop(Course drop)
        {

        }
    }
}
