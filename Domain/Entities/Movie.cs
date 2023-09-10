using System;
namespace Domain.Entities
{
	public class Movie : Entity
	{
        public int MovieId { get; set; }
        public string Name { get; set; }
        public ICollection<Watchlist> Watchlists { get; set; }
    }
}

