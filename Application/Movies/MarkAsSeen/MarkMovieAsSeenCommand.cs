using System;
using Infrastructure;
using MediatR;

namespace Application.Movies.MarkAsSeen
{
	public sealed record MarkMovieAsSeenCommand : IRequest<Result<bool>>
	{
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}

