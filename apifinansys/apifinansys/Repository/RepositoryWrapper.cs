using apifinansys.Contracts;
using apifinansys.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FinansysContext _context;
        private ICategoryRepository _categoryRepository;
        private IEntryRepository _entryRepository;


        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_context);
                return _categoryRepository;
            }
        }

        public IEntryRepository EntryRepository
        {
            get
            {
                if (_entryRepository == null)
                    _entryRepository = new EntryRepository(_context);
                return _entryRepository;
            }
        }


        public RepositoryWrapper(FinansysContext context)
        {
            this._context = context;
        }


    }
}
