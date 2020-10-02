using BandApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BandApi.DContexts
{
    public class BandAlbumContext : DbContext
    {
        public BandAlbumContext(DbContextOptions<BandAlbumContext> options) : base(options)
        {

        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(new Band
            {
                Id = Guid.Parse("38e324f7-256b-40e8-a55a-a9882f5ed342"),
                Name = "Cairokee",
                Founded = new DateTime(2003, 1, 1),
                MainGenre = "Rock"
            });
            modelBuilder.Entity<Album>().HasData(new Album
            {
                Id = Guid.NewGuid(),
                Title = "The Ugly Duck",
                Description = "The best Album ever",
                ReleaseDate = new DateTime(2019, 1, 1),
                BandId = Guid.Parse("38e324f7-256b-40e8-a55a-a9882f5ed342")
            });
            modelBuilder.Entity<Album>().HasData(new Album
            {
                Id = Guid.NewGuid(),
                Title = "White Point",
                Description = "The second best Album ever",
                ReleaseDate = new DateTime(2017, 1, 1),
                BandId = Guid.Parse("38e324f7-256b-40e8-a55a-a9882f5ed342")
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
