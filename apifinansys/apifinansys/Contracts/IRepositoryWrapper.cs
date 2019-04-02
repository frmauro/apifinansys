using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.Contracts
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository CategoryRepository { get; }
        IEntryRepository EntryRepository { get; }
    }
}
