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
    void Add(Product product, int clientId);
    ICollection<ProductPrice> GetProductPrices(string asin);
    Product GetProduct(string asin);
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

    public ICollection<ProductPrice> GetProductPrices(string asin)
    {
      var prices = _productDbContext.ProductPrices.Where(p => p.Asin == asin).ToList();
      return prices;
    }

    public Product GetProduct(string asin)
    {
      return _productDbContext.Products.FirstOrDefault(p => p.Asin == asin);
    }

    public ICollection<Product> GetClientProducts(int clientId)
    {
      var clientAsins = _productDbContext.ClientProducts.Where(c => c.ClientId == clientId)
        .Select(c => c.Asin);

      return _productDbContext.Products.Where(p => clientAsins.Contains(p.Asin)).ToList();
    }

    public void Add(Product product, int clientId)
    {
      _productDbContext.Products.Add(product);
      _productDbContext.ClientProducts.Add(new ClientProduct() { Asin = product.Asin, ClientId = clientId });
      _productDbContext.SaveChanges();
    }
  }
}
