using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor_shop.Shared;


namespace Blazor_shop.Server.BAZA
{
    public class baza : DbContext
    {
        public DbSet<Artikal> Artikals { get; set; }
        public DbSet<Racun> Racuns { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ArtikalRacuni> ArtikalRacunis { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikal>().HasKey(p => p.SKU);
            modelBuilder.Entity<User>().HasKey(p => p.Username);

            modelBuilder.Entity<ArtikalRacuni>().HasKey(p => new{p.IDartikla,p.IDracuna});
            modelBuilder.Entity<ArtikalRacuni>().HasOne(p => p.artikal).WithMany(k => k.Racuni).HasForeignKey(l => l.IDartikla);
            modelBuilder.Entity<ArtikalRacuni>().HasOne(p => p.racun).WithMany(k => k.PoruceniArtikli).HasForeignKey(l => l.IDracuna);

            modelBuilder.Entity<Racun>().HasOne(p => p.Korisnik).WithMany(k => k.KolekcijaRacuna).HasForeignKey(l => l.KorisnikID); //jedan korisnik ima vise racuna

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KUN7BOB; Initial Catalog=blazorshop; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
