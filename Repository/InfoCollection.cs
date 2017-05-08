using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBDataAccess;

namespace Repository
{
    public class InfoCollection<T> : ConnectionProvider<T> where T : class, new()
    {
    }
}
