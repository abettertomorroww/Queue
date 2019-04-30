using BusinessLogicLayer.Models;
using DataLogicLayer.Models;
using DataLogicLayer.Services;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IList<QueueBusiness>> GetQueueAsync(string id)
        {
            var queueDto = await this.queueService.GetQueue(id);
            return queueDto.Select(el => (el.Adapt<QueueBusiness>())).ToList();
        }

        public Task DeleteQueueAsync(int id)
        {
            return this.queueService.DeleteAsync(id);
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
            await this.queueService.CreateQueue(queueDto);
        }

        public async Task UpdateQueue(QueueBusiness queue)
        {
            var queueDto = queue.Adapt<QueueData>();
            queueDto.Id = queue.Id;
            await this.queueService.UpdateQueue(queueDto);
        }

        public IList<QueueBusiness> EqualQueue(DateTime time, string operation, int? id)
        {
            IList<QueueData> queueDto = null;

            switch (operation)
            {
                case "add":
                    queueDto = this.queueService.EqualQueue(time);
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
