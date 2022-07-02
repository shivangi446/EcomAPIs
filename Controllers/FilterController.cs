using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EcomAPIs.Models;
namespace EcomAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
       

        private readonly IConfiguration _configuration;

        public FilterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("filtersizemaster")]
        [HttpPost]
        public JsonResult filtersizemaster(Product pm)
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("tblproductmaster", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "pSize");
                sqlcmd.Parameters.AddWithValue("@id", 0);
                sqlcmd.Parameters.AddWithValue("@product_id", pm.product_id);
                sqlcmd.Parameters.AddWithValue("@category_mid", 0);
                sqlcmd.Parameters.AddWithValue("@size_mid", 0);
                sqlcmd.Parameters.AddWithValue("@Colmid", 0);
                sqlcmd.Parameters.AddWithValue("@mpackid", 0);
                sqlcmd.Parameters.AddWithValue("@tag_id", 0);

                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();
                //sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            return new JsonResult(dt);

        }
        [Route("filtercolormaster")]
        [HttpPost]
        public JsonResult filtercolormaster(Product pm)
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("tblproductmaster", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "pColor");
                sqlcmd.Parameters.AddWithValue("@id", 0);
                sqlcmd.Parameters.AddWithValue("@product_id", pm.product_id);
                sqlcmd.Parameters.AddWithValue("@category_mid", 0);
                sqlcmd.Parameters.AddWithValue("@size_mid", 0);
                sqlcmd.Parameters.AddWithValue("@Colmid", 0);
                sqlcmd.Parameters.AddWithValue("@mpackid", 0);
                sqlcmd.Parameters.AddWithValue("@tag_id", 0);

                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();
                //sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            return new JsonResult(dt);

        }
        [Route("filterpackagemaster")]
        [HttpPost]
        public JsonResult filterpackagemaster(Product pm)
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("tblproductmaster", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "pPackage");
                sqlcmd.Parameters.AddWithValue("@id", 0);
                sqlcmd.Parameters.AddWithValue("@product_id", pm.product_id);
                sqlcmd.Parameters.AddWithValue("@category_mid", 0);
                sqlcmd.Parameters.AddWithValue("@size_mid", 0);
                sqlcmd.Parameters.AddWithValue("@Colmid", 0);
                sqlcmd.Parameters.AddWithValue("@mpackid", 0);
                sqlcmd.Parameters.AddWithValue("@tag_id", 0);

                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();
                //sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            return new JsonResult(dt);

        }
    }
}
