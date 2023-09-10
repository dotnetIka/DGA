using System;
using Application.Movies.MarkAsSeen;
using FluentValidation;

namespace Application.Movies.SearchByName
{
	public class SearchMovieByNameQueryValidator : AbstractValidator<SearchMovieByNameQuery>
    {
		public SearchMovieByNameQueryValidator()
		{
            RuleFor(input => input)
                .NotEmpty().WithMessage("The input string cannot be empty.");
        }
	}
}

