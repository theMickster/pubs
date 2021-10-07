using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pubs.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pubs.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Pubs.API.Controllers
{
    [Route("api/authors/{authorId}/titles", Name ="authorTitlesRoute")]
    [Produces("application/json", "application/xml")]
    [ApiController]
    public class AuthorTitlesController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorTitlesController> _logger;

        public AuthorTitlesController(IAuthorRepository authorRepository, IMapper mapper, ILogger<AuthorTitlesController> logger)
        {
            _authorRepository = authorRepository ??
                throw new ArgumentNullException(nameof(authorRepository));

            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));

            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        [HttpHead]
        [HttpGet(Name = "GetTitlesForAuthor")]
        [ProducesResponseType(typeof(List<AuthorTitleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<AuthorTitleDto>>> GetTitlesForAuthor(int authorId)
        {
            if (!_authorRepository.IsAuthorValid(authorId))
            {
                return NotFound();
            }

            var authorAndTitles = await _authorRepository.GetTitlesForAuthorAsync(authorId);

            return Ok(_mapper.Map<List<AuthorTitleDto>>(authorAndTitles));
        }

    }
}
