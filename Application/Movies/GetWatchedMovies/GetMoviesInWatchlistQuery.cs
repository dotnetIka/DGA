using System;
using MediatR;

namespace Application.Movies.GetWatchedMovies
{
	public sealed record GetMoviesInWatchlistQuery : IRequest<List<string>>
    {
        public int UserId { get; set; }
    }
}

