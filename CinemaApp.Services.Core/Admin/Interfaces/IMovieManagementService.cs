using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Admin.MovieManagement;

namespace CinemaApp.Services.Core.Admin.Interfaces
{
    public interface IMovieManagementService : IMovieService
    {
        Task<IEnumerable<MovieManagementIndexViewModel>> GetMovieManagementBoardDataAsync();

        Task<Tuple<bool, bool>> DeleteOrRestoreMovieAsync(string? id);
    }
}
