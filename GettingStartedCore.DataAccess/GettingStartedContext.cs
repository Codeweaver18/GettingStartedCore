using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GettingStartedCore.DataAccess.Entities;
using Microsoft.Extensions.Configuration;

namespace GettingStartedCore.DataAccess
{
    public class GettingStartedContext:DbContext
    {
        public GettingStartedContext(DbContextOptions options)
            :base(options)
        {
            Database.Migrate();
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Actor> Actors { get; set; }

    }
}
