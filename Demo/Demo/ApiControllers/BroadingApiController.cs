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
    public class BroadingApiController : ControllerBase
    {
        private BroadingServices broadingServices;


        public BroadingApiController()
        {
            broadingServices = new BroadingServices();
        }

        [HttpGet()]
        public IEnumerable<Broading> GetAll()
        {
            return broadingServices.GetAll().ToList();
        }

        [HttpGet("{id:int}")]
        public Broading GetById(int id)
        {
            return broadingServices.GetById(id);
        }

        [HttpPost()]
        public bool Add([FromBody] Broading broading)
        {
            return broadingServices.Add(broading);
        }

    }
}