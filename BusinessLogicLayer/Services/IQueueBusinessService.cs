using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// интерфейс работы с очередью
    /// </summary>
    public interface IQueueBusinessService
    {
        /// <summary>
        /// получаем список очередей
        /// </summary>
        /// <param name="id">идентификатор  пользователя</param>
        /// <returns></returns>
        Task<IList<QueueBusiness>> GetQueueAsync(string id);

        /// <summary>
        /// создание/изменение очереди
        /// </summary>
        /// <param name="queue">очередь</param>
        /// <returns></returns>
        Task CreateQueue(QueueBusiness queue);

        /// <summary>
        /// редактирует очереди
        /// </summary>
        /// <param name="queue">очеред</param>
        Task UpdateQueue(QueueBusiness queue);

        /// <summary>
        /// получение очереди по индификатору
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task<QueueBusiness> GetDetails(int id);

        /// <summary>
        /// удаление очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task DeleteQueueAsync(int id);

        /// <summary>
        /// получает список очередей с номером, идентичным параметру
        /// </summary>
        /// <param name="time">время брони очереди</param>
        /// <param name="operation">операция создания/изменения</param>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        IList<QueueBusiness> EqualQueue(DateTime time, string operation, int? id);
    }
}
