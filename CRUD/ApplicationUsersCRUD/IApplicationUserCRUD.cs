using GameHub.Models;

namespace GameHub.CRUD.ApplicationUsersCRUD
{
    public interface IApplicationUserCRUD : IRepoCRUD<ApplicationUser>
    {
        void Update(ApplicationUser applicationUser);
    }
}
