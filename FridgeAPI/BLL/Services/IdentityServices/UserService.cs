using AutoMapper;
using BLL.DTO;
using FridgeOfWebHunter.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IdentityServices
{
    public class UserService
    {
        UserManager<User> userManager;
        IMapper mapper;

        public UserService(UserManager<User> userManager)
        {
            this.userManager = userManager;
            MapperConfiguration configuration = new MapperConfiguration(opt =>
            {
                opt.CreateMap<User, UserDto>();
                opt.CreateMap<UserDto, User>();
            });
            mapper = new Mapper(configuration);
        }
        public async Task<IdentityResult> CreateAsync(UserDto user, string password)
        {
            //user.Id = Guid.NewGuid().ToString();
            User newUser = mapper.Map<UserDto, User>(user);
            newUser.UserName = Guid.NewGuid().ToString();
            var res = await userManager.CreateAsync(newUser, password);
            return res;
        }
        public async Task<UserDto> FindByEmailAsync(string email)
        {
            UserDto user = mapper.Map<User, UserDto>(await userManager.FindByEmailAsync(email));
            return user;
        }
        public async Task<UserDto> GetUser(ClaimsPrincipal claims)
        {
            UserDto user = mapper.Map<User, UserDto>(await userManager.GetUserAsync(claims));
            return user;
        }
        public string GetUserId(ClaimsPrincipal claims)
        {
            return userManager.GetUserId(claims);
        }

        public async Task<IdentityResult> ChangePasswordAsync(string Email, string newPassword, string oldPassword)
        {
            User user = await userManager.FindByEmailAsync(Email);
            var res = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return res;
        }
       
       
        public Task<UserDto> FindUserById(string userId)
        {
            return Task.Run(async () =>
            {
                UserDto user = mapper.Map<User, UserDto>(await userManager.FindByIdAsync(userId));
                return user;
            });
        }
       
        public async Task<IdentityResult[]>ValidatePassword(string password)
        {
            List<IdentityResult> resList = new List<IdentityResult>();
            foreach (var validator in userManager.PasswordValidators)
            {
                IdentityResult res= await validator.ValidateAsync(userManager,null,password);
                resList.Add(res);
            }
            return resList.ToArray();
        }
    }
}
