using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Implementation;
using Mapster;
using Queue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.Services.Implementation
{
    internal class AdminService : IAdminService
    {
        private readonly IAdminBusinessService adminBusiness;

        public AdminService(IAdminBusinessService adminBusiness)
        {
            this.adminBusiness = adminBusiness;
        }

        public LogsViewModel GetLogs()
        {
            return adminBusiness.GetLogs().Adapt<LogsViewModel>();
        }

        public LogsViewModel GetLogsByDate(LogsViewModel logs)
        {
            var baseLogs = logs.Adapt<LogsModel>();
            return adminBusiness.GetLogsByDate(baseLogs).Adapt<LogsViewModel>();
        }
    }
}