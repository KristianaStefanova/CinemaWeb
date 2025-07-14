using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : BaseController
    {
        private readonly ICinemaService cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<UsersCinemaIndexViewModel> allCinemasUserView = await this.cinemaService
                 .GetAllCinemasUserViewAsync();

                return View(allCinemasUserView);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
            
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Program(string? id)
        {
            try
            {
                CinemaProgramViewModel? cinemaProgram = await this.cinemaService
                .GetCinemaProgramAsync(id);
                if (cinemaProgram == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return View(cinemaProgram);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
