using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMSS_v2.UserDataSource
{
    public class Course
    {

        public String code { get; set; }
        public String description { get; set; }
        public String location { get; set; }
        public String professor { get; set; }
        public Double unit { get; set; }

        public String grade { get; set; }

        public String time { get; set; }
        public String dayOfWeek { get; set; }

        public Boolean missing { get; set; }
        public Boolean taking { get; set; }
        public Boolean completed { get; set; }


        public List<Course> prerequisites { get; set; }
        
        public Course()
        {
            prerequisites = new List<Course>();
            unit = 1.00;
            missing = true;
            taking = false;
            completed = false;
        }

        public Course(String code, String description, String location, String professor, String time, String dayOfTheWeek)
        {
            prerequisites = new List<Course>();
            unit = 1.00;
            missing = true;
            taking = false;
            completed = false;

            this.code = code;
            this.description = description;
            this.location = location;
            this.professor = professor;
            this.time = time;
            this.dayOfWeek = dayOfTheWeek;
        }

        public String[] calendarInfo(Boolean calendarView)
        {
            if(calendarView == false)
            {
                String[] info = { "\tCode: " + code + "\n\t\t","Class: " + description + "\n\t\t","Time: " + time + "\n\t\t","Location: " + location + "\n\t\t","Professor: " + professor + "\n\n"};
                return info;
            }
            else
            {
                String[] info = { "Code: " + code + "\n\t", "Class: " + description + "\n\t", "Time: " + time + "\n\t", "Location: " + location + "\n\t", "Professor: " + professor + "\n\n" };
                return info;
            }
            
        }

        public static implicit operator List<object>(Course v)
        {
            throw new NotImplementedException();
        }


    }
}
