using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace MovieRancor.Models
{
    public enum role { banned, user, moderator, admin, developer };
    public enum workerRole { actor, director, writer };
    public enum CategoryType { Genre, Series, Other }

    //The u
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<MovieWorker> Workers { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
    //Allows the movie to pull the actors rather than hard coding them in there, also allows search by actors if that is to be added later
    public class MovieWorker
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public workerRole Role { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual ApplicationUser Reviewer { get; set; }
        public virtual Score Score { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual ApplicationUser Commenter { get; set; }
        public virtual Review Review { get; set; }
    }

    public class Score
    {
        [Key]
        public int Id { get; set; }
        [Range(1, 5)]
        public int score { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }

    public class Role
    {
        [Key]
        public int UserId { get; set; }
        public role UserRole { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }

    public class List
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<Movie> movies { get; set; }
    }
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public CategoryType Type { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }

    public class MovieContext : DbContext
    {
        public MovieContext()
            : base("MovieContext")
        { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<MovieWorker> MovieWorkers { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext()
            : base("DatabaseContext", throwIfV1Schema: false)
        {
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }
}