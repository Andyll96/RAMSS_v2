using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMSS_v2.UserDataSource
{
    public class Major
    {
        
        List<Semester> year1 = new List<Semester>();
        List<Semester> year2 = new List<Semester>();
        List<Semester> year3 = new List<Semester>();
        List<Semester> year4 = new List<Semester>();

        Semester semester1;
        Semester semester2;
        Semester semester3;
        Semester semester4;
        Semester semester5;
        Semester semester6;
        Semester semester7;
        Semester semester8;

#region Courses Declarations
        Course sem1Course1; // CPS109	Computer Science I
        Course sem1Course2; // CPS213  Computer Organization I
        Course sem1Course3; // MTH108   Linear Algebra
        Course sem1Course4; // BLG143 OR CHY103 OR PCS110    Biology I OR General Chemistry I OR Physics
        Course sem1Course5; // LIBERAL STUDIES: TABLE A

        Course sem2Course1; // CPS209	Computer Science II ================================= CPS109
        Course sem2Course2; // CPS310   Computer Organization II ============================ CPS213
        Course sem2Course3; // CPS393   Introduction to C and UNIX ========================== NONE
        Course sem2Course4; // MTH207   Calculus and Computational Methods I ================ NONE
        Course sem2Course5; // LIBERAL STUDIES: TABLE A ===================================== NONE

        Course sem3Course1; // CMN300	Communication in the Computer Industry ============== NONE
        Course sem3Course2; // CPS305   Data Structures and Algorithms ====================== CPS213 or CPS211
        Course sem3Course3; // CPS506   Comparative Programming Languages =================== CPS209
        Course sem3Course4 ; // MTH110  Discrete Mathematics I ============================== NONE
        Course sem3Course5; // PROFESSIONALLY RELATED ======================================= IDK

        Course sem4Course1; // CPS406    Introduction to Software Engineering =============== CPS311 or CPS209
        Course sem4Course2; // CPS412    Social Issues and Professional Practice ============ NONE
        Course sem4Course3; // CPS420    Discrete Structures ================================ NONE
        Course sem4Course4; // CPS590    Introduction to Operating Systems ================== CPS393
        Course sem4Course5; // PROFESSIONALLY RELATED ======================================= IDK

        Course sem5Course1; // CPS510    Database Systems I ================================= CPS305
        Course sem5Course2; // CPS721    Artificial Intelligence I ========================== (CPS305 & MTH210 & MTH304) or (CPS305 & CPS420)
        Course sem5Course3; // PROFESSIONALLY RELATED ======================================= IDK
        Course sem5Course4; // LIBERAL STUDIES: TABLE B ===================================== NONE
        Course sem5Course5; // OPEN ELECTIVES =============================================== IDK

        Course sem6Course1; // CPS633   Computer Security =================================== CPS393
        Course sem6Course2; // CPS706   Computer Networks I ================================= CPS590
        Course sem6Course3; // PROFESSIONALLY RELATED ======================================= IDK
        Course sem6Course4; // LIBERAL STUDIES: TABLE B ===================================== NONE
        Course sem6Course5; // OPEN ELECTIVES =============================================== NONE

        Course sem7Course1; // PROFESSIONALLY RELATED ======================================= IDK
        Course sem7Course2; // PROFESSIONALLY RELATED ======================================= IDK
        Course sem7Course3; // PROFESSIONALLY RELATED ======================================= IDK
        Course sem7Course4; // OPEN ELECTIVES =============================================== NONE
        Course sem7Course5; // LIBERAL STUDIES: TABLE B ===================================== NONE

        Course sem8Course1; // PROFESSIONALLY RELATED ======================================= IDK
        Course sem8Course2; // PROFESSIONALLY RELATED ======================================= IDK
        Course sem8Course3; // PROFESSIONALLY RELATED ======================================= IDK
        Course sem8Course4; // OPEN ELECTIVES =============================================== NONE
        Course sem8Course5; // LIBERAL STUDIES: TABLE B ===================================== NONE
#endregion

        public Major()
        {
            sem1Course1 = new Course("CPS109", "Computer Science I", "ENG 123", "n/a", "8:00am", "Monday");
            sem1Course2 = new Course("CPS213", "Computer Organization I", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem1Course3 = new Course("MTH108", "Linear Algebra", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem1Course4 = new Course("PCS110", "Physics", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem1Course5 = new Course("LIBA1", "LIBERAL STUDIES: TABLE A1", "ENG 159", "n/a", "7:00pm", "Friday");

            sem2Course1 = new Course("CPS209", "Computer Science II", "ENG 123", "n/a", "8:00am", "Monday");
            sem2Course2 = new Course("CPS310", "Computer Organization II", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem2Course3 = new Course("CPS393", "Introduction to C and UNIX", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem2Course4 = new Course("MTH207", "Calculus and Computational Methods I", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem2Course5 = new Course("LIBA2", "LIBERAL STUDIES: TABLE A2", "ENG 159", "n/a", "7:00pm", "Friday");

            sem3Course1 = new Course("CMN300", "Communication in the Computer Industry", "ENG 123", "n/a", "8:00am", "Monday");
            sem3Course2 = new Course("CPS305", "Data Structures and Algorithms", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem3Course3 = new Course("CPS506", "Comparative Programming Languages", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem3Course4 = new Course("MTH110", "Discrete Mathematics I", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem3Course5 = new Course("PRL1", "PROFESSIONALLY RELATED 1", "ENG 159", "n/a", "7:00pm", "Friday");

            sem4Course1 = new Course("CPS406", "Introduction to Software Engineering", "ENG 123", "n/a", "8:00am", "Monday");
            sem4Course2 = new Course("CPS412", "Social Issues and Professional Practice", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem4Course3 = new Course("CPS420", "Discrete Structures", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem4Course4 = new Course("CPS590", "Introduction to Operating Systems", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem4Course5 = new Course("PRL2", "PROFESSIONALLY RELATED 2", "ENG 159", "n/a", "7:00pm", "Friday");

            sem5Course1 = new Course("CPS510", "Database Systems I", "ENG 123", "n/a", "8:00am", "Monday");
            sem5Course2 = new Course("CPS721", "Artificial Intelligence I", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem5Course3 = new Course("PRL3", "PROFESSIONALLY RELATED 3", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem5Course4 = new Course("LIBB1", "LIBERAL STUDIES: TABLE B1", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem5Course5 = new Course("OPE1", "OPEN ELECTIVES 1", "ENG 159", "n/a", "7:00pm", "Friday");

            sem6Course1 = new Course("CPS633", "Computer Security", "ENG 123", "n/a", "8:00am", "Monday");
            sem6Course2 = new Course("CPS706", "Computer Networks I", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem6Course3 = new Course("PRL4", "PROFESSIONALLY RELATED 4", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem6Course4 = new Course("LIBB2", "LIBERAL STUDIES: TABLE B2", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem6Course5 = new Course("OPE2", "OPEN ELECTIVES 2", "ENG 159", "n/a", "7:00pm", "Friday");

            sem7Course1 = new Course("PRL5", "PROFESSIONALLY RELATED 5", "ENG 123", "n/a", "8:00am", "Monday");
            sem7Course2 = new Course("PRL6", "PROFESSIONALLY RELATED 6", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem7Course3 = new Course("PRL7", "PROFESSIONALLY RELATED 7", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem7Course4 = new Course("LIBB3", "LIBERAL STUDIES: TABLE B3", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem7Course5 = new Course("OPE3", "OPEN ELECTIVES 3", "ENG 159", "n/a", "7:00pm", "Friday");

            sem8Course1 = new Course("PRL6", "PROFESSIONALLY RELATED 6", "ENG 123", "n/a", "8:00am", "Monday");
            sem8Course2 = new Course("PRL7", "PROFESSIONALLY RELATED 7", "ENG 147", "n/a", "10:00am", "Tuesday");
            sem8Course3 = new Course("PRL8", "PROFESSIONALLY RELATED 8", "ENG 789", "n/a", "1:00pm", "Wednesday");
            sem8Course4 = new Course("LIBB4", "LIBERAL STUDIES: TABLE B4", "ENG 369", "n/a", "4:00pm", "Thursday");
            sem8Course5 = new Course("OPE4", "OPEN ELECTIVES 4", "ENG 159", "n/a", "7:00pm", "Friday");

            semester1 = new Semester(1, DateTime.Parse("2014-09-06"), DateTime.Parse("2014-12-06"));
            semester2 = new Semester(2, DateTime.Parse("2015-01-13"), DateTime.Parse("2015-04-13"));
            semester3 = new Semester(3, DateTime.Parse("2015-09-06"), DateTime.Parse("2015-12-06"));
            semester4 = new Semester(4, DateTime.Parse("2016-01-13"), DateTime.Parse("2016-04-13"));
            semester5 = new Semester(5, DateTime.Parse("2016-09-06"), DateTime.Parse("2016-12-06"));
            semester6 = new Semester(6, DateTime.Parse("2017-01-13"), DateTime.Parse("2017-04-13"));
            semester7 = new Semester(7, DateTime.Parse("2017-09-06"), DateTime.Parse("2017-12-06"));
            semester8 = new Semester(8, DateTime.Parse("2018-01-13"), DateTime.Parse("2018-04-13"));

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
            year1.Add(semester1);
            year1.Add(semester2);

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
            year2.Add(semester3);
            year2.Add(semester4);

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
            year3.Add(semester5);
            year3.Add(semester6);

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
            year4.Add(semester7);
            year4.Add(semester8);

        }
    }
}