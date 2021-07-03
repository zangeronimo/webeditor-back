using System.Collections.Generic;
using System.Linq;
using Domain.Models.Webeditor;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Webeditor
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(WebeditorContext context) :
            base(context)
        {
        }

        public override User GetById(int id)
        {
            var query =
                _context
                    .Users
                    .Where(e => e.DeletedAt == null)
                    .Where(e => e.Id == id)
                    .Include(c => c.Company)
                    .Include(r => r.Roles);

            if (query.Any()) return query.First();

            return null;
        }

        public override IEnumerable<User> GetAll()
        {
            var query =
                _context
                    .Users
                    .Where(e => e.DeletedAt == null)
                    .Include(c => c.Company)
                    .Include(r => r.Roles);

            return query.Any() ? query.ToList() : new List<User>();
        }
    }
}
