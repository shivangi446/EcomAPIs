using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomAPIs.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EcomAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private readonly IConfiguration _configuration;

        [Route("MainCategory")]
        [HttpGet]
        public JsonResult MainCategory()
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("SpMasterCategories", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "Get0");
                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();
                //sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            return new JsonResult(dt);
        }

        [Route("BrandCategory")]
        [HttpGet]
        public JsonResult BrandCategory()
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("SpMasterCategories", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "GetBName");
                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();
                //sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            return new JsonResult(dt);
        }




        [Route("categorymaster")]
        [HttpGet]
        public JsonResult categorymaster()
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("SpMasterCategories", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "Get1");
                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();
                //sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            return new JsonResult(dt);

        }

        [Route("SubCategorymaster")]
        [HttpPost]
        public JsonResult SubCategorymaster(string parentid)
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("SpMasterCategories", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "Get2");
                sqlcmd.Parameters.AddWithValue("@Parentid", parentid);
                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();
                sqlConnection.Close();

            }
            return new JsonResult(dt);

        }


        [Route("getidCategorymaster")]
        [HttpPost]
        public JsonResult getidCategorymaster(GetMasterID msc)
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("SpMasterCategories", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "Get3");
                sqlcmd.Parameters.AddWithValue("@Cmid", 0);
                sqlcmd.Parameters.AddWithValue("@Parentid", 0);
                sqlcmd.Parameters.AddWithValue("@Cname", msc.CatName.ToString());
                sqlcmd.Parameters.AddWithValue("@Cdescription", 0);
                sqlcmd.Parameters.AddWithValue("@Status", 0);
                sqlcmd.Parameters.AddWithValue("@IsDelete", 0);
                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();
                //sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            return new JsonResult(dt);

        }


        [HttpDelete("{id}")]
          public JsonResult DelSubCategorymaster(MasterCat msc)
          {
              // DataTable dt = new DataTable();
              //SqlDataReader myreader;
              using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
              {
                  sqlConnection.Open();

                  SqlCommand sqlcmd = new SqlCommand("SpMasterCategory", sqlConnection);
                  sqlcmd.CommandType = CommandType.StoredProcedure;
                  sqlcmd.Parameters.AddWithValue("@Action", "Delete");
                  sqlcmd.Parameters.AddWithValue("@Cmid", msc.Cmid);
                  sqlcmd.Parameters.AddWithValue("@Parentid", msc.Parentid);
                  sqlcmd.Parameters.AddWithValue("@Cname", msc.Cname.ToString());
                  sqlcmd.Parameters.AddWithValue("@Cdesciption", msc.Cdescription.ToString());
                  sqlcmd.Parameters.AddWithValue("@Status", msc.Status);
                  sqlcmd.Parameters.AddWithValue("@IsDelete", 1);
                  //myreader = sqlcmd.ExecuteReader();
                  //dt.Load(myreader);
                  //myreader.Close();
                  sqlcmd.ExecuteNonQuery();
                  sqlConnection.Close();

              }
              return new JsonResult("Delete Successfully");

          }

        [Route("insSubCategorymaster")]
        [HttpPost]
        public JsonResult insSubCategorymaster(MasterCat msc)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("SpMasterCategories", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "Insert");
                sqlcmd.Parameters.AddWithValue("@Cmid", msc.Cmid);
                sqlcmd.Parameters.AddWithValue("@Parentid", msc.Parentid);
                sqlcmd.Parameters.AddWithValue("@Cname", msc.Cname.ToString());
                sqlcmd.Parameters.AddWithValue("@Cdescription", msc.Cdescription.ToString());
                sqlcmd.Parameters.AddWithValue("@Status", msc.Status);
                sqlcmd.Parameters.AddWithValue("@IsDelete", 0);
                sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            return new JsonResult("Insert Successfully");

        }
    }
}
