using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Admin.CinemaManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core.Admin.Interfaces
{
    public interface ICinemaManagementService : ICinemaService
    {
        Task<IEnumerable<CinemaManagementIndexViewModel>> GetCinemaManagementBoardDataAsync();

        Task<bool> AddCinemaAsync(CinemaManagementAddFormModel? inputModel);

        Task<CinemaManagementEditFormModel?> GetCinemaEditFormModelAsync(string? id);

        Task<bool> EditCinemaAsync(CinemaManagementEditFormModel? inputModel);

        Task<Tuple<bool, bool>> DeleteOrRestoreCinemaAsync(string? id);
    }
}
