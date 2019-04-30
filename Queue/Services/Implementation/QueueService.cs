using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using Mapster;
using Queue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.Services.Implementation
{
    public class QueueService : IQueueService
    {
        private readonly IQueueBusinessService queueData;

        public QueueService(IQueueBusinessService queueData)
        {
            this.queueData = queueData;
        }

        public Task DeleteQueueAsync(int id)
        {
            return this.queueData.DeleteQueueAsync(id);
        }

        public async Task<IEnumerable<QueueModel>> GetQueue(string id)
        {
            return (await this.queueData.GetQueueAsync(id)).Adapt<IEnumerable<QueueModel>>();
        }

        public async Task<QueueModel> GetDetails(int id)
        {
            return (await queueData.GetDetails(id)).Adapt<QueueModel>();
        }

        public async Task<int> CreateQueue(QueueModel queue)
        {
            var baseQueue = queue.Adapt<QueueBusiness>();
            await this.queueData.CreateQueue(baseQueue);
            return baseQueue.Id;
        }

        public async Task<int> UpdateQueue(QueueModel queue)
        {
            var baseQueue = queue.Adapt<QueueBusiness>();
            await this.queueData.UpdateQueue(baseQueue);
            return baseQueue.Id;
        }

        public IEnumerable<QueueModel> EqualQueue(DateTime time, string operation, int? id)
        {
            return (this.queueData.EqualQueue(time, operation, id)).Adapt<IEnumerable<QueueModel>>();
        }
    }
}
