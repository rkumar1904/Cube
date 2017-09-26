using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AnalysisServices.Core;
using Microsoft.AnalysisServices.AdomdClient;
using System.Configuration;
using System.Data;

namespace NepalApi.Controllers
{
    public class NepalController : ApiController
    {
        public HttpResponseMessage List(string name = "cipla")
        {
            using (AdomdConnection conn = new AdomdConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                //    AdomdConnection conn = new AdomdConnection(
                //         "Data Source=localhost;Catalog=YourDatabase");
                //conn.Open();
                string commandText = @"SELECT FLATTENED 
                                   PredictAssociation()
                                   From
                                   [Mining Structure Name]
                                   NATURAL PREDICTION JOIN
                                   (SELECT (SELECT 1 AS [UserId]) AS [Vm]) AS t ";
                AdomdCommand cmd = new AdomdCommand(commandText, conn);
                AdomdDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    Console.WriteLine(Convert.ToString(dr[0]));
                }
                dr.Close();
                conn.Close();

                return null;
            }
        }
    }
}
