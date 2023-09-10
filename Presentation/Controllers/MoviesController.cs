using System;
using System.Runtime.InteropServices;
using Application.Movies;
using Application.Movies.AddMovieToWatchlist;
using Application.Movies.GetWatchedMovies;
using Application.Movies.MarkAsSeen;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-to-watchlist")]
        public async Task<IActionResult> AddToWatchlist(AddMovieToWatchlistCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("mark-as-seen")]
        public async Task<IActionResult> MarkAsSeen(MarkMovieAsSeenCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchMovieByNameQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("watchlist")]
        public async Task<IActionResult> GetWatchlist([FromQuery] GetMoviesInWatchlistQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
