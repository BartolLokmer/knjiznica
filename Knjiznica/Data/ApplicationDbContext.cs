using Knjiznica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Knjiznica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public  DbSet<Knjiga> Knjige { get; set; }
        public  DbSet<Kategorija> Kategorija { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Knjiga>().Property(f => f.Cijena).HasPrecision(10, 2);

            modelBuilder.Entity<Kategorija>().HasData(
                new Kategorija() { Id = 1, Naziv = "Mit" },
                new Kategorija() { Id = 2, Naziv = "Triler" },
                new Kategorija() { Id = 3, Naziv = "Drama" },
                new Kategorija() { Id = 4, Naziv = "Vestern" },
                new Kategorija() { Id = 5, Naziv = "Fantastika" }
                );

            modelBuilder.Entity<Knjiga>().HasData(

                new Knjiga() { Id = 1, Naziv = "Gone Girl", Autor = "Gillian Flynn", Cijena = 7.99m, DatumIzlaska = DateTime.Parse("2012-5-24"), SlikaUrl = "https://www.pluggedin.com/wp-content/uploads/2020/01/gone-girl-cover.jpg", KategorijaId = 2 },
                new Knjiga() { Id = 2, Naziv = "Divergent", Autor = "Veronica Roth", Cijena = 8.99m, DatumIzlaska = DateTime.Parse("2011-4-26"), SlikaUrl = "https://upload.wikimedia.org/wikipedia/en/f/f4/Divergent_%28book%29_by_Veronica_Roth_US_Hardcover_2011.jpg", KategorijaId = 5 },
                new Knjiga() { Id = 3, Naziv = "American Gods", Autor = "Neil Gaiman", Cijena = 9.99m, DatumIzlaska = DateTime.Parse("2001-6-19"), SlikaUrl = "https://www.dymocks.com.au/Pages/ImageHandler.ashx?q=9780755322817&w=&h=570", KategorijaId = 1 },
                new Knjiga() { Id = 4, Naziv = "The Tipping Point", Cijena = 12.99m, Autor = "Malcom Gladwell", DatumIzlaska = DateTime.Parse("2000-03-20"), SlikaUrl = "https://m.media-amazon.com/images/I/61e2z7Nz3rL.jpg", KategorijaId = 3 },
                new Knjiga() { Id = 5, Naziv = "The Hunger Games", Autor = "Suzzane Collins", Cijena = 15.99m, DatumIzlaska = DateTime.Parse("2008-9-14"), SlikaUrl = "https://m.media-amazon.com/images/I/614SwlZNtJL._AC_UF1000,1000_QL80_.jpg", KategorijaId = 5 }
                );
        }

    }
}
    
