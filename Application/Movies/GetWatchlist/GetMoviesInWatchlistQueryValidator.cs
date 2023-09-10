using System;
using Application.Movies.AddMovieToWatchlist;
using Application.Movies.GetWatchedMovies;
using FluentValidation;

namespace Application.Movies.GetWatchlist
{
	public class GetMoviesInWatchlistQueryValidator : AbstractValidator<GetMoviesInWatchlistQuery>
    {
		public GetMoviesInWatchlistQueryValidator()
		{
            RuleFor(command => command.UserId)
               .NotEmpty().WithMessage("UserId is required.")
               .GreaterThan(0).WithMessage("UserId must be a positive integer.");
        }
	}
}

