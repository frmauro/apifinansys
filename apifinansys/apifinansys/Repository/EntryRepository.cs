using apifinansys.Contracts;
using apifinansys.EFContext;
using apifinansys.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.Repository
{
    public class EntryRepository : RepositoryBase<Entry>, IEntryRepository
    {
        public EntryRepository(FinansysContext context)
            :base(context)
        {

        }
    }
}
