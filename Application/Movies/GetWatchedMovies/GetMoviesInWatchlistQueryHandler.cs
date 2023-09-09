using System;
using MediatR;

namespace Application.Movies.GetWatchedMovies
{
	public class GetMoviesInWatchlistQueryHandler : IRequestHandler<GetMoviesInWatchlistQuery, List<string>>
	{
		public GetMoviesInWatchlistQueryHandler()
		{
		}

        public Task<List<string>> Handle(GetMoviesInWatchlistQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

