﻿using CinemaApp.Services.Core.Interfaces;
using CinemaApp.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CinameApp.WebApi.Controllers
{
    public class CinemaMovieApiController : BaseExternalApiController
    {
        private readonly IProjectionService projectionService;

        public CinemaMovieApiController(IProjectionService projectionService)
        {
            this.projectionService = projectionService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Showtimes")]
        public async Task<ActionResult<IEnumerable<string>>> GetProjectionShowtimes([Required] string cinemaId, [Required] string movieId)
        {
            IEnumerable<string> showtimes = await this.projectionService
                .GetProjectionShowtimesAsync(cinemaId, movieId);

            return this.Ok(showtimes);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("AvailableTickets")]
        public async Task<ActionResult<int>> GetAvailableTickets([Required] string cinemaId,
            [Required] string movieId, [Required] string showtime)
        {
            int availableTickets = await this.projectionService
                .GetAvailableTicketsCountAsync(cinemaId, movieId, showtime);

            return this.Ok(availableTickets);
        }
    }
}
