using System;
using Application.Movies.MarkAsSeen;
using Domain.Entities;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Application.Movies
{
	internal sealed class SearchMovieByNameQueryHandler : IRequestHandler<SearchMovieByNameQuery, Result<List<Movie>>>
	{
        private readonly IMoviesRepository _moviesRepository;
        private readonly IValidator<SearchMovieByNameQuery> _validator;

        public SearchMovieByNameQueryHandler(IMoviesRepository moviesRepository, IValidator<SearchMovieByNameQuery> validator)
		{
            _moviesRepository = moviesRepository;
            _validator = validator;
        }

        public async Task<Result<List<Movie>>> Handle(SearchMovieByNameQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return Result<List<Movie>>.ErrorResult(400, "Validation failed.").WithErrors(errorMessages);
            }

            return await _moviesRepository.SearchByNameAsync(request.MovieName);
        }
    }
}

