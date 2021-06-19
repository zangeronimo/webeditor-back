using System.Collections.Generic;
using System.Linq;
using Domain.Models.Webeditor;
using Infra.Context;

namespace Infra.Repositories.Webeditor
{
    public class UserRepository: Repository<User>
    {
        public UserRepository(WebeditorContext context): base(context) 
        {}
        
        public override User GetById(int id)
        {
            var query = _context.Set<User>().Where(e => e.DeletedAt == null).Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<User> GetAll()
        {
            var query = _context.Set<User>().Where(e => e.DeletedAt == null);

            return query.Any() ? query.ToList() : new List<User>();
        }
    }
}