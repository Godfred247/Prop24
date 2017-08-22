using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prop24.Models
{
    public class Email
    {
        public string emailName;
        public string emailFrom;
        public string emailNumber;
        public string emailBody;

        public string EmailName
        {
            get { return emailName; }
            set { emailName = value; }
        }
        public string EmailFrom
        {
            get { return emailFrom; }
            set { emailFrom = value; }
        }
        public string EmailNumber
        {
            get { return emailNumber; }
            set { emailNumber = value; }
        }
        public string EmailBody
        {
            get { return emailBody; }
            set { emailBody = value; }
        }
        public Email()
        {

        }
    }
}