using apifinansys.Contracts;
using apifinansys.EFContext;
using apifinansys.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {

        public CategoryRepository(FinansysContext context)
            :base(context)
        {

        }
    }
}
