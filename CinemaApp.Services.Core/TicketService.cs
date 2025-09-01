using CinemaApp.Data.Repository;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Ticket;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Services.Core
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public async Task<IEnumerable<TicketIndexViewModel>> GetUserTicketsAsync(string? userId)
        {
            IEnumerable<TicketIndexViewModel> userTickets = new List<TicketIndexViewModel>();
            if (!String.IsNullOrEmpty(userId))
            {
                userTickets = await this.ticketRepository
                    .GetAllAttached()
                    .Where(t => t.UserId.ToString().ToLower() == userId.ToString().ToLower())
                    .Select(t => new TicketIndexViewModel()
                    {
                        MovieTitle = t.CinemaMovieProjection.Movie.Title,
                        MovieImageUrl = t.CinemaMovieProjection.Movie.ImageUrl ?? $"/images/{NoImageUrl}",
                        CinemaName = t.CinemaMovieProjection.Cinema.Name,
                        Showtime = t.CinemaMovieProjection.Showtime,
                        TicketCount = t.Quantity,
                        TicketPrice = t.Price.ToString("F2"),
                        TotalPrice = (t.Price * t.Quantity).ToString("F2"),
                    })
                    .ToArrayAsync();
            }
            return userTickets;
        }
    }
}
