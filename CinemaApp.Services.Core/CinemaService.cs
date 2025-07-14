using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository cinemaRepository;
        public CinemaService(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }
        public async Task<IEnumerable<UsersCinemaIndexViewModel>> GetAllCinemasUserViewAsync()
        {
            IEnumerable<UsersCinemaIndexViewModel> allCinemasUsersView = await this.cinemaRepository
                .GetAllAttached()
                .Select(c => new UsersCinemaIndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Location = c.Location
                })
                .ToArrayAsync();

            return allCinemasUsersView;
        }
    }
}
