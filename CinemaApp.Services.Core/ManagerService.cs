using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }

        public async Task<bool> ExistsByIdAsync(string? id)
        {
            bool result = false;

            if(!String.IsNullOrWhiteSpace(id))
            {
                result = await this.managerRepository
                    .GetAllAttached()
                    .AnyAsync(m => m.Id.ToString().ToLower() == id.ToLower());
            }
            return result;
        }

        public async Task<bool> ExistsByUserIdAsync(string? userId)
        {
            bool result = false;

            if (!String.IsNullOrWhiteSpace(userId))
            {
                result = await this.managerRepository
                    .GetAllAttached()
                    .AnyAsync(m => m.UserId.ToString().ToLower() == userId.ToLower());
            }
            return result;
        }

        public async Task<Guid?> GetIdByUserIdAsync(string? userId)
        {
            Guid? managerId = null;

            if (!String.IsNullOrWhiteSpace(userId))
            {
               Manager? manager = await this.managerRepository
                    .FirstOrDefaultAsync(m => m.UserId.ToString().ToLower() == userId.ToLower());

                if(manager != null)
                {
                    managerId = manager.Id;
                }
            }

            return managerId;
        }
    }
}
