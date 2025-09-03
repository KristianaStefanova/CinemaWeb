using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core
{
    public class ProjectionService : IProjectionService
    {
        private readonly ICinemaMovieRepository cinemaMovieRepository;

        public ProjectionService(ICinemaMovieRepository cinemaMovieRepository)
        {
            this.cinemaMovieRepository = cinemaMovieRepository;
        }

        public async Task<int> GetAvailableTicketsCountAsync(string? cinemaId, string? movieId, string? showtime)
        {
            int avalibleTicketCount = 0;
            if (!String.IsNullOrWhiteSpace(cinemaId) &&
               !String.IsNullOrWhiteSpace(movieId) &&
               !String.IsNullOrWhiteSpace(showtime))
            {
                CinemaMovie? projection = await this.cinemaMovieRepository
                    .SingleOrDefaultAsync(cm => cm.CinemaId.ToString().ToLower() == cinemaId.ToString().ToLower() &&
                                           cm.MovieId.ToString().ToLower() == movieId.ToString().ToLower() &&
                                           cm.Showtime.ToLower() == showtime.ToLower());

                if (projection != null)
                {
                    avalibleTicketCount = projection.AvailableTickets;
                }
            }
            
            return avalibleTicketCount;
        }

        public async Task<IEnumerable<string>> GetProjectionShowtimesAsync(string? cinemaId, string? movieId)
        {
            IEnumerable<string> showtimes = new List<string>();
            if (!String.IsNullOrWhiteSpace(cinemaId) &&
               !String.IsNullOrWhiteSpace(movieId))
            {
                showtimes = await this.cinemaMovieRepository
                    .GetAllAttached()
                    .Where(cm => cm.CinemaId.ToString().ToLower() == cinemaId.ToString().ToLower() &&
                                 cm.MovieId.ToString().ToLower() == movieId.ToString().ToLower())
                    .Select(cm => cm.Showtime)
                    .ToArrayAsync();
            }

            return showtimes;
        }
    }
}
