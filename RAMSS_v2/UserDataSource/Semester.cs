using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMSS_v2.UserDataSource
{
    public class Semester
    {

        public int semesterNumber { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<Course> courseList { get; set; }

        public Semester()
        {
            courseList = new List<Course>();
        }

        public Semester(int semesterNumber, DateTime startDate, DateTime endDate)
        {
            courseList = new List<Course>();
            this.semesterNumber = semesterNumber;
            this.startDate = startDate;
            this.endDate = endDate;
        }

    }
}
