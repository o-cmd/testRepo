using Microsoft.SqlServer.Server;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace OneToOneOps
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.Write("Enter Person ID : ");
            //int Pid = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Enter First Name : ");
            //String fName = Console.ReadLine();

            //Console.Write("Enter Last Name : ");
            //String lName = Console.ReadLine();

            //Console.Write("Enter Gender : ");
            //String gender = Console.ReadLine();

            //Console.Write("Enter Date of Birth");
            //string dob = Console.ReadLine();


            string cs = "data source = encdappunlt0080; database = testdb; integrated security = true";
            SqlConnection conn = new SqlConnection(cs);

            //string insertQueryPerson = string.Format("insert into Person({0},'{1}','{2}','{3}','{4}')"
            //                                         ,Pid,fName,lName,gender,dob);
            //SqlCommand insertPersonCommand = new SqlCommand(insertQueryPerson, conn);
            // conn.Open();
            //     int n = insertPersonCommand.ExecuteNonQuery();
            // Console.WriteLine("{0} row(s) are inserted successfully in Person Table", n);

            // conn.Close();



            // Console.Write("Enter Address Id : ");
            // int addressId = Convert.ToInt32(Console.ReadLine());

            // Console.Write("Enter Street Address : ");
            // string streetAddr = Console.ReadLine();

            // Console.Write("Enter City : ");
            // string city = Console.ReadLine();

            // Console.Write("Enter State : ");
            // string state = Console.ReadLine();

            // Console.WriteLine("Enter Zip Code : ");
            // int zipCode = Convert.ToInt32(Console.ReadLine());

            // Console.WriteLine(" Enter Person Id : ");
            // int pid = Convert.ToInt32(Console.ReadLine());

            // string insertQueryAddress = string.Format("insert into Address({0},'{1}','{2}','{3}',{4},{5})"
            //                                         , addressId,streetAddr,city,state,zipCode,pid);
            // SqlCommand insertAddressCommand = new SqlCommand(insertQueryPerson, conn);
            // conn.Open();
            // int i = insertAddressCommand.ExecuteNonQuery();
            // Console.WriteLine("{0} row(s) are inserted successfully in Address Table", i);

            // conn.Close();

            string insertQueryPersons = "INSERT INTO Person (PersonID, FirstName, LastName, Gender, DateOfBirth)" +
                                 "VALUES (3, 'Viraj', 'Shinde', 'M', '2019-25-11')";

            conn.Open();
            SqlCommand insertcmd1 = new SqlCommand(insertQueryPersons, conn);
            insertcmd1.ExecuteNonQuery();
            conn.Close();

            string insertQueryAddress = "INSERT INTO Address (AddressID, StreetAddress, City, State, ZipCode, PersonID)" +
                "VALUES (3, 'colony no 8', 'pune', 'MH', '142105', 3)";
            conn.Open();
            SqlCommand insertcmd2 = new SqlCommand(insertQueryAddress, conn);
            insertcmd2.ExecuteNonQuery();
            conn.Close();


            //To display the content of tables
            string selectQueryPerson = "select * From Person";

            SqlCommand selectcmd1 = new SqlCommand(selectQueryPerson, conn);

            conn.Open();

            SqlDataReader rdr = selectcmd1.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("{0}     {1}       {2}        {3}        {4}",
                        rdr["PersonId"], rdr["FirstName"], rdr["LastName"], rdr["Gender"], rdr["DateOfBirth"]);
                }
            }
            conn.Close();

            Console.WriteLine("\n\n");


            string selectQueryAddress = "select * From Address";

            SqlCommand selectcmd2 = new SqlCommand(selectQueryAddress, conn);

            conn.Open();

            SqlDataReader rdr1 = selectcmd2.ExecuteReader();

            if (rdr1.HasRows)
            {
                while (rdr1.Read())
                {
                    Console.WriteLine("{0}     {1}       {2}        {3}        {4}        {5}",
                        rdr1["AddressID"], rdr1["StreetAddress"], rdr1["City"], rdr1["State"], rdr1["ZipCode"], rdr1["PersonID"]);
                }
            }
            conn.Close();
        }
    }
}
