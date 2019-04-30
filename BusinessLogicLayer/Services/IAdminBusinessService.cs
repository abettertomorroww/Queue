using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services.Implementation
{
    /// <summary>
    /// интерфейс работы администратора
    /// </summary>
    public interface IAdminBusinessService
    {
        /// <summary>
        /// получаем логи
        /// </summary>
        /// <returns></returns>
        LogsModel GetLogs();

        /// <summary>
        /// получаем логи по дате
        /// </summary>
        /// <param name="logs">лрги</param>
        /// <returns></returns>
        LogsModel GetLogsByDate(LogsModel logs);
    }
}
