using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CinemaApp.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ProjectionType> ProjectionTypes { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", t => t.ExcludeFromMigrations());*/

            // Configure the foreign key between Projections and Theaters
            modelBuilder.Entity<Projection>()
                .HasOne(p => p.Theater)
                .WithMany()
                .HasForeignKey(p => p.TheaterId)
                .OnDelete(DeleteBehavior.Restrict);// Specify ON DELETE RESTRICT

            modelBuilder.Entity<ApplicationUser>().HasData(
       new ApplicationUser
       {
           Id = "1",
           UserName = "admin1",
           NormalizedUserName = "ADMIN1",
           Email = "admin1@example.com",
           NormalizedEmail = "ADMIN1@EXAMPLE.COM",
           EmailConfirmed = true,
           PasswordHash = "AQAAAAEAACcQAAAAEBUxA0d/A3X8Q3QfYkAAAAAO5BZ0AICgWZk=" // Use a proper hashed password
       },
       new ApplicationUser
       {
           Id = "2",
           UserName = "admin2",
           NormalizedUserName = "ADMIN2",
           Email = "admin2@example.com",
           NormalizedEmail = "ADMIN2@EXAMPLE.COM",
           EmailConfirmed = true,
           PasswordHash = "AQAAAAEAACcQAAAAEBUxA0d/A3X8Q3QfYkAAAAAO5BZ0AICgWZk=" // Use a proper hashed password
       }
     );

            // Configure the foreign key between Projections and ProjectionTypes
            modelBuilder.Entity<Projection>()
                .HasOne(p => p.ProjectionType)
                .WithMany()
                .HasForeignKey(p => p.ProjectionTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Specify ON DELETE RESTRICT

            // Configure the foreign key between Projections and Movies
            modelBuilder.Entity<Projection>()
                .HasOne(p => p.Movie)
                .WithMany()
                .HasForeignKey(p => p.MovieId)
                .OnDelete(DeleteBehavior.Restrict); // Specify ON DELETE RESTRICT

            modelBuilder.Entity<Projection>()
                 .HasOne(p => p.Administrator)
                 .WithMany()
                 .HasForeignKey(p => p.AdministratorId)
                 .OnDelete(DeleteBehavior.Cascade);

            // Configure the foreign key between Tickets and Projections
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Projection)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.ProjectionId)
                .OnDelete(DeleteBehavior.Cascade); // Specify ON DELETE RESTRICT

            // Configure the foreign key between Tickets and Seats
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Seat)
                .WithMany()
                .HasForeignKey(t => t.SeatId)
                .OnDelete(DeleteBehavior.Restrict); // Specify ON DELETE RESTRICT

            // Configure the foreign key between Tickets and Users
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Specify ON DELETE RESTRICT

           // modelBuilder.Entity<Projection>().Ignore(p => p.Theater);

            modelBuilder.Entity<ProjectionType>().HasData(
                new ProjectionType() { Id = 1, Type = ProjectionTypeEnum.TwoD },
                new ProjectionType() { Id = 2, Type = ProjectionTypeEnum.ThreeD },
                new ProjectionType() { Id = 3, Type = ProjectionTypeEnum.FourD }
            );

            modelBuilder.Entity<Theater>().HasData(
                new Theater() { Id = 1, Capacity = 100, Type = TheaterEnum.MovieHouse },
                new Theater() { Id = 2, Capacity = 150, Type = TheaterEnum.TheaterHall },
                new Theater() { Id = 3, Capacity = 200, Type = TheaterEnum.PictureDream }
            );

            var seats = new List<Seat>();
            var theaters = new List<Theater>
            {
                new Theater { Id = 1, Capacity = 100 },
                new Theater { Id = 2, Capacity = 150 },
                new Theater { Id = 3, Capacity = 200 }
            };

            foreach (var theater in theaters)
            {
                for (int seatNumber = 1; seatNumber <= theater.Capacity; seatNumber++)
                {
                    seats.Add(new Seat { Id = (theater.Id - 1) * 200 + seatNumber, Number = seatNumber, TheaterId = theater.Id });
                }
            }
            modelBuilder.Entity<Seat>().HasData(seats);

            /*modelBuilder.Entity<Seat>().HasData(
                new Seat() { Id = 11, Number = 1, TheaterId = 1 },
                new Seat() { Id = 12, Number = 12, TheaterId = 2 },
                new Seat() { Id = 13, Number = 31, TheaterId = 3 }
            );*/

            modelBuilder.Entity<Movie>().HasData(
                new Movie() { Id = 1, Title = "Pulp Fiction", Director = "Quentin Tarantino", Actors = "Bruce Willis, Uma Thurman", Genre = "Crime Story", Duration = 150, Distributor = "Miramax", CountryOrigin = "USA", Description = "Exciting crime drama", ReleaseYear = 1994 },
                new Movie() { Id = 2, Title = "2001: A Space Odyssey", Director = "Stanley Kubrick", Actors = "Keir Dullea, Gary Lockwood", Genre = "Sci-fi/Adventure", Duration = 149, Distributor = "Warner Bros", CountryOrigin = "USA", Description = "Experiment in film form and content", ReleaseYear = 1968 }
            );

            modelBuilder.Entity<Projection>().HasData(
                new Projection() { Id = 1, MovieId = 1, ProjectionTypeId = 2, TheaterId = 1, DateTime = DateTime.Now, Price = 500, AdministratorId = "1" },
                new Projection() { Id = 2, MovieId = 2, ProjectionTypeId = 3, TheaterId = 2, DateTime = DateTime.Now, Price = 500, AdministratorId = "2" }
            );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket() { Id = 1, ProjectionId = 1, SeatId = 1, SaleDateTime = DateTime.Now, UserId = "1" },
                new Ticket() { Id = 2, ProjectionId = 2, SeatId = 2, SaleDateTime = DateTime.Now, UserId = "2" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
