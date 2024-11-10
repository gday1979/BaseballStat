﻿namespace BaseballStat.Services.Data.League
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BaseballStat.Data.Common.Repositories;
    using BaseballStat.Data.Models;
    using BaseballStat.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class LeagueService : ILeagueService
    {
        private readonly IRepository<League> leaguesRepository;

        public LeagueService(IRepository<League> leaguesRepository)
        {
            this.leaguesRepository = leaguesRepository;
        }

        public async Task<IEnumerable<T>> GetAllLeaguesAsync<T>(int? count = null)
        {
            IQueryable<League> query = this.leaguesRepository
                .All()
                .OrderBy(x => x.Id);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return await query.To<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var league = this.leaguesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
            return await Task.FromResult(league);
        }
    }
}