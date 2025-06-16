using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymFitBE.Models;
using GymFitBE;

[ApiController]
[Route("api/[controller]")] // This gives you /api/Clients
public class ClientsController : ControllerBase
{
    private readonly GymFitContext _context;

    public ClientsController(GymFitContext context)
    {
        _context = context;
    }

    // GET for testing only
    [HttpGet]
    public IActionResult Get() => Ok(_context.Clients.ToList());

    // ✅ This is the POST that will work with [FromBody]
    [HttpPost]
    public async Task<ActionResult<Client>> Post(Client client)
    {
        Console.WriteLine("📥 Incoming POST: " + (client?.FirstName ?? "null"));

        if (client == null)
        {
            return BadRequest(new { code = "400", message = "Client data is required." });
        }

        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = client.ID }, client);
    }
}
