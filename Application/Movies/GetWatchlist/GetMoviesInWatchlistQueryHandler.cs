using System;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Application.Movies.GetWatchedMovies
{
	public class GetMoviesInWatchlistQueryHandler : IRequestHandler<GetMoviesInWatchlistQuery, Result<List<Movie>>>
	{
        private readonly IMoviesRepository _moviesRepository;

        public GetMoviesInWatchlistQueryHandler(IMoviesRepository moviesRepository)
		{
            _moviesRepository = moviesRepository;
        }

        public async Task<Result<List<Movie>>> Handle(GetMoviesInWatchlistQuery request, CancellationToken cancellationToken)
        {
            return await _moviesRepository.GetWatchlistAsync(request.UserId);
        }
    }
}

