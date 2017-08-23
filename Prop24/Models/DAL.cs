using DataAccessLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Prop24.Models;
using System.Net.Mail;
using System.Net;

namespace Prop24.Models
{
    public class DAL
    {
        string connString;
        public string ConnectionString
        {
            get { return connString; }
            set { connString = value; }
        }
        public DAL()
        {
            connString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }
        //string constr = "server=localhost;uid=root;password=123456;database=property24;";

        public string AddUser(User user)
        {
            using (MySqlConnection dbCon = new MySqlConnection(connString))
            {
                MySqlCommand dbCmd = new MySqlCommand("spInsertUser", dbCon);

                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.AddWithValue("Email", user.email);
                dbCmd.Parameters.AddWithValue("Password", user.password);

                dbCon.Open();
                int i = dbCmd.ExecuteNonQuery();
                dbCon.Close();

                return "User Added!";

            }

        }

        public User userLogin(string email, string password)
        {
            using (MySqlConnection dbCon = new MySqlConnection(connString))
            {
                MySqlCommand dbcmd = new MySqlCommand("spUserLogin", dbCon);
                dbcmd.CommandType = CommandType.StoredProcedure;

                dbcmd.Parameters.Add(new MySqlParameter("_Email", MySqlDbType.String));
                dbcmd.Parameters["_Email"].Value = email;
                dbcmd.Parameters.Add(new MySqlParameter("_Password", MySqlDbType.String));
                dbcmd.Parameters["_Password"].Value = password;

                User usr = null;

                try
                {
                    if (dbCon.State == ConnectionState.Closed)
                    {
                        dbCon.Open();
                    }
                    MySqlDataReader rdr = dbcmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        usr = new User(Convert.ToString(rdr["email"]),
                            Convert.ToString(rdr["password"]));
                    }
                    rdr.Close();
                }
                catch (MySqlException)
                {
                    throw new Exception("Error reading data");
                }
                return usr;
            }
        }

        public string PropAdd(Property prop)
        {
            using (MySqlConnection dbCon = new MySqlConnection(connString))
            {
                MySqlCommand dbcm = new MySqlCommand("spAddProperty", dbCon);
                dbcm.CommandType = CommandType.StoredProcedure;

                dbcm.Parameters.AddWithValue("_Price", prop.price);
                dbcm.Parameters.AddWithValue("_M2", prop.m2);
                dbcm.Parameters.AddWithValue("_Address", prop.address);
                dbcm.Parameters.AddWithValue("_Title", prop.title);
                dbcm.Parameters.AddWithValue("_Description", prop.description);
                dbcm.Parameters.AddWithValue("_Suburb", prop.suburb);
                dbcm.Parameters.AddWithValue("_Type", prop.typee);
                dbcm.Parameters.AddWithValue("_Beds", prop.noOfBeds);
                dbcm.Parameters.AddWithValue("_Baths", prop.noOfBaths);
                dbcm.Parameters.AddWithValue("_Garage", prop.noOfGarages);
                dbcm.Parameters.AddWithValue("_Image1", prop.image1);

                dbCon.Open();
                int d = dbcm.ExecuteNonQuery();
                dbCon.Close();

                return "Property Added";
            }
        }

        public Property getPropId(string price, string m2, string address, string title, string description, string suburb, string typee, string noOfBeds, string noOfBaths, string noOfGarages)
        {
            //List<Property> list = new List<Property>();
            Property prop = new Property();
            
            using (MySqlConnection dbCon = new MySqlConnection(connString))
            {
                
                if (dbCon.State == ConnectionState.Closed)
                {
                    dbCon.Open();
                }

                MySqlCommand dbcmd = new MySqlCommand("spGetPropID", dbCon);
                dbcmd.CommandType = CommandType.StoredProcedure;

                dbcmd.Parameters.Add(new MySqlParameter("_price", MySqlDbType.String));
                dbcmd.Parameters["_price"].Value = price;
                dbcmd.Parameters.Add(new MySqlParameter("_m2", MySqlDbType.String));
                dbcmd.Parameters["_m2"].Value = m2;
                dbcmd.Parameters.Add(new MySqlParameter("_address", MySqlDbType.String));
                dbcmd.Parameters["_address"].Value = address;
                dbcmd.Parameters.Add(new MySqlParameter("_title", MySqlDbType.String));
                dbcmd.Parameters["_title"].Value = title;
                dbcmd.Parameters.Add(new MySqlParameter("_description", MySqlDbType.String));
                dbcmd.Parameters["_description"].Value = description;
                dbcmd.Parameters.Add(new MySqlParameter("_suburb", MySqlDbType.String));
                dbcmd.Parameters["_suburb"].Value = suburb;
                dbcmd.Parameters.Add(new MySqlParameter("_typee", MySqlDbType.String));
                dbcmd.Parameters["_typee"].Value = typee;
                dbcmd.Parameters.Add(new MySqlParameter("_noOfBeds", MySqlDbType.String));
                dbcmd.Parameters["_noOfBeds"].Value = noOfBeds;
                dbcmd.Parameters.Add(new MySqlParameter("_noOfBaths", MySqlDbType.String));
                dbcmd.Parameters["_noOfBaths"].Value = noOfBaths;
                dbcmd.Parameters.Add(new MySqlParameter("_noOfGarages", MySqlDbType.String));
                dbcmd.Parameters["_noOfGarages"].Value = noOfGarages;

                Property propy = null;

                MySqlDataReader rdr = dbcmd.ExecuteReader();

                while(rdr.Read())
                {
                    propy = new Property(Convert.ToInt32(rdr["propertyID"]),
                          Convert.ToString(rdr["price"]),
                          Convert.ToString(rdr["m2"]),
                          Convert.ToString(rdr["address"]),
                          Convert.ToString(rdr["title"]),
                          Convert.ToString(rdr["description"]),
                          Convert.ToString(rdr["suburb"]),
                          Convert.ToString(rdr["typee"]),
                          Convert.ToString(rdr["noOfBeds"]),
                          Convert.ToString(rdr["noOfBaths"]),
                          Convert.ToString(rdr["noOfGarages"]));               
                }
                try
                {
                    rdr.Close();
                    MySqlDataReader reader = dbcmd.ExecuteReader(CommandBehavior.SingleRow);
                    reader.Read();
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    throw new ApplicationException(ex.ToString());
                }
                return propy;

                
            }
        }

