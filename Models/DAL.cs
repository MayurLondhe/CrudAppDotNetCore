using System.Data;
using System.Data.SqlClient;

namespace CrudAppDotNetCore.Models
{
    public class DAL
    {
        public Response GetAllEmployee(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblCrudNetCore",connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee> listEmployee = new List<Employee>();
            if (dt.Rows.Count > 0)
            {
                for(int i=0;  i<dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    listEmployee.Add(employee);
                }

            }
            if (listEmployee.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.ListEmployees = listEmployee;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Data Not Found";
                response.ListEmployees = null;
            }
            response.ListEmployees = listEmployee;
            return response; 
        }
        public Response GetEmployeeById(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblCrudNetCore where ID = '"+id+"' ", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Employee listEmployee = new Employee();
            if (dt.Rows.Count > 0)
            {
               
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.Employee = employee;

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Data Not Found";
                response.Employee = null;
            }
            return response;
        }
        public Response AddEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into tblCrudNetCore(Name,Email,IsActive,CreateOn) values('"+ employee.Name + "','"+ employee.Email + "','"+ employee.IsActive + "',GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "employee added";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "no employee added";
            }
            return response;
        }
        public Response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("update tblCrudNetCore set Name = '" + employee.Name + "',Email = '" + employee.Email + "',IsActive = '" + employee.IsActive + "' where id = '" + employee.Id+"' ", connection);
            connection.Open();
           
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "employee updeted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "no employee updeted";
            }
            
            


            return response;
        }

        public Response DeleteEmployee(SqlConnection connection, int id) 
        {
            Response response; response = new Response();
            SqlCommand cmd = new SqlCommand("delete from tblCrudNetCore where id = " + id +"",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "employee deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "employee is not deleted";
            }
            return response;
        }
        public Response Login(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from tblCrudNetCore where Name= '" + employee.Name + "' and Email='" + employee.Email + "'", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
           
            if (dt.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee is Login alredy";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "need to signup";
            }
            return response;
        }
    }
}
