using DataAccessLayer;
using Prop24.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
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

        [HttpGet]
        [System.Web.Http.Route("api/PropertyID")]
        public Property GetPropertyId(string price, string m2, string address, string title, string description, string suburb, string typee, string noOfBeds, string noOfBaths, string noOfGarages)
        {
            return dal.GetPropertyId(price, m2, address, title, description, suburb, typee, noOfBeds, noOfBaths, noOfGarages);
        }
    }
}