using System.Collections.Generic;
using System.Data.SqlClient;
using System.Numerics;

namespace ManyToManyOps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cs = "data source = encdappunlt0080; database = testdb; integrated security = true";
            SqlConnection conn = new SqlConnection(cs);

            //Insert Operation on Student table
            string insertQueryStudents = "INSERT INTO Student(StudentID, FirstName, LastName, Email, Phone)" +
                                        "VALUES(5, 'Onkar', 'Shinde', 'onkarsh@email.com', '852-369-7410')";

            conn.Open();
            SqlCommand insertcmdstud = new SqlCommand(insertQueryStudents, conn);
            insertcmdstud.ExecuteNonQuery();
            conn.Close();

            //Insert operation on Couser Table
            string insertQueryCourse = "INSERT INTO Course (CourseID, CourseName, Credits)" +
                                        "VALUES(4, 'Science', 5)";

            conn.Open();
            SqlCommand insertcmdcourse = new SqlCommand(insertQueryCourse, conn);
            insertcmdcourse.ExecuteNonQuery();
            conn.Close();

            //Insert Operation on StudentCourse table
            string insertQuerystudcourse = "INSERT INTO StudentCourse (StudentID, CourseID)VALUES(5, 4)";

            conn.Open();
            SqlCommand insertcmdstudcourse = new SqlCommand(insertQuerystudcourse, conn);
            insertcmdstudcourse.ExecuteNonQuery();
            conn.Close();


            //Display Operation on Student Table
            string selectQueryStudent = "select * from Student";

            SqlCommand selectcmdstud = new SqlCommand (selectQueryStudent, conn);

            conn.Open();

            SqlDataReader rdr1 = selectcmdstud.ExecuteReader();

            if(rdr1.HasRows)
            {
                while(rdr1.Read())
                {
                    Console.WriteLine("{0}          {1}         {2}         {3}         {4}",
                        rdr1["StudentID"], rdr1["FirstName"], rdr1["LastName"], rdr1["Email"], rdr1["Phone"]);

                }
            }
            conn.Close();

            Console.WriteLine("\n \n");

            //Display Operation on Customer Table
            string selectQueryCourse = "select * from Course";

            SqlCommand selectcmdcourse = new SqlCommand(selectQueryCourse, conn);

            conn.Open();

            SqlDataReader rdr2 = selectcmdcourse.ExecuteReader();

            if(rdr2.HasRows)
            {
                while(rdr2.Read())
                {
                    Console.WriteLine("{0}          {1}         {2}",
                                        rdr2["CourseID"], rdr2["CourseName"], rdr2["Credits"]);    
                }
            }
            conn.Close();

            Console.WriteLine("\n \n");

            //Display Operation on StudentCourse Table
            string seletctQueryStudCourse = "select * from StudentCourse";

            SqlCommand selectcmdstudcourse = new SqlCommand(seletctQueryStudCourse, conn);

            conn.Open();
            SqlDataReader rdr3 = selectcmdstudcourse.ExecuteReader();

            if(rdr3.HasRows)
            {
                while(rdr3.Read())
                {
                    Console.WriteLine("{0}          {1}",
                                        rdr3["StudentID"], rdr3["CourseID"]);
                }
            }
            conn.Close();
        }
    }
}
 