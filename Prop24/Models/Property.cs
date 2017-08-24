using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace DataAccessLayer
{
    public class Property
    {
        public int propertyID;
        public string price;
        public string m2;
        public string address;
        public string title;
        public string description;
        public string suburb;
        public string typee;
        public string noOfBeds;
        public string noOfBaths;
        public string noOfGarages;
        public byte[] imagedata;      

        public int PropertyID
        {
            get { return propertyID; }
            set { propertyID = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string M2
        {
            get { return m2; }
            set { m2 = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }
        public string Typee
        {
            get { return typee; }
            set { typee = value; }
        }

        public string NoOfBeds
        {
            get { return noOfBeds; }
            set { noOfBeds = value; }
        }
        public string NoOfBaths
        {
            get { return noOfBaths; }
            set { noOfBeds = value; }
        }
        public string NoOfGarages
        {
            get { return noOfGarages; }
            set { noOfGarages = value; }
        }
        public byte[] Image1
        {
            get { return imagedata; }
            set { imagedata = value; }
        }      
        public Property(int propID, string PPrice, string PM2, string PAddress, string PTitle, string PDescription, string PSuburb, string PTypee, string PBeds, string PBaths, string PGarages)
        {
            propertyID = propID;
            price = PPrice;
            m2 = PM2;
            address = PAddress;
            title = PTitle;
            description = PDescription;
            suburb = PSuburb;
            typee = PTypee;
            noOfBeds = PBeds;
            noOfBaths = PBaths;
            noOfGarages = PGarages;
        }
        public Property()
        {

        }
    }
}