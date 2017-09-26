using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace NepalApi.Controllers
{
    public class TestingController : ApiController
    {
        //GET: api/Testing/ManufactureSales/
        //[Route("ManufactureSales")]
        [Route("api/testing/{anyString}")]
        [AcceptVerbs("Get","Post")]
        public HttpResponseMessage ManufactureSales(string name = "cipla")
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                string querystring = "select * from nepal_cube where manufacturename= '" +  name + "'";
                SqlCommand cmd = new SqlCommand(querystring, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "nepal_cube");
            }
            //return ds;
            return Request.CreateResponse(HttpStatusCode.OK, ds);
        }    
    }
}
