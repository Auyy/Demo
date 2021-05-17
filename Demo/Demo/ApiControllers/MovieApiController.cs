using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {

        private MovieServices movieServices;


        public MovieApiController()
        {
            movieServices = new MovieServices();          
        }

        [HttpGet()]
        public IEnumerable<Movie> GetAll()
        {
            return movieServices.GetAll().ToList();
        }

        [HttpGet("{id:int}")]
        public Movie GetById(int id)
        {
            return movieServices.GetById(id);
        }
        [HttpPost()]
        public bool Add([FromBody] Movie movie)
        {
            return movieServices.Add(movie);
        }



    }
}
