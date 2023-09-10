using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        Task<Result<bool>> AddToWatchListAsync(int userId, int movieId, CancellationToken cancellationToken = default);
        Task<Result<bool>> MarkAsSeenAsync(int userId, int movieId, CancellationToken cancellationToken = default);
        Task<Result<List<Movie>>> SearchByNameAsync(string movieName, CancellationToken cancellationToken = default);
        Task<Result<List<Movie>>> GetWatchlistAsync(int userId, CancellationToken cancellationToken = default);
    }
}
