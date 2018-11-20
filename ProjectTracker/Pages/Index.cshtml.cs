using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTracker.DataAccess;
using ProjectTracker.Model;

namespace ProjectTracker.Pages
{
  public class IndexModel : PageModel
  {
    private readonly IProductRepository _productRepository;
    private readonly IClientRepository _clientRepository;
    public IList<Model.Product> Products { get; set; }
    public IList<SelectListItem> Clients { get; set; }
    [BindProperty]
    public int Client { get; set; }

    public IndexModel(IProductRepository productRepository, IClientRepository clientRepository)
    {
      _productRepository = productRepository;
      _clientRepository = clientRepository;
    }

    public void OnGet(string client)
    {
      if (string.IsNullOrEmpty(client))
      {
        Products = _productRepository.GetProducts().ToList();
      }
      else
      {
        Products = _productRepository.GetClientProducts(int.Parse(client)).ToList();
      }

      Clients = _clientRepository.GetAllClients().Select(c => new SelectListItem() { Value = c.ClientId.ToString(), Text = c.Name }).ToList();
    }
  }
}
