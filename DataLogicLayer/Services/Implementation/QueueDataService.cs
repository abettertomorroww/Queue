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
    public class QueueDataService : IQueueDataService
    {
        private ApplicationDbContext db;
        public QueueDataService(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IList<QueueData>> GetQueue(string id)
        {
            return await db.Queue.ToListAsync();
        }

        public async Task<QueueData> GetDetails(int id)
        {
            var queue = db.Queue.
                FirstOrDefaultAsync(m => m.Id == id);
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

        public async Task DeleteAsync(int id)
        {
            var queue = await db.Queue.FindAsync(id);
            db.Queue.Remove(queue);
            await db.SaveChangesAsync();
        }

        public IList<QueueData> EqualQueue(DateTime time)
        {
            IQueryable<QueueData> equalQueue = db.Queue
                        .Where(m => m.Time == time);
            return equalQueue.ToList();
        }
    }
}
