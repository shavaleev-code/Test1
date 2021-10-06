using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Server.Models
{
    public class MyAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Record> Records { get; set; }

        private readonly ILogger _logger = Log.CreateLogger<MyAppContext>();

        public MyAppContext()
        {
            Database.EnsureCreated();            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=Cotkav83!;database=myapp;",
                new MySqlServerVersion(new Version(8, 0, 11)));

            _logger.LogInformation("Подключение к базе данных прошло успешно");
        }
    }
}

