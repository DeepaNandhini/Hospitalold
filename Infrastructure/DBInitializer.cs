using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DBInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public DBInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() { RoleName = "User" },
                new Role() { RoleName = "Admin" },
                new Role() { RoleName = "SuperAdmin" }
                );
        }
    }
}
