﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prop24.Models
{
    public class Image
    {
        public byte[] image;
        public string name;

        public byte[] ImageData
        {
            get { return image; }
            set { image = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Image()
        {

        }
        public Image(byte[] iimage, string nname)
        {
            name = nname;
            image = iimage;
        }
    }
}