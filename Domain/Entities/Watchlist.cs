using System;
namespace Domain.Entities
{
	public class Watchlist : Entity
	{
        public int WatchlistId { get; set; }
        public bool IsSeen { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}

