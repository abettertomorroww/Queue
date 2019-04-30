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
        private readonly IQueueService _queue;

        public QueueController(IQueueService queue)
        {
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
        /// возвращаем метод получающий данные о очередях
        /// </summary>
        /// <param name="id">идентификатор очереди</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            
            var queue = await _queue.GetDetails((int)id);
            if (queue == null)
            {
                return NotFound();
            }
            return View();
        }

        /// <summary>
        /// получаем страницу создания очеред
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// возвращаем метод создания очереди
        /// </summary>
        /// <param name="queue">модель очереди</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QueueModel queue)
        {
            if(_queue.EqualQueue(queue.Time, "add", null).Count() > 0)
            {
                ModelState.AddModelError("Time", "This time is already booked");
            }

            if (ModelState.IsValid)
            {
                await _queue.CreateQueue(queue);
                return RedirectToAction(nameof(Index));
            }
            return View(queue);
        }

        /// <summary>
        /// получаем страницу редактирования очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var queue = await _queue.GetDetails((int)id);
            if (queue == null)
            {
                return NotFound();
            }
            return View(queue);
        }

        /// <summary>
        /// возвращаем метод редактирования очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <param name="queue">модель очереди</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, QueueModel queue)
        {
            if (id!= queue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _queue.UpdateQueue(queue);
                }
                catch
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
        /// получаем страницу удаления очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var queue = await _queue.GetDetails((int)id);
            if (queue == null)
            {
                return NotFound();
            }
            return View(queue);
        }

        /// <summary>
        /// возвращает метод удаления очереди
        /// </summary>
        /// <param name="id">индификатор очереди</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _queue.DeleteQueueAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
