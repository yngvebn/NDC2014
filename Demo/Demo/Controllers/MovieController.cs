using System;
using System.Web.Mvc;
using Antlr.Runtime.Misc;

namespace Demo.Controllers
{
    [RoutePrefix("movie")]
    public class MovieController: Controller
    {
        [Route("add")]
        public ActionResult Add()
        {
            return View();
        }

        [Route("details")]
        public ActionResult Details(string movie)
        {
            return View();
        }



        [Route("poster/{movie}")]
        public ActionResult Poster(string movie)
        {
            string[] extensions = new[] {".png", ".jpg"};
            var path = new Func<string, string, string>((name, ext) =>
            {
                var fileName = Server.MapPath("~/app_data/posters/" + name + ext);
                return fileName;
            });
            foreach (var extension in extensions)
            {
                var filename = path(movie, extension);
                if (System.IO.File.Exists(filename))
                {
                    return base.File(filename, "image/png");
                }
            }
            return null;
        }
    }
}