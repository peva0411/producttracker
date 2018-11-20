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
  public class CreateModel : PageModel
  {
    private readonly IClientRepository _clientRepository;

    [BindProperty]
    public Client Client { get; set; }

    public CreateModel(IClientRepository clientRepository)
    {
      _clientRepository = clientRepository;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    public IActionResult OnPost()
    {
      _clientRepository.Add(Client);
      return RedirectToPage("./Index");
    }
  }
}