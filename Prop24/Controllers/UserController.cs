using System.Web.Http;
using DataAccessLayer;
using Prop24.Models;
using System.Net.Mail;
using System.Net;
using System;

namespace Prop24.Controllers
{
    public class UserController : ApiController
    {
        // GET: User
        DAL dal = new DAL();

        [HttpPost]
        public string AddUser(User usr)
        {
            return dal.AddUser(usr);

        }

       [HttpPut]
       [Route("api/update")]
       public User usrUpdate(int userId, string name, string mobileNumber, string password, string area, string province)
        {
            return dal.usrUpdate(userId, name, mobileNumber, password, area, province);
        }

        [HttpGet]
        [Route("api/login")]
        public User userLogin(string email, string password)
        {
            return dal.userLogin(email, password);
        }

        [HttpPost]
        [Route("api/email")]
        [AllowAnonymous]
        public string PostSendEmail(Email email)
        {
            return dal.PostSendEmail(email);
        }
    }
}
