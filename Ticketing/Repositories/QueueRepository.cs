using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading.Tasks;
using Ticketing.Enums;
using Ticketing.Repositories.Interfaces;
using Ticketing.Services;

namespace Ticketing.Repositories
{
    public class QueueRepository : IQueueRepository
    {
        private readonly CloudQueue queue;

        public QueueRepository(QueueName queueName)
        {
            var queueClient = StorageAccountProvider.Instance.CreateCloudQueueClient();
            queue = queueClient.GetQueueReference(queueName.ToString());
            queue.CreateIfNotExistsAsync();
        }

        public async Task Add(string content)
        {
            // ToDo: Probably it would be good to strongly type the object is added to the queue
            var message = new CloudQueueMessage(content);
            await queue.AddMessageAsync(message);
        }
    }
}
