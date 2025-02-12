using LemonadeStand.Abstractions.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LemonadeStand.Abstractions.Extensions
{
    public static class RunMigrationsExtensions
    {
        public static void AddRunMigrationsExtensions(this IServiceCollection service, IApplicationBuilder app, IConfiguration configuration)
        {
            if (Convert.ToBoolean(configuration["RunMigrations"]))
            {
                IEnumerable<Type> tonnectProjects = RetrieveIMigratableMarkedProjectsInAssembly();
                CheckListofProjects(app, tonnectProjects);
            }
        }

        private static IEnumerable<Type> RetrieveIMigratableMarkedProjectsInAssembly()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IMigratable).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
        }

        private static void CheckListofProjects(IApplicationBuilder app, IEnumerable<Type> tonnectProjects)
        {
            foreach (var tProject in tonnectProjects)
            {
                if (tProject != null)
                {
                    ExecuteMigtration(app, tProject);
                }
            }
        }

        private static void ExecuteMigtration(IApplicationBuilder app, Type tProject)
        {
            try
            {
                var scope = app.ApplicationServices.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService(tProject) as DbContext;
                dbContext?.Database.Migrate();
            }
            catch (Exception ex)
            {

            }
        }
    }
}

