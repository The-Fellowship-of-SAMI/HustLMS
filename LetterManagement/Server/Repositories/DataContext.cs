using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using LetterManagement.Server.Models;

namespace LetterManagement.Server.Repositories
{
    public class DataContext : DbContext
    {
        public DbSet<Letter> Letters { get; set; }
        public DbSet<LetterTemplate> LetterTemplates { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Manager> Manager { get; set; } 

        public DbSet<Department> Departments { get; set; }  


        public string DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "sqlite_data.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

}
