using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySharedIncomes.Data
{
    public class DbSeeder
    {
        private ApplicationDbContext DbContext;

        public DbSeeder(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            DbContext.Database.EnsureCreated();
            if (await DbContext.Users.CountAsync() == 0) CreateUsers();            
        }

        private void CreateUsers()
        {
            DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;

            var user_Admin = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Email = "admin@incomes.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            DbContext.Users.Add(user_Admin);
            DbContext.SaveChanges();
        }
    }
}
