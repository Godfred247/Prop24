using Prop24.Models;
using System.Web.Http;

namespace Prop24.Controllers
{
    public class ImageController : ApiController
    {
        DAL dal = new DAL();

        [HttpGet]
        [System.Web.Http.Route("api/Image")]
        public string AddImage(Image img)
        {
            return dal.AddImage(img);
        }

    }
}
