using Microsoft.AspNetCore.Mvc;
using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Pubs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

        }
        
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<Author>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Author>>> GetAuthorsAsync()
        {
            return await _authorRepository.GetAuthorsAsync();
        }

        
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
                
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
