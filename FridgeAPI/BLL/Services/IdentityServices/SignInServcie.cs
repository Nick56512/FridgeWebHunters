using AutoMapper;
using BLL.DTO;
using FridgeOfWebHunter.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IdentityServices
{
    public class SignInService
    {
        SignInManager<User> signInManager;
        UserManager<User> userManager;
        IMapper mapper;

        public SignInService(SignInManager<User>signInManager,UserManager<User>userManager)
        {
            this.signInManager= signInManager;
            this.userManager = userManager;
            MapperConfiguration configuration = new MapperConfiguration(opt =>
            {
                opt.CreateMap<User, UserDto>();
                opt.CreateMap<UserDto, User>();
            });
            mapper = new Mapper(configuration);
        }
        public async Task<SignInResult> SignInWithEmailAsync(string email,string password)
        {
            User user =await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var res=await signInManager.PasswordSignInAsync(user,password,false,false);
                return res;
            }
            return SignInResult.Failed;
        }
        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }

    }
}
