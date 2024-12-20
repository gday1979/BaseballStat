﻿namespace BaseballStat.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BaseballStat.Data.Seeding.CustomSeeder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                              new RolesSeeder(),
                              new SettingsSeeder(),
                              new AccountsSeeder(),
                              new LeagueSeeder(),
                              new TeamSeeder(),
                              new PlayerSeeder(),
                              new CategorySeeder(),
                              new PlayerStatisticSeeder(),
                              new TeamStatisticSeeder(),
                              new LeagueStatisticSeeder(),
                              new AwardTypeSeeder(),
                              new AwardSeeder(),
                              new AllTimeGreatsSeeder(),
                              new RecordTypeSeeder(),
                              new RecordSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
