using Exadel.Compreface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exadel.Compreface.Clients
{
    public interface ICompreFaceClient
    {
        public T GetService<T>(string apiKey) where T : AbstractBaseService;
    }
}
