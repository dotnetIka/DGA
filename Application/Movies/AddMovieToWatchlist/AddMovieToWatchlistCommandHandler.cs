using System;
using MediatR;

namespace Application.Movies.AddMovieToWatchlist
{
	internal sealed class AddMovieToWatchlistCommandHandler : IRequestHandler<AddMovieToWatchlistCommand, bool>
	{
		public AddMovieToWatchlistCommandHandler()
		{
		}

        public Task<bool> Handle(AddMovieToWatchlistCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}

