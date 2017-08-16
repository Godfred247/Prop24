﻿using DataAccessLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Prop24.Models;
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

                dbCon.Open();
                int d = dbcm.ExecuteNonQuery();
                dbCon.Close();

                return "Property Added";
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
                dbCmd.Parameters.Add(new MySqlParameter("_Image", MySqlDbType.Byte));
                dbCmd.Parameters["_Image"].Value = img.image;
                //dbCmd.Parameters.AddWithValue("_Image", img.image);
                dbCmd.Parameters.Add(new MySqlParameter("_Name", MySqlDbType.String));
                dbCmd.Parameters["_Name"].Value = img.name;
                dbCmd.Parameters.Add(new MySqlParameter("_Description", MySqlDbType.String));
                dbCmd.Parameters["_Description"].Value = img.description;
                

                dbCon.Open();
                int i = dbCmd.ExecuteNonQuery();
                dbCon.Close();

                return "Image Added";
            }
        }
    }
}