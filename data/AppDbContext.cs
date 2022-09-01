using Microsoft.EntityFrameworkCore;
using BinlistApiWrapper.data.entities;

namespace BinlistApiWrapper.data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public DbSet<UserTask> UserTasks { get; set; }
    }
}