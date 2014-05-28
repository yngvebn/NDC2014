using System.Web.Mvc;

namespace Demo.Controllers
{
    [System.Web.Mvc.RoutePrefix("Search")]
    public class SearchController: Controller
    {

        [System.Web.Mvc.Route]
        public ActionResult Search(string q)
        {
            return View((object)q);
        }
         
    }
}