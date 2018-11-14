using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTracker.Model;

namespace ProjectTracker.DataAccess
{
  public interface IProductRepository
  {
    ICollection<Product> GetProducts();
    ICollection<Product> GetClientProducts(int clientId);
  }

  public class ProductRepository : IProductRepository
  {
    private readonly ProductDbContext _productDbContext;

    public ProductRepository(ProductDbContext productDbContext)
    {
      _productDbContext = productDbContext;
    }

    public ICollection<Product> GetProducts()
    {
      return _productDbContext.Products.ToList();
    }

    public ICollection<Product> GetClientProducts(int clientId)
    {
      var clientAsins = _productDbContext.ClientProducts.Where(c => c.ClientId == clientId)
        .Select(c => c.Asin);

      return _productDbContext.Products.Where(p => clientAsins.Contains(p.Asin)).ToList();
    }
  }
}
