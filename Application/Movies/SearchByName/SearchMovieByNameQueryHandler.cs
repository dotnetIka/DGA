using System;
using MediatR;

namespace Application.Movies
{
	internal sealed class SearchMovieByNameQueryHandler : IRequestHandler<SearchMovieByNameQuery, List<string>>
	{
		public SearchMovieByNameQueryHandler()
		{
		}

        public Task<List<string>> Handle(SearchMovieByNameQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

