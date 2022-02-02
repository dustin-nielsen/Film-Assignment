using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Film_Assignment.Models
{
    public class MovieSubmissionContext : DbContext
    {
        //Constructor
        public MovieSubmissionContext (DbContextOptions<MovieSubmissionContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );

            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    ApplicationId = 1,
                    CategoryId = 4,
                    Title = "Tangled",
                    Year = 2010,
                    Director = "Nathan Greno",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "My Fav Movie"
                },
                new MovieResponse
                {
                    ApplicationId = 2,
                    CategoryId = 1,
                    Title = "Spider-Man: Into the Spider-Verse",
                    Year = 2018,
                    Director = "Bob Persichetti",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "Can't wait for #2!"
                },
                new MovieResponse
                {
                    ApplicationId = 3,
                    CategoryId = 2,
                    Title = "Napoleon Dynamite",
                    Year = 2004,
                    Director = "Jared Hess",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Tanner",
                    Notes = ""
                }
            );
        }
    }
}
