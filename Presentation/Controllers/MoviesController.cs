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
            var success = await _mediator.Send(command);
            if (success)
            {
                return Ok("Movie added to watchlist successfully.");
            }
            return BadRequest("Failed to add the movie to the watchlist.");
        }

        [HttpPost("mark-as-seen")]
        public async Task<IActionResult> MarkAsSeen(MarkMovieAsSeenCommand command)
        {
            var success = await _mediator.Send(command);
            if (success)
            {
                return Ok("Movie marked as seen successfully.");
            }
            return BadRequest("Failed to mark the movie as seen.");
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchMovieByNameQuery query)
        {
            var movies = await _mediator.Send(query);
            return Ok(movies);
        }

        [HttpGet("watchlist")]
        public async Task<IActionResult> GetWatchlist([FromQuery] GetMoviesInWatchlistQuery query)
        {
            var movies = await _mediator.Send(query);
            return Ok(movies);
        }
    }
}
