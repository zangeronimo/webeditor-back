using System.Collections.Generic;
using System.Linq;
using Domain.Models.Webeditor;
using Infra.Context;

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
                    .Set<Role>()
                    .Where(e => e.DeletedAt == null)
                    .Where(e => e.Id == id);

            if (query.Any()) return query.First();

            return null;
        }

        public override IEnumerable<Role> GetAll()
        {
            var query = _context.Set<Role>().Where(e => e.DeletedAt == null);

            return query.Any() ? query.ToList() : new List<Role>();
        }
    }
}
