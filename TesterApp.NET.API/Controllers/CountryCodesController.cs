using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using TesterApp.NET.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesterApp.NET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryCodesController : ControllerBase
    {
        private readonly TesterContext _context;

        public CountryCodesController(TesterContext context)
        {
            _context = context;
        }

        //GET: api/<CountryCodesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var countryCodes = await _context.Testers.Select(t => t.CountryCode).Distinct().ToListAsync();
            return countryCodes;
        }

        // GET api/<CountryCodesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CountryCodesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<CountryCodesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CountryCodesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
