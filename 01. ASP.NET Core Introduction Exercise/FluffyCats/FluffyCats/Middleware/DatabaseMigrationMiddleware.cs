﻿namespace FluffyCats.Middleware
{
    using FluffyCats.Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public class DatabaseMigrationMiddleware
    {
        private readonly RequestDelegate next;

        public DatabaseMigrationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.RequestServices.GetRequiredService<CatsDbContext>().Database.Migrate();

            return this.next(context);
        }
    }
}