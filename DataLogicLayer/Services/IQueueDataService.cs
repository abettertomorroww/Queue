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
        /// создание очереди в БД
        /// </summary>
        /// <param name="queue">модель очереди</param>
        /// <returns></returns>
        Task CreateQueue(QueueData queue);

        /// <summary>
        /// получаем очередь по индификатору
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task<QueueData> GetDetails(int id);

        /// <summary>
        /// изменяет очередь в БД
        /// </summary>
        /// <param name="records">очередь</param>
        Task UpdateQueue(QueueData queue);

        /// <summary>
        /// получаем список очередей с номером, идентичным параметру
        /// </summary>
        /// <param name="time">время брони очереди</param>
        /// <returns></returns>
        IList<QueueData> EqualQueue(DateTime time);

        /// <summary>
        /// удаление очереди (БД)
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
