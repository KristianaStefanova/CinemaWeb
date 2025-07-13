using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core.Interfaces
{
    public interface IManagerService
    {
        Task<bool> ExistsByIdAsync(string? id);

        Task<bool> ExistsByUserIdAsync(string? userId);

        Task<Guid?> GetIdByUserIdAsync(string? userId);
    }
}
