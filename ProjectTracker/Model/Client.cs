using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Model
{
    public class Client
    {
      public int ClientId { get; set; }
      public string Name { get; set; }
      public bool IsDeleted { get; set; }
    }
}
