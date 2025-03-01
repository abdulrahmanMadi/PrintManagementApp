using PrintManagementApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagementApp.Data
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {

            // Check if the Roles table is empty
            if (!context.Roles.Any())
            {
                context.Roles.Add(new Role { RoleName = "Admin" });
                context.Roles.Add(new Role { RoleName = "User" });
                context.SaveChanges();
            }

            // Check if the Users table is empty
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Username = "admin",
                    PasswordHash = HashPassword("admin123"), // Hash the password
                    RoleId = 1 // Admin role
                });
                context.SaveChanges();
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

