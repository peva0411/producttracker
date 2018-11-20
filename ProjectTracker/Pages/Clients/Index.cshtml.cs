using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTracker.DataAccess;
using ProjectTracker.Model;

namespace ProjectTracker.Pages.Clients
{
  public class IndexModel : PageModel
  {
    private readonly IClientRepository _clientRepository;

    public IndexModel(IClientRepository clientRepository)
    {
      _clientRepository = clientRepository;
    }

    public void OnGet()
    {
      Clients = _clientRepository.GetAllClients().ToList();
    }

    public IList<Client> Clients { get; set; }
  }
}