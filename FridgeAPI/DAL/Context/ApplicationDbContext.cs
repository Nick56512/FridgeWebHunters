using FridgeOfWebHunter.Areas.Identity.Data;
using FridgeOfWebHunter.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FridgeOfWebHunter.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<IngredientRecipe> IngredientRecipes { get; set; }

    public virtual DbSet<IngredientUser> IngredientUsers { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}
