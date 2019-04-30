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
        /// удаление очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task DeleteQueueAsync(int id);

        /// <summary>
        /// получаем список очередей 
        /// </summary>
        /// <param name="id">идентификатор очереди</param>
        /// <returns></returns>
        Task<IEnumerable<QueueModel>> GetQueue(string id);

        /// <summary>
        /// получает очередь по индификатору
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task<QueueModel> GetDetails(int id);


        /// <summary>
        /// создает/изменяет очередь
        /// </summary>
        /// <param name="queue">очередь</param>
        /// <returns></returns>
        Task<int> CreateQueue(QueueModel queue);

        /// <summary>
        /// редактирует очередь
        /// </summary>
        /// <param name="queue">модель очереди</param>
        Task<int> UpdateQueue(QueueModel queue);

        /// <summary>
        /// получаем список очередей с именем индетичным параметру
        /// </summary>
        /// <param name="time">время брони очереди</param>
        /// <param name="operation">операция создания/изменения</param>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        IEnumerable<QueueModel> EqualQueue(DateTime time, string operation, int? id);

    }
}
