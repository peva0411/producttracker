using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Model
{
    public class ClientProduct
    {
      public int ClientProductId { get; set; }
      public int ClientId { get; set; }
      public string Asin { get; set; }
    }
}
