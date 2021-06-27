using System.Collections.Generic;
using System.Linq;
using Domain.Models.Webeditor;
using Infra.Context;

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
                    .Where(e => e.Id == id);

            if (query.Any()) return query.First();

            return null;
        }

        public override IEnumerable<Company> GetAll()
        {
            var query = _context.Set<Company>().Where(e => e.DeletedAt == null);

            return query.Any() ? query.ToList() : new List<Company>();
        }
    }
}
