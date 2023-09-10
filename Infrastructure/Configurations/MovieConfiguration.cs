using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
	internal sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .HasKey(m => m.MovieId);

            SeedData(builder);
        }


        private void SeedData(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(
                new Movie { MovieId = 1, Name = "The perk of being programmer" },
                new Movie { MovieId = 2, Name = "Once upon in America" },
                new Movie { MovieId = 3, Name = "Bashi Achuki" }
            );
        }
    }
}

