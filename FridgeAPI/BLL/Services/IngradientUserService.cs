using AutoMapper;
using BLL.DTO;
using FridgeOfWebHunter.Areas.Identity.Data;
using FridgeOfWebHunter.Interfaces;
using FridgeOfWebHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class IngradientUserService : GenericService<IngredientUser, IngradientUserDto>
    {
        public IngradientUserService(IRepository<IngredientUser> repository) : base(repository)
        {
            MapperConfiguration configuration = new MapperConfiguration(opt =>
            {
                opt.CreateMap<IngredientUser, IngradientUserDto>();
                opt.CreateMap<IngradientUserDto, IngredientUser>();

                opt.CreateMap<User, UserDto>();
                opt.CreateMap<UserDto, User>();

                opt.CreateMap<Ingredient, IngradientDto>();
                opt.CreateMap<IngradientDto, Ingredient>();
            });
            mapper = new Mapper(configuration);
        }

        public Task<IEnumerable<IngradientUserDto>> GetUserIngredientsAsync(UserDto user) {
            return Task.Run(async () => {
                var result = await this.GetAllAsync();
                result = result.Where(r => r.User.Equals(user));
                return result;
            });
        }

        public Task<IEnumerable<IngradientUserDto>> GetUserIngredientsByUserIdAsync(string userId)
        {
            return Task.Run(async () => {
                var result = await this.GetAllAsync();
                result = result.Where(r => r.UserId==userId);
                return result;
            });
        }
    }
}
