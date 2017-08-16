using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prop24.Models;
using System.Data;
using DataAccessLayer;

namespace Prop24.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DAL layer = new DAL();
        DataAccessLayer.User userLayer = new DataAccessLayer.User();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult dashboard()
        {
            return View();
        }

        //[HttpGet]
        //public int userLogin(User us)
        //{
        //    //return layer.userLogin(us);
        //    int count = Convert.ToInt32(layer.userLogin(us));

        //    if (count == 1)
        //    {
        //        Session["userm"] = us.email;
        //        Session["userm"] = us.password;
        //    }
        //    else
        //    {
        //        count = -1;
        //    }
        //    return count;
        //}

    }
}
