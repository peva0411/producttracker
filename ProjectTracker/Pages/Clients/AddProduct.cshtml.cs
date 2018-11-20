using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTracker.DataAccess;
using ProjectTracker.Model;

namespace ProjectTracker.Pages.Clients
{
  public class AddProductModel : PageModel
  {
    private readonly IProductRepository _productRepository;

    [BindProperty]
    public Model.Product Product { get; set; }

    [BindProperty]
    public int ClientId { get; set; }

    public AddProductModel(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public IActionResult OnGet(int clientId)
    {
      ClientId = clientId;
      return Page();
    }

    public IActionResult OnPost()
    {
      _productRepository.Add(Product, ClientId);
      return RedirectToPage("./Edit");
    }
  }
}