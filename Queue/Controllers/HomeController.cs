using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Queue.Models;
using Queue.Services;
using Queue.ViewModels;

namespace Queue.Controllers
{
    /// <summary>
    /// основной  контролер
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IAdminService _admin;

        public HomeController(ILogger<HomeController> logger, IAdminService admin)
        {
            _logger = logger;
            _admin = admin;
        }

        /// <summary>
        /// получаем главную страницу
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// получаем страницу конфиденциальности
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// обработка ошибок http
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error(int? id)
        {
            _logger.LogWarning("Error({ID}) в {RequestTime}", id, DateTime.Now);
            return Redirect($"~/{id}.htm");
        }

        /// <summary>
        /// получает страницу логов
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Logs()
        {
            LogsViewModel model = _admin.GetLogs();
            return View(model);
        }

        /// <summary>
        /// получает страницу логов по дате
        /// </summary>
        /// <param name="logs">Модель логов</param>
        [HttpPost]
        public IActionResult Logs(LogsViewModel logs)
        {
            if (ModelState.IsValid)
            {
                LogsViewModel model = _admin.GetLogsByDate(logs);
                return View(model);
            }

            return View(new LogsViewModel { Date = null, Text = "Error" });
        }
    }
}
