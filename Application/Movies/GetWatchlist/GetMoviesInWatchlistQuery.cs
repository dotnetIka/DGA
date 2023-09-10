using System;
using Domain.Entities;
using Infrastructure;
using MediatR;

namespace Application.Movies.GetWatchedMovies
{
	public sealed record GetMoviesInWatchlistQuery : IRequest<Result<List<Movie>>>
    {
        public int UserId { get; set; }
    }
}

