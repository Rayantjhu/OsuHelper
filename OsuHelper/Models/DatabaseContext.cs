using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace OsuHelper.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<OsuReplay>? Replays { get; set; }

        public string DatabasePath
        {
            get
            { 
                return Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OsuHelperData");
            }
        }

        public DatabaseContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // If the directory doesn't exist, create it
            if (!Directory.Exists(DatabasePath))
                Directory.CreateDirectory(DatabasePath);
            options.UseSqlite($"Data Source={DatabasePath}\\database.db");
        }
    }
}
