using System;
using MediatR;

namespace Application.Movies
{
	public sealed record SearchMovieByNameQuery : IRequest<List<string>>
	{
		public string MovieName { get; set; }
	}
}

