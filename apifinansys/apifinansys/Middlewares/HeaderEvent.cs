using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.Middlewares
{
    public class HeaderEvent : IHeaderEvent
    {
        public string Token { get; set; }
    }
}
