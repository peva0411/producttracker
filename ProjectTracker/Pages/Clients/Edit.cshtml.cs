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
  public class EditModel : PageModel
  {
    private readonly IClientRepository _clientRepository;
    private readonly IProductRepository _productRepository;

    [BindProperty]
    public Client Client { get; set; }

    public IList<Model.Product> Products { get; set; }

    public EditModel(IClientRepository clientRepository, IProductRepository productRepository)
    {
      _clientRepository = clientRepository;
      _productRepository = productRepository;
    }

    public IActionResult OnGet(int clientId)
    {
      Client = _clientRepository.Find(clientId);

      Products = _productRepository.GetClientProducts(clientId).ToList();

      return Page();
    }

    public IActionResult OnPost()
    {
      _clientRepository.Save(Client);
      return RedirectToPage("./Index");
    }
  }
}