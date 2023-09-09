using System;
using MediatR;

namespace Application.Movies.MarkAsSeen
{
	internal sealed class MarkMovieAsSeenCommandHandler : IRequestHandler<MarkMovieAsSeenCommand, bool>
	{
		public MarkMovieAsSeenCommandHandler()
		{
		}

        public Task<bool> Handle(MarkMovieAsSeenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

