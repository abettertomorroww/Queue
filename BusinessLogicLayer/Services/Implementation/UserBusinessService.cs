using BusinessLogicLayer.Models;
using DataLogicLayer.Models;
using DataLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Implementation
{
    public class UserBusinessService : IUserBusinessService
    {
        private readonly IUserDataService userServices;

        public UserBusinessService(IUserDataService userServices)
        {
            this.userServices = userServices;
        }

        public async Task<IdentityResult> Register(UserBusiness user, string pass)
        {
            var userData = user.Adapt<UserData>();
            return await this.userServices.Register(userData, pass);
        }

        public Task SignIn(UserBusiness user)
        {
            var userData = user.Adapt<UserData>();
            return userServices.SignIn(userData);
        }

        public async Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe)
        {
            return await userServices.PasswordSignIn(email, pass, rememberMe);
        }

        public async Task ForgotPassword(string email, string callbackUrl)
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(email, "Reset password",
                $"To reset your password, go to <a href='{callbackUrl}'>link</a>");
        }

        public async Task RegistrationConfirm(string email, string callbackUrl)
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(email, "Confirm your account",
                $"Confirm your registration by clicking on <a href='{callbackUrl}'>link</a>");
        }
    }
}
