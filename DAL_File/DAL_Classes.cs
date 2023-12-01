using CrudAppDotNetCore.Logic_Classes;
using CrudAppDotNetCore.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CrudAppDotNetCore.DAL_File
{
    public class DAL_Classes
    {
        
        public Response GetResponse(int id)
        {
            //SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            LogicForResponse lg = new LogicForResponse();
            Response response = new Response(); 
            try
            {

            }catch (Exception ex)
            {
                response.StatusMessage = ex.Message;
            }
            return null;
        }
       
    }
}
