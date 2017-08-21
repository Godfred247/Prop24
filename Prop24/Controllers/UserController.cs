using System.Web.Http;
using DataAccessLayer;
using Prop24.Models;
using System.Net.Mail;
using System.Net;

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
        //[System.Web.Http.Route("api/User")]
        public User userLogin(string email, string password)
        {
            return dal.userLogin(email, password);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public string PostSendEmail()
        //{
        //    SmtpClient client = new SmtpClient();
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    client.EnableSsl = true;
        //    client.Host = "smtp.gmail.com";
        //    client.Port = 587;

        //    NetworkCredential cred = new NetworkCredential("gpnkumane@gmail.com", "Nqaba247");
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = cred;

        //    MailMessage msg = new MailMessage();
        //    msg.From = new MailAddress("gpnkumane@gmail.com");
        //    msg.To.Add(new MailAddress(""));
        //    msg.Subject = "Property details";
        //    msg.IsBodyHtml = true;
        //    msg.Body = string.Format("<html><head></head><body><b>");
        //}
    }
}
