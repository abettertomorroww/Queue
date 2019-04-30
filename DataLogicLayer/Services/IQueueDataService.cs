using DataLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLayer.Services
{
    /// <summary>
    /// интерфейс работы с очередью
    /// </summary>
    public interface IQueueDataService
    {
        /// <summary>
        /// получаем список очередей
        /// </summary>
        /// <param name="name">имя пользователя</param>
        /// <returns></returns>
        Task<IList<QueueData>> GetQueue(string name);

        /// <summary>
        /// удаление очереди из бд
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// получаем персонаж по идентификатору
        /// </summary>
        /// <param name="id">идентификатор очереди</param>
        /// <returns></returns>
        Task<QueueData> GetDetails(int id);

        /// <summary>
        /// создание очереди в бд
        /// </summary>
        /// <param name="queue">очередь</param>
        /// <returns></returns>
        Task CreateQueue(QueueData queue);

        /// <summary>
        /// обнавление очереди в бд
        /// </summary>
        /// <param name="queue">очередь</param>
        /// <returns></returns>
        Task UpdateQueue(QueueData queue);

        /// <summary>
        /// получаем список очередей с номером, идентичным параметру
        /// </summary>
        /// <param name="number">номер очереди</param>
        /// <returns></returns>
        IList<QueueData> EqualQueue(string number);

        /// <summary>
        /// обновляем список очередей с номером, идентичным параметру
        /// </summary>
        /// <param name="number">номер очереди</param>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        IList<QueueData> EqualQueueUpdate(string number, int id);
    }
}
