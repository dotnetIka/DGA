using System;
using Infrastructure;
using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Application.Movies.AddMovieToWatchlist
{
	internal sealed class AddMovieToWatchlistCommandHandler : IRequestHandler<AddMovieToWatchlistCommand, Result<bool>>
	{
        private readonly IMoviesRepository _moviesRepository;

        public AddMovieToWatchlistCommandHandler(IMoviesRepository moviesRepository)
		{
            _moviesRepository = moviesRepository;
        }

        public async Task<Result<bool>> Handle(AddMovieToWatchlistCommand request, CancellationToken cancellationToken)
        {

            return await _moviesRepository.AddToWatchListAsync(request.UserId, request.MovieId);
        }
    }
}

