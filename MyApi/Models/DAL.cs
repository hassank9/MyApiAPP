using Microsoft.Extensions.Configuration;
using MyApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace ASP_CORE_API.Models
{
    public class DAL
    {
        public Response GetAllEmployee(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from Employees", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee> lstEmployees = new List<Employee>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["EmpId"].ToString());
                    employee.EmpName = dt.Rows[i]["EmpName"].ToString();
                    employee.Password = dt.Rows[i]["Password"].ToString();
                    lstEmployees.Add(employee);
                }
            }
            if (lstEmployees.Count > 0)
            {
                response.StatusCode = 200;
                response.ErrorMessage = "Data Found";
                response.listEmployee = lstEmployees;
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                response.listEmployee = null;
            }
            return response;
        }

        public Response GetEmployeeById(SqlConnection connection,int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from Employees where EmpId = '"+ id +"' ", connection);
            DataTable dt = new DataTable();
            Employee Employees = new Employee();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[0]["EmpId"].ToString());
                    employee.EmpName = dt.Rows[0]["EmpName"].ToString();
                    employee.Password = dt.Rows[0]["Password"].ToString();
                response.StatusCode = 200;
                response.ErrorMessage = "Data Found";
                response.Employee = employee;
            } 
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                response.listEmployee = null;
            }
            return response;
        }

        public Response AddEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Employees(EmpName,Password) VALUES ('"+employee.EmpName+"','"+employee.Password+"')", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.ErrorMessage = "Employee added.";
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data inserted.";
            }
            return response;
        }

        public Response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Employees SET EmpName = '"+employee.EmpName+"' , Password = '"+employee.Password+"' WHERE EmpId = '"+employee.Id+"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.ErrorMessage = "Employee Updated.";
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No employee Updated.";
            }
            return response;
        }


        public Response DeleteEmployee(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmpId = '"+id+"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.ErrorMessage = "Employee deleted.";
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No employee deleted.";
            }
            return response;
        }



        public ResponseUsers GetAllUsers(SqlConnection connection,int ID)
        {
            ResponseUsers response = new ResponseUsers();
            List<Users> lstUsers = new List<Users>();

            SqlCommand cmd = new SqlCommand("spSELECT_UsersTb", connection);
            if (ID > 0) { cmd.Parameters.AddWithValue("ID", ID); }
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader read = cmd.ExecuteReader();
            while(read.Read())
            {
                    Users users = new Users();
                    users.users_id = Convert.ToInt32(read["users_id"].ToString());
                    users.users_name = read["users_name"].ToString();
                    users.users_email = read["users_email"].ToString();
                    users.users_phone = read["users_phone"].ToString();
                    users.users_verefiycode = Convert.ToInt32(read["users_verefiycode"].ToString());
                    users.users_approve = Convert.ToInt32(read["users_approve"].ToString());
                    lstUsers.Add(users);
            }
            if (lstUsers.Count > 0)
            {
                response.StatusCode = 200;
                response.ErrorMessage = "Data Found";
                response.listUsers = lstUsers;
                connection.Close();
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data Found";
                response.listUsers = null;
                connection.Close();
            }
            return response;
        }


        public ResponseUsers AddUsers(SqlConnection connection, Users users)
        {
            ResponseUsers response = new ResponseUsers();
            SqlCommand cmd = new SqlCommand("spINSERT_UsersTb", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("users_name", users.users_name); 
            cmd.Parameters.AddWithValue("users_email", users.users_email); 
            cmd.Parameters.AddWithValue("users_phone", users.users_phone); 
            cmd.Parameters.AddWithValue("users_verefiycode", users.users_verefiycode); 
            cmd.Parameters.AddWithValue("users_approve", users.users_approve); 
            connection.Open();
            int i = Convert.ToInt32(cmd.ExecuteScalar());

            if (1 > 0)
            {
                response.StatusCode = 200;
                response.ErrorMessage = "User added.";
                connection.Close();
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No Data inserted.";
                connection.Close();
            }
            return response;
        }

    }
}