using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
	internal sealed class WatchlistConfiguration : IEntityTypeConfiguration<Watchlist>
	{
        public void Configure(EntityTypeBuilder<Watchlist> builder)
        {
            builder
                .HasKey(w => w.WatchlistId);

            builder
                .HasOne(w => w.User)
                .WithMany(u => u.Watchlists)
                .HasForeignKey(w => w.UserId);

            builder
                .HasOne(w => w.Movie)
                .WithMany(m => m.Watchlists)
                .HasForeignKey(w => w.MovieId);
        }
    }
}

