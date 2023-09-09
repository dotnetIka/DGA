using System;
using MediatR;

namespace Application.Movies.MarkAsSeen
{
	public sealed record MarkMovieAsSeenCommand : IRequest<bool>
	{
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}

