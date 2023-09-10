using System;
using Application.Movies.AddMovieToWatchlist;
using Application.Movies.MarkAsSeen;
using FluentValidation;

namespace Application.Movies.AddToWatchlist
{
	public class AddMovieToWatchlistCommandValidator : AbstractValidator<AddMovieToWatchlistCommand>
    {
		public AddMovieToWatchlistCommandValidator()
		{
            RuleFor(command => command.UserId)
                .NotEmpty().WithMessage("UserId is required.")
                .GreaterThan(0).WithMessage("UserId must be a positive integer.");

            RuleFor(command => command.MovieId)
                .NotEmpty().WithMessage("MovieId is required.")
                .GreaterThan(0).WithMessage("MovieId must be a positive integer.");
        }
	}
}

