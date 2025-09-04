using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Ticket
{
    public class BuyTicketInputModel
    {
        [Required]
        public string CinemaId { get; set; } = null!;

        [Required]
        public string MovieId { get; set; } = null!;

        public int Quantity { get; set; }

        [Required]
        public string Showtime { get; set; } = null!;
    }
}
