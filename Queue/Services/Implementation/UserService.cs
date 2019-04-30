using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Queue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserBusinessService userBusiness;

        public UserService(IUserBusinessService userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        public async Task<IdentityResult> Register(User user, string pass)
        {
            var baseUser = user.Adapt<UserBusiness>();
            return (await this.userBusiness.Register(baseUser, pass)).Adapt<IdentityResult>();
        }

        public Task SignIn(User user)
        {
            var baseUser = user.Adapt<UserBusiness>();
            return userBusiness.SignIn(baseUser);
        }

        public async Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe)
        {
            return (await this.userBusiness.PasswordSignIn(email, pass, rememberMe)).Adapt<SignInResult>();
        }

        public Task ForgotPassword(string email, string callbackUrl)
        {
            return userBusiness.ForgotPassword(email, callbackUrl);
        }

        public Task RegistrationConfirm(string email, string callbackUrl)
        {
            return userBusiness.RegistrationConfirm(email, callbackUrl);
        }
    }
}
