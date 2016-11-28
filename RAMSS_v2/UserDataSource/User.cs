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

        public Major majorProgram;
        public Minor minorProgram;

        List<Course> missingCourses = new List<Course>();
        List<Course> takingCourses = new List<Course>();
        List<Course> completedCourses = new List<Course>();

        public User()
        {
            name = "Violet Alessia Martins";
            year = 3;
            address = "133 Woodward Ave. Apt. 10 Toronto, Ontario";
            email = "V_allesia@ryerson.ca";
            phoneNumber = "(647)-789-1483";
            emergencyContactName = "John Cara";
            emergencyContactPhoneNumber = "(416)-159-0189";

            majorProgram = new Major();
        }
    }
}
