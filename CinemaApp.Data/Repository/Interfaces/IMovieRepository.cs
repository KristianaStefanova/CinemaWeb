﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data.Models;

namespace CinemaApp.Data.Repository.Interfaces
{
    public interface IMovieRepository 
        : IRepository<Movie, Guid>, IAsyncRepository<Movie, Guid>
    {
    }
}
