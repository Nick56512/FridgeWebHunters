using BLL.DTO;
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
        }

        public Task<IEnumerable<IngradientUserDto>> GetUserIngredientsAsync(UserDto user) {
            return Task.Run(async () => {
                var result = await this.GetAllAsync();
                result = result.Where(r => r.UserDto.Equals(user));
                return result;
            });
        }
    }
}
