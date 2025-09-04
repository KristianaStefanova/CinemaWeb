using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Manager? Manager { get; set; }

        public virtual ICollection<ApplicationUserMovie> WatchlistMovies { get; set; }
            = new HashSet<ApplicationUserMovie>();

        public virtual ICollection<Ticket> Tickets { get; set; }
            = new HashSet<Ticket>();
    }   
}
