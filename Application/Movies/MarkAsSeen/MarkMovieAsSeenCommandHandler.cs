using System;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Application.Movies.MarkAsSeen
{
	internal sealed class MarkMovieAsSeenCommandHandler : IRequestHandler<MarkMovieAsSeenCommand, Result<bool>>
	{
        private readonly IMoviesRepository _moviesRepository;
        private readonly IValidator<MarkMovieAsSeenCommand> _validator;

        public MarkMovieAsSeenCommandHandler(IMoviesRepository moviesRepository, IValidator<MarkMovieAsSeenCommand> validator)
		{
            _moviesRepository = moviesRepository;
            _validator = validator;
        }

        public async Task<Result<bool>> Handle(MarkMovieAsSeenCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return Result<bool>.ErrorResult(400, "Validation failed.").WithErrors(errorMessages);
            }

            return await _moviesRepository.MarkAsSeenAsync(request.UserId, request.MovieId);
        }
    }
}

