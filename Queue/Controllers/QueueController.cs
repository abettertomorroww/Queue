using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Queue.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Queue.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Queue.Controllers
{
    /// <summary>
    /// контролер управления очередью
    /// </summary>
    [Authorize]
    public class QueueController : Controller
    {
        private readonly ILogger _logger;
        private readonly IQueueService _queue;

        public QueueController(ILogger<QueueController> logger, IQueueService queue)
        {
            _logger = logger;
            _queue = queue;
        }

        /// <summary>
        /// получает список очередей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View("Index", await this._queue.GetQueue(HttpContext.User.Identity.Name));
        }

        /// <summary>
        /// получет данные о очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queue = await _queue.GetDetails((int)id);
            if (queue == null)
            {
                return BadRequest();
            }
            if (queue.UserName != HttpContext.User.Identity.Name || queue.UserName == "Default")
            {
                return RedirectToAction(nameof(Index));
            }
            return View(queue);
        }

        /// <summary>
        /// получает страницу создания очереди
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// возвращает метод создания очереди
        /// </summary>
        /// <param name="queue">очередь</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QueueModel queue)
        {
            if (_queue.EqualQueue(queue.UserName, "add", null).Count() > 0)
            {
                ModelState.AddModelError("Name", "An entry has already been added under this name");
            }

            if (ModelState.IsValid)
            {
                await _queue.CreateQueue(queue);
                return RedirectToAction(nameof(Index));
            }
            return View(queue);
        }

        /// <summary>
        /// получает страницу редактирование очереди
        /// </summary>
        /// <param name="id">индификатов очереди</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var queue = await _queue.GetDetails((int)id);

            if (queue == null)
            {
                return BadRequest();
            }

            if (queue.UserName != HttpContext.User.Identity.Name || queue.UserName == "Default")
            {
                return RedirectToAction(nameof(Index));
            }
            return View(queue);
        }

        /// <summary>
        /// возвращает метод редактирования очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <param name="queue">очередь</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, QueueModel queue)
        {
            if (id != queue.Id)
            {
                return NotFound();
            }

            if (_queue.EqualQueue(queue.UserName, "update", queue.Id).Count() > 0)
            {
                ModelState.AddModelError("Name", "An entry has already been added under this name");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _queue.CreateQueue(queue);
                }
                catch (DbUpdateConcurrencyException)
                {
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(queue);
        }

        /// <summary>
        /// получает страницу удаления очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var queue = await _queue.GetDetails((int)id);

            if (queue == null)
            {
                return BadRequest();
            }

            if (queue.UserName != HttpContext.User.Identity.Name || queue.UserName == "Default")
            {
                return RedirectToAction(nameof(Index));
            }
            return View(queue);
        }

        /// <summary>
        /// возвращает метод удаления очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _queue.DeleteQueueAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
