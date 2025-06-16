using GymFitBE.Models;
using GymFitBE;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly GymFitContext _context;

    public ClientsController(GymFitContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Client>> Post(Client client)
    {
        if (client == null)
            return BadRequest(new { message = "Client data is required." });

        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Post), new { id = client.ID }, client);
    }

    [HttpPost("login")]
    public ActionResult<Client> Login([FromBody] LoginRequest request)
    {
        var client = _context.Clients.FirstOrDefault(c =>
            c.Email == request.Email &&
            c.Password == request.Password &&
            c.Role == (UserRole)request.Role);

        if (client == null)
            return Unauthorized(new { message = "Invalid email or password" });

        return Ok(client);
    }

    // Helper class
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}

