using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using EcomAPIs.Models;
namespace EcomAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("LoginAuth")]
        [HttpPost]
        public JsonResult LoginAuth(Userlogin uLogin)
        {
            object value;
            string query = @"select * from tblUser where RoleID = 2 and  IsDelete = 0 and Email =@Username and Password = @Password";
            DataTable dt = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("EcommAppCon");
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycmd = new SqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@Username", uLogin.Username);
                    mycmd.Parameters.AddWithValue("@Password", uLogin.Password);
                    value = mycmd.ExecuteScalar();
                    mycon.Close();
                }
            }
            if (value != null)
            {
                return new JsonResult(value.ToString());
            }
            return new JsonResult("Authentication Failed");
        }

        [Route("CreateGSTInfo")]
        [HttpPost]
        public JsonResult CreateGSTInfo(GstMaster gm)
        {
            string query = "insert into GstMaster(GId,HSNCode,GDescription ,CGSTRate,IGSTRate ,status) VALUES(@GID , @HSNCode , @GDescription ,@CGSTR , @SGSTR ,@status)";
            DataTable dt = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("EcommAppCon");
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycmd = new SqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@GID", gm.GID);
                    mycmd.Parameters.AddWithValue("@HSNCode", gm.HSNCode);
                    mycmd.Parameters.AddWithValue("@GDescription", gm.GDescription.ToString());
                    mycmd.Parameters.AddWithValue("@CGSTR", gm.CGSTR);
                    mycmd.Parameters.AddWithValue("@SGSTR", gm.SGSTR);
                    mycmd.Parameters.AddWithValue("@status", gm.status);
                    mycmd.ExecuteNonQuery();
                    mycon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [Route("ReadGSTInfo")]
        [HttpGet]
        public JsonResult ReadGSTInfo()
        {
            string query = @"select * from GST_Master";
            DataTable dt = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("EcommAppCon");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycmd = new SqlCommand(query, mycon))
                {
                    myreader = mycmd.ExecuteReader();
                    dt.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(dt);
        }


        [Route("updateGSTInfo")]
        [HttpPut]
        public JsonResult updateGSTInfo(GstMaster ugm)
        {
            string query = @" update GstMaster set  HSNCode = @HSNCode ,GDescription= @GDescription ,CGSTRate = @CGSTR ,IGSTRate=@SGSTR,status = @status where GId = @GID";
            string sqlDataSource = _configuration.GetConnectionString("EcommAppCon");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@GID", ugm.GID);
                    myCommand.Parameters.AddWithValue("@HSNCode", ugm.HSNCode);
                    myCommand.Parameters.AddWithValue("@GDescription", ugm.GDescription.ToString());
                    myCommand.Parameters.AddWithValue("@CGSTR", ugm.CGSTR);
                    myCommand.Parameters.AddWithValue("@SGSTR", ugm.SGSTR);
                    myCommand.Parameters.AddWithValue("@status", ugm.status);
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult DeleteGSTInfo(GstMaster ugm)
        {
            string query = @"update GstMaster set status = 0 where GID = @GID";
            // string query = @" delete from GstMaster where GID = @GID";
            string sqlDataSource = _configuration.GetConnectionString("EcommAppCon");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@GID", ugm.GID);
                    myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }

       
    }
}
