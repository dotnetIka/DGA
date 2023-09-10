using System;
using Domain.Entities;
using Infrastructure;
using MediatR;

namespace Application.Movies
{
	public sealed record SearchMovieByNameQuery : IRequest<Result<List<Movie>>>
	{
		public string MovieName { get; set; }
	}
}

