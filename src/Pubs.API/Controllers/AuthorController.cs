using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pubs.Application.DTOs;
using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Pubs.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository ??
                throw new ArgumentNullException(nameof(authorRepository));

            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet()]
        [HttpHead]
        [ProducesResponseType(typeof(List<Author>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Author>>> GetAuthorsAsync()
        {
            var authorsFromRepo = await _authorRepository.GetAuthorsAsync();

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }


        [HttpGet("{authorId:int}", Name = "GetAuthor")]
        public async Task<IActionResult> GetAuthor(int authorId)
        {
            var author = await _authorRepository.GetAuthorAsync(authorId);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(author));
        }


        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorCreationDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            var authorEntity = _mapper.Map<Author>(author);

            await _authorRepository.AddAsync(authorEntity);

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

            return CreatedAtRoute("GetAuthor", new { authorId = authorToReturn.AuthorId }, authorToReturn);
        }

        [HttpDelete("authorId:int")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            var author = await _authorRepository.GetAuthorAsync(authorId);

            if (author == null)
            {
                return NotFound();
            }

            await _authorRepository.DeleteAsync(author);

            return NoContent();
        }

        [HttpPut("{authorId:int}")]
        public async Task<IActionResult> UpdateAuthor(int authorId, Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            var authorToUpdate = await _authorRepository.GetAuthorAsync(authorId);
            if(authorToUpdate == null)
            {
                return NotFound();
            }

            await _authorRepository.UpdateAsync(author);

            return Ok();
        }


    }
}
