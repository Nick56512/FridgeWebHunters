using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BLL.Services;
using BLL.DTO;
using Microsoft.AspNetCore.Identity;
using BLL.Services.IdentityServices;
using FridgeOfWebHunter.Areas.Identity.Data;
using FridgeOfWebHunter.Models;
using FridgeOfWebHunter.Repository;
using FridgeOfWebHunter.Interfaces;

namespace BLL.Extensions
{
    public static class AddProvidersExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection services,string connectionStr)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionStr);
            });
        }
        public static void ConfigureIdentityOptions(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 9;
                options.Password.RequiredUniqueChars = 1;

                options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
            });
            services.AddIdentity<User, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();
        }
       

        public static void AddApplicationDataTransients(this IServiceCollection services)
        {
            services.AddScoped<IService<Category,CategoryDto>, CategoryService>();
            services.AddScoped<CategoryService, CategoryService>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();

            services.AddScoped<IService<Ingredient, IngradientDto>, IngradientService>();
            services.AddScoped<IngradientService, IngradientService>();
            services.AddScoped<IRepository<Ingredient>, IngredientRepository>();

            services.AddScoped<IService<IngredientRecipe, IngradientRecipeDto>, IngradientRecipeService>();
            services.AddScoped<IngradientRecipeService, IngradientRecipeService>();
            services.AddScoped<IRepository<IngredientRecipe>, IngredientRecipeRepository>();

            services.AddScoped<IService<IngredientUser, IngradientUserDto>, IngradientUserService>();
            services.AddScoped<IngradientUserService, IngradientUserService>();
            services.AddScoped<IRepository<IngredientUser>, IngredientUserRepository>();

            services.AddScoped<IService<Recipe, RecipeDto>, RecipeService>();
            services.AddScoped<RecipeService, RecipeService>();
            services.AddScoped<IRepository<Recipe>, RecipeRepository>();


            services.AddScoped<UserService, UserService>();
            services.AddScoped<SignInService, SignInService>();
            //services.AddScoped<UserManager<User>, UserManager<User>>();

            services.AddTransient<DbContext, ApplicationDbContext>();
        }
    }
}
