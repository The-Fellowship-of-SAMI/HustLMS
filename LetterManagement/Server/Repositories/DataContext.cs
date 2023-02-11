using LetterManagement.Server.Models;
using Microsoft.EntityFrameworkCore;
using LetterManagement.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LetterManagement.Server.Repositories
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Letter> Letters { get; set; }
        public DbSet<LetterTemplate> LetterTemplates { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Manager> Manager { get; set; } 

        public DbSet<Department> Departments { get; set; }  


        public string DbPath { get; }

        public DataContext(DbContextOptions options) : base(options)
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "sqlite_data1.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite($"Data Source={DbPath}");
    }
    


}
