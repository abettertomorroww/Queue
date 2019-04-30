using DataLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Queue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.Controllers
{
    /// <summary>
    /// контроллер управления ролями пользователей
    /// </summary>
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<UserData> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<UserData> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// получаем список пользователей 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index() => View(_roleManager.Roles.ToList());

        /// <summary>
        /// получаем страницу создания ролей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create() => View();

        /// <summary>
        /// возращаем метод создание ролей
        /// </summary>
        /// <param name="name">имя/название роли</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        /// <summary>
        /// возвращаем метод удаления роли
        /// </summary>
        /// <param name="id">индификатор роли</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// получает список пользователей
        /// </summary>
        [HttpGet]
        public IActionResult UserList() => View(_userManager.Users.ToList());

        /// <summary>
        /// получаем страницу редактирование ролей пользователя
        /// </summary>
        /// <param name="userId">индификатор пользователя</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            UserData user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        /// <summary>
        /// возвращаем метод редактирования ролей пользователя
        /// </summary>
        /// <param name="userId">индификатор поьзователя</param>
        /// <param name="roles">список ролей</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            UserData user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);
                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
                return RedirectToAction("UserList");
            }
            return NotFound();
        }
    }
}
