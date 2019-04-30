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
    internal class QueueService : IQueueService
    {
        private readonly IQueueBusinessService queueBusiness;

        public QueueService(IQueueBusinessService queueBusiness)
        {
            this.queueBusiness = queueBusiness;
        }


        public async Task<IEnumerable<QueueModel>> GetQueue(string id)
        {
            return (await this.queueBusiness.GetQueue(id)).Adapt<IEnumerable<QueueModel>>();
        }


        public async Task<int> CreateQueue(QueueModel queue)
        {
            var baseQueue = queue.Adapt<QueueBusiness>();
            await this.queueBusiness.CreateQueue(baseQueue);
            return baseQueue.Id;
        }


        public IEnumerable<QueueModel> EqualQueue(string name, string operation, int? id)
        {
            return (this.queueBusiness.EqualQueue(name, operation, id)).Adapt<IEnumerable<QueueModel>>();
        }


        public Task DeleteQueueAsync(int id)
        {
            return this.queueBusiness.DeleteQueueAsync(id);
        }


        public async Task<QueueModel> GetDetails(int id)
        {
            return (await queueBusiness.GetDetails(id)).Adapt<QueueModel>();
        }

 
    }
}
