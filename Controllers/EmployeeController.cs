using CrudAppDotNetCore.DAL_File;
using CrudAppDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace CrudAppDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllemployee")]
        public IActionResult GetAllemployee()
        {
            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
                Response response = new Response();
                DAL dal = new DAL();
                response = dal.GetAllEmployee(conn);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can also return a specific error response if needed
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
                Response response = new Response();
                DAL dAL = new DAL();
                response = dAL.GetEmployeeById(conn, id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can also return a specific error response if needed
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
                Response response = new Response();
                DAL dAL = new DAL();
                response = dAL.AddEmployee(conn, employee);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can also return a specific error response if needed
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
                Response response = new Response();
                DAL dAL = new DAL();
                response = dAL.UpdateEmployee(conn, employee);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can also return a specific error response if needed
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
                
                Response response = new Response();
                DAL dAL = new DAL();
                response = dAL.DeleteEmployee(conn, id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can also return a specific error response if needed
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Employee employee)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
                Response response = new Response();
                DAL dAL = new DAL();
                response = dAL.Login(conn, employee);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can also return a specific error response if needed
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("GetResponse")]
        public Response GetResponse(Employee employee)
        {
            DAL_Classes dAL = new DAL_Classes();
            Response response = new Response();
            try
            {
                if(employee.Id == 0)
                {
                   

                }
                else
                {
                    response = dAL.GetResponse(employee.Id);
                }
                if(response.StatusCode == 1)
                {

                }

            }catch (Exception ex)
            {
                response.StatusMessage = ex.Message;
            }
            return null;
        }
    }
}
