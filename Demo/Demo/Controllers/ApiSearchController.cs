using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace Demo.Controllers
{
    [RoutePrefix("api/v1")]
    public class ApiSearchController : ApiController
    {

        [Route("search"), HttpGet]
        public IEnumerable<dynamic> Search(string term)
        {
            return MovieRepository.Search(term);
        }
    }

    public static class MovieRepository
    {
        public static IEnumerable<dynamic> Search(string term)
        {
            term = term.ToUpper();
            List<dynamic> objects = Movies.Where(movie => movie.title.ToString().ToUpper().Contains(term) ||
                                                 movie.description.ToString().ToUpper().Contains(term)
                ).ToList();
            return objects;
        }

        private static List<dynamic> _movies = new List<dynamic>();
        private static bool _stale = true;
        private static IEnumerable<dynamic> Movies
        {
            get
            {
                if (!_stale) return _movies;

                string file = HttpContext.Current.Server.MapPath("~/app_data/movies.json");
                if (File.Exists(file))
                {
                    _movies = JsonConvert.DeserializeObject<List<dynamic>>(File.ReadAllText(file));
                }
                else
                {
                    _movies = new List<dynamic>();
                }
                _stale = false;
                return _movies;
            }
        }

        public static dynamic Add(dynamic movieViewModel)
        {
            _movies.Add(movieViewModel);
            Commit();
            return movieViewModel;
        }

        private static void Commit()
        {
            string file = HttpContext.Current.Server.MapPath("~/app_data/movies.json");

            if (!File.Exists(file))
            {
                using (File.Create(file)) { };
            }
            File.WriteAllText(file, JsonConvert.SerializeObject(_movies));

            _stale = true;
        }

        public static dynamic Get(string movie)
        {
            return Movies.Single(m => m.title.ToString().Equals(movie, StringComparison.InvariantCultureIgnoreCase));
        }


        public static IEnumerable<dynamic> Get(int take)
        {
            return Movies.Take(take);
        }
    }
}

