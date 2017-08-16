using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
    public class User
    {
        //public int userId;
        public string name;
        public string mobileNumber;
        public string email;
        public string password;
        public string area;
        public string province;
        public string role;

        //public int UserID
        //{
        //    get { return userId; }
        //    set { userId = value; }
        //}
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string MobileNumber
        {
            get { return mobileNumber; }
            set { mobileNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        public string Province
        {
            get { return province; }
            set { province = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        public User(string uName, string uMobileNumber, string uEmail, string Password, string uArea, string uProvince, string uRole)
        {
            name = uName;
            mobileNumber = uMobileNumber;
            email = uEmail;
            password = Password;
            area = uArea;
            province = uProvince;
            role = uRole;
        }
        public User(string eemail, string ppassword)
        {
            email = eemail;
            password = ppassword;
        }

        public User(string nname, string mmobileNumber, string ppass, string aarea, string pprovince)
        {
            //userId = userID;
            name = nname;
            mobileNumber = mmobileNumber;
            password = ppass;
            area = aarea;
            province = pprovince;
        }
        public User()
        {

        }
    }
}