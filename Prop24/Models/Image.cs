using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prop24.Models
{
    public class Image
    {
        public byte[] image;
        public string name;
        public string description;

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
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public Image()
        {

        }
        public Image(byte[] iimage, string nname, string ddescription)
        {
            name = nname;
            image = iimage;
            description = ddescription;
        }
    }
}