        public User usrUpdate(int userId, string name, string mobileNumber, string password, string area, string province)
        {
            using (MySqlConnection dbCon = new MySqlConnection(connString))
            {
                MySqlCommand dbCmd = new MySqlCommand("spUpdateProfile", dbCon);

                //dbCmd.Parameters.Add(new MySqlParameter("_userID", MySqlDbType.Int32));
                //dbCmd.Parameters["userId"].Value = _userID;
                dbCmd.Parameters.Add(new MySqlParameter("Namee", MySqlDbType.String));
                dbCmd.Parameters["Namee"].Value = name;
                dbCmd.Parameters.Add(new MySqlParameter("MobileNumba", MySqlDbType.String));
                dbCmd.Parameters["MobileNumba"].Value = mobileNumber;
                dbCmd.Parameters.Add(new MySqlParameter("Pass", MySqlDbType.String));
                dbCmd.Parameters["Pass"].Value = password;
                dbCmd.Parameters.Add(new MySqlParameter("Ar", MySqlDbType.String));
                dbCmd.Parameters["Ar"].Value = area;
                dbCmd.Parameters.Add(new MySqlParameter("Prov", MySqlDbType.String));
                dbCmd.Parameters["Prov"].Value = province;

                User usrUp = null;

                try
                {
                    if (dbCon.State == ConnectionState.Closed)
                    {
                        dbCon.Open();
                    }
                    MySqlDataReader rdr = dbCmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        usrUp = new User(
                            Convert.ToString(rdr["name"]),
                            Convert.ToString(rdr["mobileNumber"]),
                            Convert.ToString(rdr["password"]),
                            Convert.ToString(rdr["area"]),
                            Convert.ToString(rdr["province"]));
                    }
                    rdr.Close();
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.ToString());
                }
                return usrUp;
                
            }
        }
        
        public Property[] GetProperty()
        {
            List<Property> propList = new List<Property>();

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MySqlCommand cmd = new MySqlCommand("spGetProperty", con);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    Property property = new Property();

                    property.price = rdr["price"].ToString();
                    property.m2 = rdr["m2"].ToString();
                    property.address = rdr["address"].ToString();
                    property.title = rdr["title"].ToString();
                    property.description = rdr["description"].ToString();
                    property.suburb = rdr["suburb"].ToString();
                    property.typee = rdr["typee"].ToString();
                    property.noOfBeds = rdr["noOfBeds"].ToString();
                    property.noOfBaths = rdr["noOfBaths"].ToString();
                    property.noOfGarages = rdr["noOfGarages"].ToString();

                    propList.Add(property);
                }
                try
                {
                    rdr.Close();
                    MySqlDataReader dbreader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    dbreader.Read();
                    dbreader.Close();
                }
                catch (MySqlException ex)
                {
                    throw new ApplicationException(ex.ToString());
                }
                return propList.ToArray();
            }
        }

        public string AddImage(Image img)
        {
            using (MySqlConnection dbCon = new MySqlConnection(connString))
            {
                MySqlCommand dbCmd = new MySqlCommand("spInsertImage", dbCon);

                dbCmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter[] paras = new MySqlParameter[2];
                paras[0] = new MySqlParameter("_Image", MySqlDbType.MediumBlob);
                paras[0].Value = img.image;

                paras[1] = new MySqlParameter("_Name", MySqlDbType.String);
                paras[1].Value = img.name;
              
                dbCmd.Parameters.AddRange(paras);
               
                dbCon.Open();
                dbCmd.ExecuteNonQuery();
                dbCon.Close();

                return "Image Added";
            }
        }

        public string PostSendEmail(Email email)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            NetworkCredential cred = new NetworkCredential("gpnkumane@gmail.com", "Nqaba247");
            client.UseDefaultCredentials = false;
            client.Credentials = cred;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(email.emailFrom);
            //msg.Sender = new MailAddress(email.emailFrom);
            msg.To.Add(new MailAddress("gpnkumane@gmail.com"));
            msg.Subject = "Property Details";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head><head><body><b>Name: </b>" + email.emailName + "<br /><br />" + "<b>Email: </b>" + email.emailFrom + "<br /><br />" + "<b>Mobile Number: </b>" + email.emailNumber + "<br /><br />" + email.emailBody + "</body></html>");
            

            try
            {
                client.Send(msg);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        //public Image[] GetImage()
        //{
        //    List<Image> imgList = new List<Image>();

        //    using (MySqlConnection dbCon = new MySqlConnection(connString))
        //    {
        //        if (dbCon.State == ConnectionState.Closed)
        //        {
        //            dbCon.Open();
        //        }
        //        MySqlCommand dbCmd = new MySqlCommand("spGetImages", dbCon);
        //        dbCmd.CommandType = CommandType.StoredProcedure;

        //        MySqlDataReader rdr = dbCmd.ExecuteReader();

        //        //while(rdr.Read())
        //        //{
        //        //    Image img = Convert.T rdr["imagedate"].ToString();
        //        //}

        //    }
        //}
    }
}