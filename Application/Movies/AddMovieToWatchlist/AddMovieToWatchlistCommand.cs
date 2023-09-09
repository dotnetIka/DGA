using System;
using MediatR;

namespace Application.Movies.AddMovieToWatchlist
{
	public sealed record AddMovieToWatchlistCommand : IRequest<bool>
	{
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}

