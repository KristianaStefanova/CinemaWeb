using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repository
{
    public class ManagerRepository : BaseRepository<Manager, Guid>, IManagerRepository
    {
        public ManagerRepository(CinemaAppDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
