using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitOfWork _uof;

        public MoviesRepository(ApplicationDbContext dbContext, IUnitOfWork uof)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _uof = uof;
        }

        public async Task<Result<bool>> AddToWatchListAsync(int userId, int movieId, CancellationToken cancellationToken = default)
        {
            var user = await _dbContext.Users.Include(u => u.Watchlists).FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
            if (user == null)
            {
                return Result<bool>.ErrorResult(404, "User not found");
            }

            var movie = await _dbContext.Movies.FindAsync(movieId);
            if (movie == null)
            {
                return Result<bool>.ErrorResult(404, "Movie not found");
            }

            if (user.Watchlists.Any(w => w.MovieId == movieId))
            {
                return Result<bool>.ErrorResult(400, "Movie is already in the watchlist");
            }

            var watchlistEntry = new Watchlist
            {
                UserId = userId,
                MovieId = movieId
            };

            user.Watchlists.Add(watchlistEntry);
            await _uof.SaveChangesAsync(cancellationToken);

            return Result<bool>.SuccessResult(true);
        }

        public async Task<Result<List<Movie>>> GetWatchlistAsync(int userId, CancellationToken cancellationToken = default)
        {
            var movies = await _dbContext.Watchlists.Include(m => m.Movie).Where(w => w.UserId == userId).Select(m => m.Movie).ToListAsync();
            if (movies.Any())
            {
                return Result<List<Movie>>.SuccessResult(movies);
            }
            else
            {
                return Result<List<Movie>>.ErrorResult(404, "No movies found with the given name.");
            }
        }

        public async Task<Result<bool>> MarkAsSeenAsync(int userId, int movieId, CancellationToken cancellationToken = default)
        {
            var user = await _dbContext.Users.Include(u => u.Watchlists).FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
            if (user == null)
            {
                return Result<bool>.ErrorResult(404, "User not found");
            }

            var watchlistEntry = user.Watchlists.FirstOrDefault(w => w.MovieId == movieId);
            if (watchlistEntry == null)
            {
                return Result<bool>.ErrorResult(404, "Movie not found in the user's watchlist");
            }

            watchlistEntry.IsSeen = true;
            watchlistEntry.UpdateDate = DateTime.UtcNow;

            await _uof.SaveChangesAsync(cancellationToken);

            return Result<bool>.SuccessResult(true);
        }

        public async Task<Result<List<Movie>>> SearchByNameAsync(string movieName, CancellationToken cancellationToken = default)
        {
            var movies = await _dbContext.Movies.Where(m => m.Name == movieName).ToListAsync(cancellationToken);
            if (movies.Any())
            {
                return Result<List<Movie>>.SuccessResult(movies);
            }
            else
            {
                return Result<List<Movie>>.ErrorResult(404, "No movies found with the given name.");
            }
        }
    }
}
