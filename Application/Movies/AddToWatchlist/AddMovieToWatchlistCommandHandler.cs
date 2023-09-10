using System;
using Application.Movies.GetWatchedMovies;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Application.Movies.AddMovieToWatchlist
{
	internal sealed class AddMovieToWatchlistCommandHandler : IRequestHandler<AddMovieToWatchlistCommand, Result<bool>>
	{
        private readonly IMoviesRepository _moviesRepository;
        private readonly IValidator<AddMovieToWatchlistCommand> _validator;

        public AddMovieToWatchlistCommandHandler(IMoviesRepository moviesRepository, IValidator<AddMovieToWatchlistCommand> validator)
		{
            _moviesRepository = moviesRepository;
            _validator = validator;
        }

        public async Task<Result<bool>> Handle(AddMovieToWatchlistCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return Result<bool>.ErrorResult(400, "Validation failed.").WithErrors(errorMessages);
            }

            return await _moviesRepository.AddToWatchListAsync(request.UserId, request.MovieId);
        }
    }
}

