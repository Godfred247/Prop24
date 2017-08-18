﻿using Prop24.Models;
using System.IO;
using System.Web;
using System.Web.Http;

namespace Prop24.Controllers
{
    public class ImageController : ApiController
    {
        DAL dal = new DAL();

        [HttpPost]
        [System.Web.Http.Route("api/Image")]
        public string AddImage()
        {
            Image img = new Image();
            
            HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

           for (int i = 0; i < hfc.Count; i++)
            {
                System.Web.HttpPostedFile file = hfc[i];

                string fileName = new FileInfo(file.FileName).Name;

                if(file.ContentLength > 0)
                {
                    byte[] buffer = new byte[file.ContentLength];
                    file.InputStream.Read(buffer,0,file.ContentLength);
                    img.image = buffer;
                    img.name = fileName;
                    img.description = "Pictures";
                }
            }

            return dal.AddImage(img);
        }

    }
}
