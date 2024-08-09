using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using QC = Microsoft.Data.SqlClient;

namespace Try_ADO_2
{
    internal class Program
    {

        public static SqlConnection con;
        static void Main(string[] args)
        {

            Console.WriteLine("???");
            TryConnect3();

            //string connectionString = "data source=RS-ADMIN;initial catalog=Office;integrated security=true\"\r\n";

            //Server=localhost; Database=MyDatabase; User Id=myUser; Password=myPassword;

            //string connectionString = "Server=localhost; Database=try-db-2";
            //SqlConnection con = new SqlConnection(connectionString);

            //Console.WriteLine($"state= {con.State}");
            //try
            //{
            //    //con.Open();
            //    Console.WriteLine("Connection successful!");

            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "SELECT * FROM cars";
            //    //con.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //}
            Console.WriteLine("Finish");
        }

        public static void TryConnect3()
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;
            //Integrated Security=True;Connect Timeout=30;Encrypt=False;
            //Trust Server Certificate=False;Application Intent=ReadWrite;
            //Multi Subnet Failover=False
            //using (var connection = new QC.SqlConnection(
            //"Server=tcp:(localdb)\\MSSQLLocalDB.database.windows.net,1433;" +
            //"Database=try-db-2;User ID=YOUR_LOGIN_NAME_HERE;" +
            //"Password=YOUR_PASSWORD_HERE;Encrypt=True;" +
            //"TrustServerCertificate=False;Connection Timeout=30;"
            //    ))
            //{


            string connectionString =
                "Server=tcp:(localdb)\\MSSQLLocalDB.database.windows.net,1433;" +
            "Database=try-db-2;User ID=YOUR_LOGIN_NAME_HERE;" +
            "Encrypt=False;" +
            "TrustServerCertificate=False;Connection Timeout=30;";
            //            string connectionString2 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string connectionString2 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=try-db-2;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            con = new SqlConnection(connectionString2);
            con.Open();
            Console.WriteLine("Connected successfully.");

            Console.WriteLine("State = " + con.State);

            PrintCars();


            Console.WriteLine("Press any key to finish...");
            con.Close();
            //Console.ReadKey(true);

        }

        public static void PrintCars()
        {
            ////assuming that connection is open

            //SqlCommand command2 = new SqlCommand("SELECT * FROM Cars;",con);
            string query = "SELECT * FROM cars;";
            SqlCommand command = new SqlCommand(query, con);


            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                        reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
        }

    }
}
