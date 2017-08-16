using DataAccessLayer;
using Prop24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace Prop24.Controllers
{
    public class PropertyController : ApiController
    {
        // GET: Property
        DAL dal = new DAL();

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Property")]
        public string PropAdd(Property pr)
        {
            return dal.PropAdd(pr);
        }


        [HttpGet]
        [System.Web.Http.Route("api/prop")]
        public IEnumerable<Property> GetProperty()
        {
            return dal.GetProperty();
        }
    }
}