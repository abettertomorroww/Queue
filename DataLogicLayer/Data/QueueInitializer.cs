using DataLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLogicLayer.Data
{
    public class QueueInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Queue.Any())
            {
                return;   // DB has been seeded
            }

            var usersLogin = new QueueData[]
            {
                new QueueData { UserName = "Alex",NumberRoom = 1,   Microwave = 1, Time =new DateTime(2019, 4, 25, 18, 30, 00)},
                
            };
            foreach (QueueData s in usersLogin)
            {
                context.Queue.Add(s);
            }
            context.SaveChanges();

        }
    }
}
