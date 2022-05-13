using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EcomAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from user_table";
            DataTable dt = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("EcommAppCon");
            SqlDataReader myreader;
            using(SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open(); 
                using(SqlCommand mycmd = new SqlCommand(query , mycon))
                {
                    myreader = mycmd.ExecuteReader();
                    dt.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(dt);
        }
    }
}
