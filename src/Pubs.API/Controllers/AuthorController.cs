using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pubs.Application.DTOs;
using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pubs.API.Controllers
{
    [Route("api/authors", Name = "authorRoute")]
    [Produces("application/json", "application/xml")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper, ILogger<AuthorController> logger)
        {
            _authorRepository = authorRepository ??
                throw new ArgumentNullException(nameof(authorRepository));

            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));

            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet(Name = "GetAuthors")]
        [HttpHead]
        [ProducesResponseType(typeof(List<AuthorDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            var authorsFromRepo = await _authorRepository.GetAuthorsAsync();

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }


        [HttpGet("{authorId:int}", Name = "GetAuthor")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Author>> GetAuthor(int authorId)
        {
            var author = await _authorRepository.GetAuthorAsync(authorId);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }


        [HttpPost(Name = "CreateAuthor")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Author), StatusCodes.Status201Created)]
        public async Task<ActionResult<Author>> CreateAuthor(AuthorCreateDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            var authorEntity = _mapper.Map<Author>(author);

            var returnedEntity = await _authorRepository.AddAsync(authorEntity);

            return CreatedAtRoute("GetAuthor", new { authorId = returnedEntity.Id }, returnedEntity);
        }

        [HttpDelete("{authorId:int}", Name = "DeleteAuthor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAuthor(int authorId)
        {
            var author = await _authorRepository.GetAuthorAsync(authorId);

            if (author == null)
            {
                return NotFound();
            }

            await _authorRepository.DeleteAsync(author);

            _logger.LogInformation($"The author id:: {authorId} has been deleted.");

            return NoContent();
        }

        [HttpPut("{authorId:int}", Name = "UpdateAuthor")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Author>> UpdateAuthor(int authorId, [FromBody] AuthorUpdateDto authorUpdate)
        {
            if (authorUpdate == null)
            {
                return BadRequest();
            }

            if (authorId != authorUpdate.AuthorId)
            {
                return BadRequest("The AuthorId parameter does not match the AuthorId in the request body.");
            }

            var existingAuthor = await _authorRepository.GetAuthorAsync(authorId);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            _mapper.Map(authorUpdate, existingAuthor);

            await _authorRepository.UpdateAsync(existingAuthor);

            _logger.LogInformation($"The author id:: {authorId} has been updated.");

            return Ok(existingAuthor);
        }

        [HttpPatch("customUpdateAuthorCode/{authorId:int}", Name = "PatchUpdateAuthorCode")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Author>> PatchUpdateAuthorCode(int authorId, [FromBody] AuthorUpdateAuthorCodeDto authorUpdateDto)
        {
            if (authorUpdateDto == null)
            {
                return BadRequest();
            }

            if (authorId != authorUpdateDto.AuthorId)
            {
                return BadRequest("The AuthorId parameter does not match the AuthorId in the request body.");
            }

            var existingAuthor = await _authorRepository.GetAuthorAsync(authorId);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            _mapper.Map(authorUpdateDto, existingAuthor);

            await _authorRepository.UpdateAsync(existingAuthor);

            _logger.LogInformation($"The author id:: {authorId} has been updated. The author code is now :: {authorUpdateDto.AuthorCode}");

            return Ok(existingAuthor);
        }

        [HttpPatch("customUpdateAuthorContract/{authorId:int}", Name = "PatchUpdateAuthorContract")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Author>> PatchUpdateAuthorContract(int authorId, [FromBody] AuthorUpdateContractDto authorUpdateDto)
        {
            if (authorUpdateDto == null)
            {
                return BadRequest();
            }

            if (authorId != authorUpdateDto.AuthorId)
            {
                return BadRequest("The AuthorId parameter does not match the AuthorId in the request body.");
            }

            var existingAuthor = await _authorRepository.GetAuthorAsync(authorId);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            _mapper.Map(authorUpdateDto, existingAuthor);

            await _authorRepository.UpdateAsync(existingAuthor);

            _logger.LogInformation($"The author id:: {authorId} has been updated. The contract is :: {authorUpdateDto.Contract}");

            return Ok(existingAuthor);
        }

        [HttpOptions]
        public ActionResult GetAuthorsOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, HEAD, DELETE");
            return Ok();
        }
    }
}
