using BusinessLogicLayer.Models;
using DataLogicLayer.Models;
using DataLogicLayer.Services;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Implementation
{
    public class QueueBusinessService : IQueueBusinessService
    {
        private readonly IQueueDataService queueService;

        public QueueBusinessService(IQueueDataService queueService)
        {
            this.queueService = queueService;
        }

        public Task DeleteQueueAsync(int id)
        {
            return this.queueService.DeleteAsync(id);
        }

        public async Task<IList<QueueBusiness>> GetQueue(string name)
        {
            var queueDto = await queueService.GetQueue(name);
            var queues = new List<QueueBusiness>();
            foreach (var el in queueDto)
            {
                var queue = el.Adapt<QueueBusiness>();
                queues.Add(queue);
            }
            return queues;
        }

        public async Task<QueueBusiness> GetDetails(int id)
        {
            var queueDto = await this.queueService.GetDetails(id);
            return queueDto.Adapt<QueueBusiness>();
        }

        public async Task CreateQueue(QueueBusiness queue)
        {
            var queueDto = queue.Adapt<QueueData>();
            queueDto.Id = queue.Id;
            await queueService.CreateQueue(queueDto);
        }

        public IList<QueueBusiness> EqualQueue(string name, string operation, int? id)
        {
            IList<QueueData> queueDto = null;

            switch (operation)
            {
                case "add":
                    queueDto = this.queueService.EqualQueue(name);
                    break;
                case "update":
                    queueDto = this.queueService.EqualQueueUpdate(name, (int)id);
                    break;
            }

            var queues = new List<QueueBusiness>();
            foreach (var el in queueDto)
            {
                var queue = el.Adapt<QueueBusiness>();
                queues.Add(queue);
            }
            return queues;
        }
    }
}
