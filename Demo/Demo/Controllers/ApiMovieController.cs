using System;
using System.Web.Http;

namespace Demo.Controllers
{
    [RoutePrefix("api/v1")]
    public class ApiMovieController : ApiController
    {
        [Route("movie"), HttpPost]
        public IHttpActionResult Create(MovieViewModel movie)
        {
            return Created(new Uri("/api/v1/" + movie.Title, UriKind.Relative), MovieRepository.Add(movie));
        }

        [Route("movies")]
        public IHttpActionResult Get(int take = 5)
        {
            return Ok(MovieRepository.Get(take));
        }

        [Route("movie/{movie}"), HttpGet]
        public IHttpActionResult Get(string movie)
        {
            return Ok(MovieRepository.Get(movie));
        }
    }
}