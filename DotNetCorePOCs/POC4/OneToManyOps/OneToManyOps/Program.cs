using System.Data.SqlClient;

namespace OneToManyOps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cs = "data source = encdappunlt0080; database = testdb; integrated security = true";
            SqlConnection conn = new SqlConnection(cs);

            //Insert Operation on Customer Table
            string insertQueryCustomer = "INSERT INTO Customer (CustomerID, FirstName, LastName, Email, Phone)" +
                                        "VALUES(1, 'Onkar', 'Shinde', 'onkar.shinde@example.com', '123-456')";

            conn.Open();
            SqlCommand insertcmd1 = new SqlCommand(insertQueryCustomer, conn);
            insertcmd1.ExecuteNonQuery();
            conn.Close();


            //Insert Operation on Orders Table
            string insertQueryOrders = "INSERT INTO Orders (OrderID, OrderDate, TotalAmount, CustomerID)" +
                                        "VALUES(3, '2024-03-12 12:30:00', 700.00, 1)";
            conn.Open();
            SqlCommand insertcmd2 = new SqlCommand(insertQueryOrders, conn);
            insertcmd2.ExecuteNonQuery();
            conn.Close();


            //To display the content of both the tables.
            string selectQueryCustomer = "select * from Customer";

            SqlCommand selectcmd1 = new SqlCommand(selectQueryCustomer, conn);

            conn.Open();

            SqlDataReader rdr = selectcmd1.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("{0}          {1}         {2}         {3}         {4}",
                        rdr["CustomerID"], rdr["FirstName"], rdr["LastName"], rdr["Email"], rdr["Phone"]);
                }
            }
            conn.Close();


            string selectQueryOrders = "select * from Orders";

            SqlCommand sqlCommand2 = new SqlCommand(selectQueryOrders, conn);

            conn.Open();

            SqlDataReader rdr1 = sqlCommand2.ExecuteReader();

            if ( rdr1.HasRows)
            {
                while (rdr1.Read())
                {
                    Console.WriteLine("{0}          {1}         {2}         {3}",
                        rdr1["OrderID"], rdr1["OrderDate"], rdr1["TotalAmount"], rdr1["CustomerID"]);
                }
            }
            conn.Close();
        }
    }
}
