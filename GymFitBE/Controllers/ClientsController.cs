using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using GymFitBE.Models;

namespace GymFitBE.Controllers
{
    public class ClientsController : ODataController
    {
        private readonly GymFitContext gymFitContext;

        public ClientsController(GymFitContext gymFitContext)
        {
            this.gymFitContext = gymFitContext;
        }

        [EnableQuery]
        [HttpPost("odata/Clients")]
        public async Task<ActionResult<Client>> Post([FromBody] Client client)
        {
            Console.WriteLine("🔥 POST /odata/Clients hit");

            if (client == null)
            {
                Console.WriteLine("🚫 client is null");
                return BadRequest("Client data is required.");
            }

            gymFitContext.Clients.Add(client);
            await gymFitContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Post), new { id = client.ID }, client);
        }

    }
}
