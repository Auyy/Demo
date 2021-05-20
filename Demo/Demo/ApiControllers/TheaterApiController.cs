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
    public class TheaterApiController : ControllerBase
    {
        private TheaterServices theaterServices;


        public TheaterApiController()
        {
            theaterServices = new TheaterServices();
        }

        [HttpGet()]
        public IEnumerable<Theater> GetAll()
        {
            return theaterServices.GetAll().ToList();
        }

        [HttpGet("{id:int}")]
        public Theater GetById(int id)
        {
            return theaterServices.GetById(id);
        }

        [HttpPost()]
        public bool Add([FromBody] Theater theater)
        {
            return theaterServices.Add(theater);
        }

        [HttpPost("{id:int}")]
        public int Update([FromBody] Theater theater, int id)
        {
            return theaterServices.Update(theater, id);
        }

        [HttpDelete("{id:int}")]
        public Theater Delete(int id)
        {
            return theaterServices.Delete(id);
        }

    }
}
