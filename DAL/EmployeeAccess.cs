namespace DBMan;
using DAL;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;


public class EmployeeAccess
{
public static string conString = @"
server=localhost;
port=3306;
user=root;
password=root123;
database=rahulemp; 
";

public  static List<Employee> GetAllEmployee(){
             List<Employee> allEmployee = new List<Employee>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            string query = "select * from Employee";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                Employee user = new Employee
                {
                    Id = int.Parse(row["id"].ToString()),
                    Fname = row["fname"].ToString(),
                    Lname = row["lname"].ToString(),
                   
                };
                allEmployee.Add(user);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return allEmployee;
    }
}