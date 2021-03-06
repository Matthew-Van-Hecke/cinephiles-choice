﻿using CinephilesChoiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Contracts
{
    public interface IMoviegoerRepository : IRepositoryBase<Moviegoer>
    {
        IQueryable<Moviegoer> GetAllMoviegoers();
        Moviegoer GetMoviegoerById(int id);
        Moviegoer GetMoviegoerByIdentityUserId(string identityUserId);
    }
}
