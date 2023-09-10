using System;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Application.Movies
{
	internal sealed class SearchMovieByNameQueryHandler : IRequestHandler<SearchMovieByNameQuery, Result<List<Movie>>>
	{
        private readonly IMoviesRepository _moviesRepository;

        public SearchMovieByNameQueryHandler(IMoviesRepository moviesRepository)
		{
            _moviesRepository = moviesRepository;
        }

        public async Task<Result<List<Movie>>> Handle(SearchMovieByNameQuery request, CancellationToken cancellationToken)
        {
            return await _moviesRepository.SearchByNameAsync(request.MovieName);
        }
    }
}

