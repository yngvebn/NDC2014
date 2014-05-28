using System.Web.Mvc;

namespace Demo.Controllers
{
    [RoutePrefix("movie")]
    public class MovieController: Controller
    {
        [Route("")]
        public ActionResult Add()
        {
            return View();
        }
    }
}