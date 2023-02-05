using FridgeOfWebHunter.Areas.Identity.Data;

namespace FridgeOfWebHunter.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
