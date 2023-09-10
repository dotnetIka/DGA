using System;
using Infrastructure;
using MediatR;

namespace Application.Movies.AddMovieToWatchlist
{
	public sealed record AddMovieToWatchlistCommand : IRequest<Result<bool>>
	{
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}

