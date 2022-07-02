using Microsoft.AspNetCore.Http;
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
    public class ProductController : ControllerBase
    {
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private readonly IConfiguration _configuration;
        [Route("productmaster")]
        [HttpPost]
        public JsonResult productmaster(Product pm)
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("tblproductmaster", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "get3");
                sqlcmd.Parameters.AddWithValue("@id", 0);
                sqlcmd.Parameters.AddWithValue("@product_id", pm.product_id);
                sqlcmd.Parameters.AddWithValue("@category_mid", pm.category);
                sqlcmd.Parameters.AddWithValue("@size_mid", pm.size);
                sqlcmd.Parameters.AddWithValue("@Colmid", pm.color);
                sqlcmd.Parameters.AddWithValue("@mpackid", pm.package);
                sqlcmd.Parameters.AddWithValue("@tag_id", pm.tag);

                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();
                //sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            return new JsonResult(dt);

        }

        [Route("insproductmaster")]
        [HttpPost]
        public JsonResult insproductmaster(Productls psl)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("tblproductinserter", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "inprodata");
                sqlcmd.Parameters.AddWithValue("@Cmid", psl.Cmid);
                sqlcmd.Parameters.AddWithValue("@Bid", psl.Brandid);
                sqlcmd.Parameters.AddWithValue("@Pname", psl.Pname.ToString());
                sqlcmd.Parameters.AddWithValue("@Ldescription", psl.LD.ToString());
                sqlcmd.Parameters.AddWithValue("@SDescription", psl.SD.ToString());
                sqlcmd.Parameters.AddWithValue("@MRP", psl.MRP);
                sqlcmd.Parameters.AddWithValue("@DP", psl.DP);
                sqlcmd.Parameters.AddWithValue("@Availablequantity", psl.Availqty);
                sqlcmd.Parameters.AddWithValue("@status", psl.status);
                sqlcmd.Parameters.AddWithValue("@Gid", psl.gid);
                sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return new JsonResult("Insert Successfully");

        }
        [Route("inscolormaster")]
        [HttpPost]
        public JsonResult inscolormaster(int CMID , int ProID , int StatusID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("tblproductinserter", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "incolordata");
                sqlcmd.Parameters.AddWithValue("@ColMid", CMID);
                sqlcmd.Parameters.AddWithValue("@Pid", ProID);
                sqlcmd.Parameters.AddWithValue("@status", StatusID);
                sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return new JsonResult("Insert Successfully");

        }

        [Route("inssizemaster")]
        [HttpPost]
        public JsonResult inssizemaster(int SMID , int ProID , int StatusID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("tblproductinserter", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "insizedata");
                sqlcmd.Parameters.AddWithValue("@SMid", SMID);
                sqlcmd.Parameters.AddWithValue("@Pid", ProID);
                sqlcmd.Parameters.AddWithValue("@status", StatusID);
                sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return new JsonResult("Insert Successfully");

        }

        [Route("getproID")]
        [HttpPost]
        public JsonResult getproID(string pname)
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("tblproductinserter", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "getpid");
                sqlcmd.Parameters.AddWithValue("@Pname", pname);
                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();
                sqlConnection.Close();
            }
            return new JsonResult(dt);

        }
        [Route("inspackmaster")]
        [HttpPost]
        public JsonResult inspackmaster(int MPackID, int ProID, int StatusID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("tblproductinserter", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "inpackdata");
                sqlcmd.Parameters.AddWithValue("@MPackID", MPackID);
                sqlcmd.Parameters.AddWithValue("@Pid", ProID);
                sqlcmd.Parameters.AddWithValue("@status", StatusID);
                sqlcmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return new JsonResult("Insert Successfully");

        }

        [Route("getproductdetail")]
        [HttpGet]
        public JsonResult getproductdetail()
        {
            DataTable dt = new DataTable();
            SqlDataReader myreader;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("EcommAppCon")))
            {
                sqlConnection.Open();

                SqlCommand sqlcmd = new SqlCommand("tblproductinserter", sqlConnection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Action", "getproductdata");
                myreader = sqlcmd.ExecuteReader();
                dt.Load(myreader);
                myreader.Close();

                sqlConnection.Close();
            }
            return new JsonResult(dt);
        }
    }
}
