using DataLogicLayer.Data;
using DataLogicLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLayer.Services.Implementation
{
    internal class QueueDataService : IQueueDataService
    {
        private ApplicationDbContext db;

        public QueueDataService(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task DeleteAsync(int id)
        {
            var queue = await db.Queue.FindAsync(id);
            db.Queue.Remove(queue);
            await db.SaveChangesAsync();
        }

        public async Task<IList<QueueData>> GetQueue(string name)
        {
            var userQueue = db.Queue
                .Where(m => m.UserName == name || m.UserName == "Default");

            return await userQueue.ToListAsync();
        }

        public async Task<QueueData> GetDetails(int id)
        {
            var queue = db.Queue
                .FirstOrDefaultAsync(m => m.Id == id);

            return await queue;
        }

        public async Task CreateQueue(QueueData queue)
        {
            this.db.Queue.Add(queue);
            await this.db.SaveChangesAsync();
        }

        public async Task UpdateQueue(QueueData queue)
        {
            this.db.Queue.Update(queue);
            await this.db.SaveChangesAsync();
        }

        public IList<QueueData> EqualQueue(string number)
        {
            IQueryable<QueueData> equalQueue = db.Queue
                        .Where(m => m.NumberQueue == number);
            return equalQueue.ToList();
        }

        public IList<QueueData> EqualQueueUpdate(string number, int id)
        {
            IQueryable<QueueData> equalQueue = db.Queue
                        .Where(m => m.NumberQueue == number && m.Id != id);
            return equalQueue.ToList();
        }
    }
}
