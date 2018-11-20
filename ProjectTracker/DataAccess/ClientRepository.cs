using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectTracker.Model;

namespace ProjectTracker.DataAccess
{
  public interface IClientRepository
  {
    ICollection<Client> GetAllClients();
    void Add(Client client);
    Client Find(int clientId);
    void Save(Client client);
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
      return _productDbContext.Clients.Where(c => !c.IsDeleted).ToList();
    }

    public void Add(Client client)
    {
      _productDbContext.Clients.Add(client);
      _productDbContext.SaveChanges();
    }

    public Client Find(int clientId)
    {
      return _productDbContext.Clients.Find(clientId);
    }

    public void Save(Client client)
    {
      _productDbContext.Clients.Attach(client).State = EntityState.Modified;
      _productDbContext.SaveChanges();
    }
  }
}
