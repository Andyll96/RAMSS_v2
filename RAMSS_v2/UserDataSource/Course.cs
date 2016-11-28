using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMSS_v2.UserDataSource
{
    class Course
    {

        public String code { get; set; }
        public String description { get; set; }
        public String location { get; set; }
        public String professor { get; set; }
        public Double unit { get; set; }

        public String grade { get; set; }

        public String time { get; set; }
        public String dayOfWeek { get; set; }


        public List<Course> prerequisites { get; set; }
        
        public Course(String code, String description, String location, String professor, String time, String dayOfTheWeek)
        {
            prerequisites = new List<Course>();
            unit = 1.00;

            this.code = code;
            this.description = description;
            this.location = location;
            this.professor = professor;
            this.time = time;
            this.dayOfWeek = dayOfWeek;
        }

        public String[] calendarInfo()
        {
            String[] info = { code, description, time, location, professor };
            return info;
        }
    }
}
