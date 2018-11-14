using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTracker.Model;

namespace ProjectTracker.DataAccess
{
    public interface IClientRepository
    {
      ICollection<Client> GetAllClients();
    }

    public class ClientRepository : IClientRepository
    {
      private readonly ProductDbContext _productDbContext;

      public ClientRepository(ProductDbContext productDbContext)
      {
        _productDbContext = productDbContext;
      }

      public ICollection<Client> GetAllClients()
      {
      return _productDbContext.Clients.ToList();
      }
    }
}
