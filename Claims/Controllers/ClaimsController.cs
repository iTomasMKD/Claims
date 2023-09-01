using Claims.Auditing;
using Claims.Models;
using Claims.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;

namespace Claims.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {
        
        private readonly ILogger<ClaimsController> _logger;
        private readonly CosmosDbService _cosmosDbService;
        private readonly Auditer _auditer;
        private IContainer @object;

        public ICosmosDbService Object1 { get; }
        public Auditer Object2 { get; }

        public ClaimsController(ILogger<ClaimsController> logger, CosmosDbService cosmosDbService, AuditContext auditContext)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService;
            _auditer = new Auditer(auditContext);
        }

        //public ClaimsController(IContainer @object)
        //{
        //    this.@object = @object;
        //}

        //public ClaimsController(ICosmosDbService object1, Auditer object2)
        //{
        //    Object1 = object1;
        //    Object2 = object2;
        //}

        [HttpGet]
        public Task<IEnumerable<Claim>> GetAsync()
        {
            return _cosmosDbService.GetClaimsAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Claim claim)
        {
            claim.Id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddItemAsync(claim);
            _auditer.AuditClaim(claim.Id, "POST");
            return Ok(claim);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(string id)
        {
            _auditer.AuditClaim(id, "DELETE");
            return _cosmosDbService.DeleteItemAsync(id);
        }

        [HttpGet("{id}")]
        public Task<Claim> GetAsync(string id)
        {
            return _cosmosDbService.GetClaimAsync(id);
        }
    }

    //public class CosmosDbService
    //{
    //    private readonly Container _container;

    //    public CosmosDbService(CosmosClient dbClient,
    //        string databaseName,
    //        string containerName)
    //    {
    //        if (dbClient == null) throw new ArgumentNullException(nameof(dbClient));
    //        _container = dbClient.GetContainer(databaseName, containerName);
    //    }

    //    public async Task<IEnumerable<Claim>> GetClaimsAsync()
    //    {
    //        var query = _container.GetItemQueryIterator<Claim>(new QueryDefinition("SELECT * FROM c"));
    //        var results = new List<Claim>();
    //        while (query.HasMoreResults)
    //        {
    //            var response = await query.ReadNextAsync();

    //            results.AddRange(response.ToList());
    //        }
    //        return results;
    //    }

    //    public async Task<Claim> GetClaimAsync(string id)
    //    {
    //        try
    //        {
    //            var response = await _container.ReadItemAsync<Claim>(id, new PartitionKey(id));
    //            return response.Resource;
    //        }
    //        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
    //        {
    //            return null;
    //        }
    //    }

    //    public Task AddItemAsync(Claim item)
    //    {
    //        return _container.CreateItemAsync(item, new PartitionKey(item.Id));
    //    }

    //    public Task DeleteItemAsync(string id)
    //    {
    //        return _container.DeleteItemAsync<Claim>(id, new PartitionKey(id));
    //    }
    //}
}