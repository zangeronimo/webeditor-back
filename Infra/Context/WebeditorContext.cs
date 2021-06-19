using Domain.Models.Webeditor;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class WebeditorContext: DbContext
    {
        public WebeditorContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<User> Users {get;set;}
    }
}