using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NepalApi.Controllers
{
    public class DashboardController : ApiController
    {
        [Route("getInfo")]
        [ActionName("getInfo")]
        public string getInfo()
        {
            return "Hello Aamir Pe";
        }
        [Route("testing")]
        [ActionName("testing")]
        public string testing()
        {
            return "Hello Devi Be";
        }
        //public List<string> getList()
        //{
        //    return new List<string>
        //    {
        //        "Devi Ka ",
        //        "Gaurav Ki",
        //        "Rajesh Ko"
        //    };
        //}
    }
}
