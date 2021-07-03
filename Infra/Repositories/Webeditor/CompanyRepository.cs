using System.Collections.Generic;
using System.Linq;
using Domain.Models.Webeditor;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Webeditor
{
    public class CompanyRepository : Repository<Company>
    {
        public CompanyRepository(WebeditorContext context) :
            base(context)
        {
        }

        public override Company GetById(int id)
        {
            var query =
                _context
                    .Set<Company>()
                    .Where(e => e.DeletedAt == null)
                    .Where(e => e.Id == id)
                    .Include(m => m.Modules)
                    .Include(u => u.Users);

            if (query.Any()) return query.First();

            return null;
        }

        public override IEnumerable<Company> GetAll()
        {
            var query =
                _context
                    .Set<Company>()
                    .Where(e => e.DeletedAt == null)
                    .Include(m => m.Modules)
                    .Include(u => u.Users);

            return query.Any() ? query.ToList() : new List<Company>();
        }
    }
}
