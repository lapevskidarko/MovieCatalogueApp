using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieWebApp.Models.Domain;

namespace MovieWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }
        public virtual DbSet<MoviePerson> MoviePerson { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Genre>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Person>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Role>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<MovieGenre>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Genres)
                .HasForeignKey(x => x.MovieId);

            builder.Entity<MoviePerson>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.People)
                .HasForeignKey(x => x.MovieId);

            builder.Entity<UserRole>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.PersonId);

            builder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Comedy"},
                new Genre { Id = 3, Name = "Horor"}
                );

            builder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Actor" },
                new Role { Id = 2, Name = "Director" },
                new Role { Id = 3, Name = "Producer" }
                );

            builder.Entity<Person>().HasData(
                new Person { Id = 1, FullName = "Jon Favreau" },
                new Person { Id = 2, FullName = "Robert Downey Jr." },
                new Person { Id = 3, FullName = "Kevin Feige" }
                );
            builder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, PersonId = 1, RoleId = 2 },
                new UserRole { Id = 2, PersonId = 2, RoleId = 1 },
                new UserRole { Id = 3, PersonId = 3, RoleId = 2 },
                new UserRole { Id = 4, PersonId = 1, RoleId = 3 }
                );


        }
    }
}