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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    ApplicationId = 1,
                    Category = "Musical/Adventure/Comedy",
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
                    Category = "Superhero",
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
                    Category = "Comedy",
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
