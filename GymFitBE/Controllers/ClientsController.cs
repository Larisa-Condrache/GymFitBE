using GymFitBE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.OData;

namespace GymFitBE.Controllers
{
    public class ClientsController : ODataController
    {
        private readonly GymFitContext gymFitContext;
        public ClientsController(GymFitContext gymFitContext) 
        {
            this.gymFitContext = gymFitContext;
        }

        // GET: odata/Clients
        [EnableQuery]
        public IQueryable<Client> GetClients()
        {
            return gymFitContext.Clients;
        }

        // POST odata/Clients
        [EnableQuery]
        public async Task<Client> Post([FromBody] Client client)
        {
            gymFitContext.Clients.Add(client);
            await gymFitContext.SaveChangesAsync();
            return client;
        }
    }
}
