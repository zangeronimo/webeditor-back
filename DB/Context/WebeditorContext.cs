using Domain.Models.Webeditor;
using Microsoft.EntityFrameworkCore;

namespace DB.Context
{
    public class WebeditorContext: DbContext
    {
        public WebeditorContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Users> Users {get;set;}
    }
}