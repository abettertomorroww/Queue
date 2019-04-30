using Queue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.Services
{
    /// <summary>
    /// интерфейс работы с очередью
    /// </summary>
    public interface IQueueService
    {
        /// <summary>
        /// получаем список очередей 
        /// </summary>
        /// <param name="name">идентификатор  пользователя</param>
        /// <returns></returns>
        Task<IEnumerable<QueueModel>> GetQueue(string id);

        /// <summary>
        /// создает/изменяет очередь
        /// </summary>
        /// <param name="queue">очередь</param>
        /// <returns></returns>
        Task<int> CreateQueue(QueueModel queue);

        /// <summary>
        /// получаем список очередей с именем индетичным параметру
        /// </summary>
        /// <param name="name">имя пользователя</param>
        /// <param name="operation">операция создания/изменения</param>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        IEnumerable<QueueModel> EqualQueue(string name, string operation, int? id);

        /// <summary>
        /// удаление очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task DeleteQueueAsync(int id);

        /// <summary>
        /// получает очередь по индификатору
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task<QueueModel> GetDetails(int id);

    }
}
