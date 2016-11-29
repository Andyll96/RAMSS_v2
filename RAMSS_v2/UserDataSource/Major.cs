using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMSS_v2.UserDataSource
{
    public class Major
    {
        public List<Course> curriculum { get; set; }

        public List<KeyValuePair<int, Semester>> year1 { get; set; }
        public List<KeyValuePair<int, Semester>> year2 { get; set; }
        public List<KeyValuePair<int, Semester>> year3 { get; set; }
        public List<KeyValuePair<int, Semester>> year4 { get; set; }


        public Semester semester1 { get; set; }
        public Semester semester2 { get; set; }
        public Semester semester3 { get; set; }
        public Semester semester4 { get; set; }
        public Semester semester5 { get; set; }
        public Semester semester6 { get; set; }
        public Semester semester7 { get; set; }
        public Semester semester8 { get; set; }

        #region Courses Declarations
        public Course sem1Course1 { get; set; } // CPS109	Computer Science I
        public Course sem1Course2 { get; set; } // CPS213  Computer Organization I
        public Course sem1Course3 { get; set; } // MTH108   Linear Algebra
        public Course sem1Course4 { get; set; } // BLG143 OR CHY103 OR PCS110    Biology I OR General Chemistry I OR Physics
        public Course sem1Course5 { get; set; } // LIBERAL STUDIES: TABLE A

        public Course sem2Course1 { get; set; } // CPS209	Computer Science II ================================= CPS109
        public Course sem2Course2 { get; set; } // CPS310   Computer Organization II ============================ CPS213
        public Course sem2Course3 { get; set; } // CPS393   Introduction to C and UNIX ========================== NONE
        public Course sem2Course4 { get; set; } // MTH207   Calculus and Computational Methods I ================ NONE
        public Course sem2Course5 { get; set; } // LIBERAL STUDIES: TABLE A ===================================== NONE

        public Course sem3Course1 { get; set; } // CMN300	Communication in the Computer Industry ============== NONE
        public Course sem3Course2 { get; set; } // CPS305   Data Structures and Algorithms ====================== CPS213
        public Course sem3Course3 { get; set; } // CPS506   Comparative Programming Languages =================== CPS209
        public Course sem3Course4 { get; set; } // MTH110  Discrete Mathematics I ============================== NONE
        public Course sem3Course5 { get; set; } // PROFESSIONALLY RELATED ======================================= IDK

        public Course sem4Course1 { get; set; } // CPS406    Introduction to Software Engineering =============== CPS209
        public Course sem4Course2 { get; set; } // CPS412    Social Issues and Professional Practice ============ NONE
        public Course sem4Course3 { get; set; } // CPS420    Discrete Structures ================================ NONE
        public Course sem4Course4 { get; set; } // CPS590    Introduction to Operating Systems ================== CPS393
        public Course sem4Course5 { get; set; } // PROFESSIONALLY RELATED ======================================= IDK

        public Course sem5Course1 { get; set; } // CPS510    Database Systems I ================================= CPS305
        public Course sem5Course2 { get; set; } // CPS721    Artificial Intelligence I ========================== CPS305 & CPS420
        public Course sem5Course3 { get; set; } // PROFESSIONALLY RELATED ======================================= IDK
        public Course sem5Course4 { get; set; } // LIBERAL STUDIES: TABLE B ===================================== NONE
        public Course sem5Course5 { get; set; } // OPEN ELECTIVES =============================================== IDK

        public Course sem6Course1 { get; set; } // CPS633   Computer Security =================================== CPS393
        public Course sem6Course2 { get; set; } // CPS706   Computer Networks I ================================= CPS590
        public Course sem6Course3 { get; set; } // PROFESSIONALLY RELATED ======================================= IDK
        public Course sem6Course4 { get; set; } // LIBERAL STUDIES: TABLE B ===================================== NONE
        public Course sem6Course5 { get; set; } // OPEN ELECTIVES =============================================== NONE

        public Course sem7Course1 { get; set; } // PROFESSIONALLY RELATED ======================================= IDK
        public Course sem7Course2 { get; set; } // PROFESSIONALLY RELATED ======================================= IDK
        public Course sem7Course3 { get; set; } // PROFESSIONALLY RELATED ======================================= IDK
        public Course sem7Course4 { get; set; } // OPEN ELECTIVES =============================================== NONE
        public Course sem7Course5 { get; set; } // LIBERAL STUDIES: TABLE B ===================================== NONE

        public Course sem8Course1 { get; set; } // PROFESSIONALLY RELATED ======================================= IDK
        public Course sem8Course2 { get; set; } // PROFESSIONALLY RELATED ======================================= IDK
        public Course sem8Course3 { get; set; } // PROFESSIONALLY RELATED ======================================= IDK
        public Course sem8Course4 { get; set; } // OPEN ELECTIVES =============================================== NONE
        public Course sem8Course5 { get; set; } // LIBERAL STUDIES: TABLE B ===================================== NONE
        #endregion

        public Major()
        {
            curriculum = new List<Course>();

            year1 = new List<KeyValuePair<int, Semester>>();
            year2 = new List<KeyValuePair<int, Semester>>();
            year3 = new List<KeyValuePair<int, Semester>>();
            year4 = new List<KeyValuePair<int, Semester>>();


            sem1Course1 = new Course("CPS109", "Computer Science I", "ENG 123", "n/a", "8:00am", "Monday");
            sem1Course2 = new Course("CPS213", "Computer Organization I", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem1Course3 = new Course("MTH108", "Linear Algebra", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem1Course4 = new Course("PCS110", "Physics", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem1Course5 = new Course("LIBA01", "LIBERAL STUDIES: TABLE A1", "ENG 159", "n/a", "7:00pm", "Friday");

            sem1Course1.missing = false;
            sem1Course2.missing = false;
            sem1Course3.missing = false;
            sem1Course4.missing = false;
            sem1Course5.missing = false;
            sem1Course1.completed = true;
            sem1Course2.completed = true;
            sem1Course3.completed = true;
            sem1Course4.completed = true;
            sem1Course5.completed = true;

            sem2Course1 = new Course("CPS209", "Computer Science II", "ENG 123", "n/a", "8:00am", "Monday");
            sem2Course1.prerequisites.Add(sem1Course1);
            sem2Course2 = new Course("CPS310", "Computer Organization II", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem2Course2.prerequisites.Add(sem1Course2);
            sem2Course3 = new Course("CPS393", "Introduction to C and UNIX", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem2Course4 = new Course("MTH207", "Calculus and Computational Methods I", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem2Course5 = new Course("LIBA02", "LIBERAL STUDIES: TABLE A2", "ENG 159", "n/a", "7:00pm", "Friday");

            sem2Course1.missing = false;
            sem2Course2.missing = false;
            sem2Course3.missing = false;
            sem2Course4.missing = false;
            sem2Course5.missing = false;
            sem2Course1.completed = true;
            sem2Course2.completed = true;
            sem2Course3.completed = true;
            sem2Course4.completed = true;
            sem2Course5.completed = true;


            sem3Course1 = new Course("CMN300", "Communication in the Computer Industry", "ENG 123", "n/a", "8:00am", "Monday");
            sem3Course2 = new Course("CPS305", "Data Structures and Algorithms", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem3Course2.prerequisites.Add(sem1Course2);
            sem3Course3 = new Course("CPS506", "Comparative Programming Languages", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem3Course3.prerequisites.Add(sem2Course1);
            sem3Course4 = new Course("MTH110", "Discrete Mathematics I", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem3Course5 = new Course("PRL001", "PROFESSIONALLY RELATED 1", "ENG 159", "n/a", "7:00pm", "Friday");
            
            sem4Course1 = new Course("CPS406", "Introduction to Software Engineering", "ENG 123", "n/a", "8:00am", "Monday");
            sem4Course1.prerequisites.Add(sem2Course1);
            sem4Course2 = new Course("CPS412", "Social Issues and Professional Practice", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem4Course3 = new Course("CPS420", "Discrete Structures", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem4Course4 = new Course("CPS590", "Introduction to Operating Systems", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem4Course4.prerequisites.Add(sem2Course3);
            sem4Course5 = new Course("PRL002", "PROFESSIONALLY RELATED 2", "ENG 159", "n/a", "7:00pm", "Friday");

            sem5Course1 = new Course("CPS510", "Database Systems I", "ENG 123", "n/a", "8:00am", "Monday");
            sem5Course1.prerequisites.Add(sem3Course2);
            sem5Course2 = new Course("CPS721", "Artificial Intelligence I", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem5Course2.prerequisites.Add(sem3Course2);
            sem5Course2.prerequisites.Add(sem4Course3);
            sem5Course3 = new Course("PRL003", "PROFESSIONALLY RELATED 3", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem5Course4 = new Course("LIBB01", "LIBERAL STUDIES: TABLE B1", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem5Course5 = new Course("OPE001", "OPEN ELECTIVES 1", "ENG 159", "n/a", "7:00pm", "Friday");

            sem6Course1 = new Course("CPS633", "Computer Security", "ENG 123", "n/a", "8:00am", "Monday");
            sem6Course1.prerequisites.Add(sem2Course3);
            sem6Course2 = new Course("CPS706", "Computer Networks I", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem6Course2.prerequisites.Add(sem4Course4);
            sem6Course3 = new Course("PRL004", "PROFESSIONALLY RELATED 4", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem6Course4 = new Course("LIBB02", "LIBERAL STUDIES: TABLE B2", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem6Course5 = new Course("OPE002", "OPEN ELECTIVES 2", "ENG 159", "n/a", "7:00pm", "Friday");

            sem7Course1 = new Course("PRL005", "PROFESSIONALLY RELATED 5", "ENG 123", "n/a", "8:00am", "Monday");
            sem7Course2 = new Course("PRL006", "PROFESSIONALLY RELATED 6", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem7Course3 = new Course("PRL007", "PROFESSIONALLY RELATED 7", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem7Course4 = new Course("LIBB03", "LIBERAL STUDIES: TABLE B3", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem7Course5 = new Course("OPE003", "OPEN ELECTIVES 3", "ENG 159", "n/a", "7:00pm", "Friday");

            sem8Course1 = new Course("PRL006", "PROFESSIONALLY RELATED 6", "ENG 123", "n/a", "8:00am", "Monday");
            sem8Course2 = new Course("PRL007", "PROFESSIONALLY RELATED 7", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem8Course3 = new Course("PRL008", "PROFESSIONALLY RELATED 8", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem8Course4 = new Course("LIBB04", "LIBERAL STUDIES: TABLE B4", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem8Course5 = new Course("OPE004", "OPEN ELECTIVES 4", "ENG 159", "n/a", "7:00pm", "Friday");

            semester1 = new Semester(1, DateTime.Parse("2014-09-06"), DateTime.Parse("2014-12-06"));
            semester2 = new Semester(2, DateTime.Parse("2015-01-13"), DateTime.Parse("2015-04-13"));
            semester3 = new Semester(3, DateTime.Parse("2015-09-06"), DateTime.Parse("2015-12-06"));
            semester4 = new Semester(4, DateTime.Parse("2016-01-13"), DateTime.Parse("2016-04-13"));
            semester5 = new Semester(5, DateTime.Parse("2016-09-06"), DateTime.Parse("2016-12-06"));
            semester6 = new Semester(6, DateTime.Parse("2017-01-13"), DateTime.Parse("2017-04-13"));
            semester7 = new Semester(7, DateTime.Parse("2017-09-06"), DateTime.Parse("2017-12-06"));
            semester8 = new Semester(8, DateTime.Parse("2018-01-13"), DateTime.Parse("2018-04-13"));

            curriculum.Add(sem1Course1);
            curriculum.Add(sem1Course2);
            curriculum.Add(sem1Course3);
            curriculum.Add(sem1Course4);
            curriculum.Add(sem1Course5);

            curriculum.Add(sem2Course1);
            curriculum.Add(sem2Course2);
            curriculum.Add(sem2Course3);
            curriculum.Add(sem2Course4);
            curriculum.Add(sem2Course5);

            curriculum.Add(sem3Course1);
            curriculum.Add(sem3Course2);
            curriculum.Add(sem3Course3);
            curriculum.Add(sem3Course4);
            curriculum.Add(sem3Course5);

            curriculum.Add(sem4Course1);
            curriculum.Add(sem4Course2);
            curriculum.Add(sem4Course3);
            curriculum.Add(sem4Course4);
            curriculum.Add(sem4Course5);

            curriculum.Add(sem5Course1);
            curriculum.Add(sem5Course2);
            curriculum.Add(sem5Course3);
            curriculum.Add(sem5Course4);
            curriculum.Add(sem5Course5);

            curriculum.Add(sem6Course1);
            curriculum.Add(sem6Course2);
            curriculum.Add(sem6Course3);
            curriculum.Add(sem6Course4);
            curriculum.Add(sem6Course5);

            curriculum.Add(sem7Course1);
            curriculum.Add(sem7Course2);
            curriculum.Add(sem7Course3);
            curriculum.Add(sem7Course4);
            curriculum.Add(sem7Course5);

            curriculum.Add(sem8Course1);
            curriculum.Add(sem8Course2);
            curriculum.Add(sem8Course3);
            curriculum.Add(sem8Course4);
            curriculum.Add(sem8Course5);

            semester1.courseList.Add(sem1Course1);
            semester1.courseList.Add(sem1Course2);
            semester1.courseList.Add(sem1Course3);
            semester1.courseList.Add(sem1Course4);
            semester1.courseList.Add(sem1Course5);

            semester2.courseList.Add(sem2Course1);
            semester2.courseList.Add(sem2Course2);
            semester2.courseList.Add(sem2Course3);
            semester2.courseList.Add(sem2Course4);
            semester2.courseList.Add(sem2Course5);
            year1.Add(new KeyValuePair<int, Semester>(1,semester1));
            year1.Add(new KeyValuePair<int, Semester>(2,semester2));

            semester3.courseList.Add(sem3Course1);
            semester3.courseList.Add(sem3Course2);
            semester3.courseList.Add(sem3Course3);
            semester3.courseList.Add(sem3Course4);
            semester3.courseList.Add(sem3Course5);

            semester4.courseList.Add(sem4Course1);
            semester4.courseList.Add(sem4Course2);
            semester4.courseList.Add(sem4Course3);
            semester4.courseList.Add(sem4Course4);
            semester4.courseList.Add(sem4Course5);
            year2.Add(new KeyValuePair<int, Semester>(1,semester3));
            year2.Add(new KeyValuePair<int, Semester>(2,semester4));

            semester5.courseList.Add(sem5Course1);
            semester5.courseList.Add(sem5Course2);
            semester5.courseList.Add(sem5Course3);
            semester5.courseList.Add(sem5Course4);
            semester5.courseList.Add(sem5Course5);

            semester6.courseList.Add(sem6Course1);
            semester6.courseList.Add(sem6Course2);
            semester6.courseList.Add(sem6Course3);
            semester6.courseList.Add(sem6Course4);
            semester6.courseList.Add(sem6Course5);
            year3.Add(new KeyValuePair<int, Semester>(1,semester5));
            year3.Add(new KeyValuePair<int, Semester>(2,semester6));

            semester7.courseList.Add(sem7Course1);
            semester7.courseList.Add(sem7Course2);
            semester7.courseList.Add(sem7Course3);
            semester7.courseList.Add(sem7Course4);
            semester7.courseList.Add(sem7Course5);

            semester8.courseList.Add(sem8Course1);
            semester8.courseList.Add(sem8Course2);
            semester8.courseList.Add(sem8Course3);
            semester8.courseList.Add(sem8Course4);
            semester8.courseList.Add(sem8Course5);
            year4.Add(new KeyValuePair<int, Semester>(1,semester7));
            year4.Add(new KeyValuePair<int, Semester>(2,semester8));

        }
    }
}