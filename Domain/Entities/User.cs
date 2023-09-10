using System;
namespace Domain.Entities
{
	public class User : Entity
	{
        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Watchlist> Watchlists { get; set; }
    }
}

