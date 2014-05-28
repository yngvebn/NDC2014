using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Demo.Controllers
{
    [RoutePrefix("api/v1")]
    public class ApiMovieController : ApiController
    {
        [Route("movie"), HttpPost]
        public IHttpActionResult Create(MovieViewModel movie)
        {
            return Created(new Uri("/api/v1/" + movie.Title, UriKind.Relative) , MovieRepository.Add(movie));
        }
    }

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

        private static List<MovieViewModel> Movies = new List<MovieViewModel>()
        {
            MovieViewModel.Create("The Matrix", "Neo is special")
        };

        public static MovieViewModel Add(MovieViewModel movieViewModel)
        {
            Movies.Add(movieViewModel);
            return movieViewModel;
        }
    }
}

