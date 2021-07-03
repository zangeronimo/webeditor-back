using System.Collections.Generic;
using System.Linq;
using Domain.Models.Webeditor;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Webeditor
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(WebeditorContext context) :
            base(context)
        {
        }

        public override Role GetById(int id)
        {
            var query =
                _context
                    .Roles
                    .Where(e => e.DeletedAt == null)
                    .Where(e => e.Id == id)
                    .Include(m => m.Module)
                    .Include(u => u.Users);

            if (query.Any()) return query.First();

            return null;
        }

        public override IEnumerable<Role> GetAll()
        {
            var query =
                _context
                    .Roles
                    .Where(e => e.DeletedAt == null)
                    .Include(m => m.Module)
                    .Include(u => u.Users);

            return query.Any() ? query.ToList() : new List<Role>();
        }
    }
}
