using CinemaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repository.Interfaces
{
    internal interface ITicketRepository
        : IRepository<Ticket, Guid>, IAsyncRepository<Ticket, Guid>
    {
    }
}
