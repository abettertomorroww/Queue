using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="name">имя пользователя</param>
        /// <returns></returns>
        Task<IList<QueueBusiness>> GetQueue(string name);

        /// <summary>
        /// удаление очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task DeleteQueueAsync(int id);

        /// <summary>
        /// получение очереди по индификатору
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        Task<QueueBusiness> GetDetails(int id);

        /// <summary>
        /// создание/изменение очереди
        /// </summary>
        /// <param name="queue">очередь</param>
        /// <returns></returns>
        Task CreateQueue(QueueBusiness queue);

        /// <summary>
        /// получает список очередей с номером, идентичным параметру
        /// </summary>
        /// <param name="number">номер очереди</param>
        /// <param name="operation">операция создания/изменения</param>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        IList<QueueBusiness> EqualQueue(string number, string operation, int? id);
    }
}
