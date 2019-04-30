using Queue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.Services
{
    /// <summary>
    /// интерфейс админа
    /// </summary>
    public interface IAdminService
    {
        /// <summary>
        /// получаем логи
        /// </summary>
        /// <returns></returns>
        LogsViewModel GetLogs();

        /// <summary>
        /// получаем логи по дате
        /// </summary>
        /// <param name="logs">логи</param>
        /// <returns></returns>
        LogsViewModel GetLogsByDate(LogsViewModel logs);
    }
}
