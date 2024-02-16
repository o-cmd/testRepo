using System.Data.SqlClient;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string cs = "data source = ENCDAPPUNLT0080; database = testDB; Integrated Security = True";
            SqlConnection conn = new SqlConnection(cs);

            string query = "select * From Persons";

            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while(rdr.Read())
                {
                    Console.WriteLine("{0}     {1}", rdr["PersonId"], rdr["LastName"]);
                }
            }

            //Console.Write("Enter Id : ");
            //int id = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Enter Name : ");
            //string name = Console.ReadLine();

            //string cs = "data source = ENCDAPPUNLT0080; database = testDB; Integrated Security = True";
            //SqlConnection conn = new SqlConnection(cs);

            //string query = string.Format("INSERT INTO Persons values({0},'{1}')",id, name);

            //SqlCommand cmd = new SqlCommand(query, conn);
            //conn.Open();

            //int n = cmd.ExecuteNonQuery();
            //Console.WriteLine("{0} row(s) inserted Successfuly...", n);
            //conn.Close();
        }
    }
}
