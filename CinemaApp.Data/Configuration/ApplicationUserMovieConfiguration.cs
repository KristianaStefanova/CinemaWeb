
namespace CinemaApp.Data.Configuration
{
    using CinemaApp.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserMovieConfiguration : IEntityTypeConfiguration<ApplicationUserMovie>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMovie> entity)
        {
            // Define composite Primary Key of the mapping entity
            entity.HasKey(aum => new { aum.ApplicationUserId, aum.MovieId });

            // Define required constraintsfor the ApplicationUserId, as it is type string.
            entity
                .Property(aum => aum.ApplicationUserId)
                .IsRequired();

            // Define defalt value for soft-delete functionality
            entity
                .Property(aum => aum.IsDeleted)
                .HasDefaultValue(false);

            // Configure relation between ApplicationUserMovie and IdentityUser
            // The IdentityUser does not contain navigation property, as it is build/in type from the ASP.NET Core Identity
            entity
                .HasOne(aum => aum.ApplicationUser)
                .WithMany()
                .HasForeignKey(aum => aum.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);


            // Configure relation between ApplicationUserMovie and Movie
            entity
                .HasOne(aum => aum.Movie)
                .WithMany(m => m.UserWatchlists)
                .HasForeignKey(aum => aum.MovieId)
                .OnDelete(DeleteBehavior.Restrict);


            // Definre query filter to hide the ApplicationUserMovie entries referring deleted Movie
            // Solves the problem with relations during delete
            entity
                .HasQueryFilter(aum => aum.Movie.IsDeleted == false);

            // Define query filter to hide the deleted entries in the user Watchlist
            entity.
                HasQueryFilter(aum => aum.IsDeleted == false);
        }
    }
}
