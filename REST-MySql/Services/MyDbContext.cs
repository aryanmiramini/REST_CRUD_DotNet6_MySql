using Microsoft.EntityFrameworkCore;
using REST_MySql.Models;
using System.Configuration;

namespace REST_MySql.Services
{
    public class MyDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public MyDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .ToTable("BookS");           
         
            modelBuilder.Entity<Book>()
                .HasData(
                    new Book
                    {
                        Id = 1,
                       Title  = "Test1",
                        Language = "Persian",
                        Author ="Injaneb",
                        BookMaterial = Book.Material.E_Book

                    },
                    new Book
                    {
                        Id=2,
                        Title = "Test3",
                        Language = "English",
                        Author = "NotInjaneb",
                        BookMaterial = Book.Material.PaperEdition


                    }, new Book
                    {
                        Id=3,
                        Title = "Test4",
                        Language = "English",
                        Author = "NotInjaneb",
                        BookMaterial = Book.Material.E_Book
                    }, new Book
                    {
                        Id=4,
                        Title = "Test5",
                        Language = "Arabic",
                        Author = "Arabdude",
                        BookMaterial = Book.Material.E_Book
                    }
                );
        }


        public DbSet<Book> Books { get; set; }


    }
}
