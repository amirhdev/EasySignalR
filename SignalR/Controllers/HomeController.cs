using Microsoft.AspNetCore.Mvc;
using SignalR.Models;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs.ClientHubs;
using SignalR.Hubs.ServerHubs;

namespace SignalR.Controllers;

public class HomeController : Controller
{
    private readonly IHubContext<PersonHub, IPersonHubProxy> _hubContext;

    public HomeController(IHubContext<PersonHub, IPersonHubProxy> hubContext)
    {
        _hubContext = hubContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> SendMessage()
    {
        await _hubContext.Clients.All.ReceivedMessage("message from back");
        return Json(true);
    }

    [HttpPost]
    public async Task AddNewPerson(Person person)
    {
        //TODO:save new person in db

        await _hubContext.Clients.All.NewPersonAdded(person);
    }
}