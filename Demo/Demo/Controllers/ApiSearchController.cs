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
        public IEnumerable<MovieViewModel> Search(string term)
        {
            return MovieRepository.Search(term);
        }
    }

    public static class MovieRepository
    {
        public static IEnumerable<MovieViewModel> Search(string term)
        {
            return Movies.Where(movie => movie.IsMatch(term)).ToList();
        }

        private static List<MovieViewModel> _movies = new List<MovieViewModel>();
        private static bool _stale = true;
        private static List<MovieViewModel> Movies
        {
            get
            {
                if (!_stale) return _movies;

                string file = HttpContext.Current.Server.MapPath("~/app_data/movies.json");
                if (File.Exists(file))
                {
                    _movies = JsonConvert.DeserializeObject<List<MovieViewModel>>(File.ReadAllText(file));
                }
                else
                {
                    _movies = new List<MovieViewModel>();
                }
                _stale = false;
                return _movies;
            }
        }

        public static MovieViewModel Add(MovieViewModel movieViewModel)
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

        public static MovieViewModel Get(string movie)
        {
            return Movies.Single(m => m.Title.Equals(movie, StringComparison.InvariantCultureIgnoreCase));
        }


        public static IEnumerable<MovieViewModel> Get(int take)
        {
            return Movies.Take(take);
        }
    }
}

