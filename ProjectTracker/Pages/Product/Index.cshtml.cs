using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTracker.DataAccess;
using ProjectTracker.Model;

namespace ProjectTracker.Pages.Product
{
  public class IndexModel : PageModel
  {
    private readonly IProductRepository _productRepository;

    [BindProperty]
    public IList<ProductPrice> ProductPrices { get; set; }

    [BindProperty]
    public Model.Product Product { get; set; }

    public IndexModel(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public IActionResult OnGet(string asin)
    {
      Product = _productRepository.GetProduct(asin);
      ProductPrices = _productRepository.GetProductPrices(asin).OrderByDescending(p => p.Date).ToList();
      return Page();
    }
  }
}