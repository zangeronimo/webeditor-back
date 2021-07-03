using System.Collections.Generic;
using System.Linq;
using Domain.Models.Webeditor;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Webeditor
{
    public class ModuleRepository : Repository<Module>
    {
        public ModuleRepository(WebeditorContext context) :
            base(context)
        {
        }

        public override Module GetById(int id)
        {
            var query =
                _context
                    .Set<Module>()
                    .Where(e => e.DeletedAt == null)
                    .Where(e => e.Id == id)
                    .Include(r => r.Companies);

            if (query.Any()) return query.First();

            return null;
        }

        public override IEnumerable<Module> GetAll()
        {
            var query =
                _context
                    .Set<Module>()
                    .Where(e => e.DeletedAt == null)
                    .Include(r => r.Companies);

            return query.Any() ? query.ToList() : new List<Module>();
        }
    }
}
