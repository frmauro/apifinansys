using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.Middlewares
{
    public interface IHeaderEvent
    {
        string Token { get; set; }
    }
}
