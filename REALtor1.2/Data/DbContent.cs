using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using REALtor1._2.Data.Models;

namespace REALtor1._2.Data
{
    public class DbContent:IdentityDbContext<IdentityUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "f9e70088-f003-4dd2-ae7f-b6fd6b8239d5",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "586347a0-0208-44e2-b3cc-86138a23a89e",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "89090665177d@gmail.com",
                NormalizedEmail = "89090665177D@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "realtor1"),
                SecurityStamp = string.Empty,
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "f9e70088-f003-4dd2-ae7f-b6fd6b8239d5",
                UserId= "586347a0-0208-44e2-b3cc-86138a23a89e"
            });
        }
        public DbContent(DbContextOptions<DbContent> options):base(options)
        {

        }
        public DbSet<House> House { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}
