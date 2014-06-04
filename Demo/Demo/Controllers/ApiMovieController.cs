using System;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace Demo.Controllers
{
    [RoutePrefix("api/v1")]
    public class ApiMovieController : ApiController
    {
        [Route("movie"), HttpPost]
        public IHttpActionResult Create([FromBody]JObject movie)
        {
            dynamic m = movie;
            return Created(new Uri("/api/v1/" + m.title, UriKind.Relative), MovieRepository.Add(movie.ToObject<dynamic>()));
        }

        [Route("movies")]
        public IHttpActionResult Get(int take = 0)
        {
            if (take == 0) take = int.MaxValue;
            return Ok(MovieRepository.Get(take));
        }

        [Route("movie/{movie}"), HttpGet]
        public IHttpActionResult Get(string movie)
        {
            return Ok(MovieRepository.Get(movie));
        }
    }
}