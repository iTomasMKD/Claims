using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace Claims.Auditing
{
    public class Auditer : IDisposable
    {
        private readonly AuditContext _auditContext;
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusSender _serviceBusSender;
        private AuditContext auditContext;

        public Auditer(AuditContext auditContext)
        {
            this.auditContext = auditContext;
        }

        public Auditer(AuditContext auditContext, string serviceBusConnectionString, string topicName)
        {
            _auditContext = auditContext;
            _serviceBusClient = new ServiceBusClient(serviceBusConnectionString);
            _serviceBusSender = _serviceBusClient.CreateSender(topicName);
        }

        public async Task AuditClaim(string id, string httpRequestType)
        {
            var claimAudit = new ClaimAudit()
            {
                Created = DateTime.UtcNow,
                HttpRequestType = httpRequestType,
                ClaimId = id
            };

            var messageBody = JsonConvert.SerializeObject(claimAudit);
            var message = new ServiceBusMessage(messageBody);

            await _serviceBusSender.SendMessageAsync(message);
        }

        public async Task AuditCover(string id, string httpRequestType)
        {
            var coverAudit = new CoverAudit()
            {
                Created = DateTime.UtcNow,
                HttpRequestType = httpRequestType,
                CoverId = id
            };

            var messageBody = JsonConvert.SerializeObject(coverAudit);
            var message = new ServiceBusMessage(messageBody);

            await _serviceBusSender.SendMessageAsync(message);
        }

        public void Dispose()
        {
            _serviceBusSender.DisposeAsync();
            _serviceBusClient.DisposeAsync();
        }
    }
}

