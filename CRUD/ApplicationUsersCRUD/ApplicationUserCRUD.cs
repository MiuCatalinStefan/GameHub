using GameHub.CRUD.ApplicationUsersCRUD;
using GameHub.CRUD.CategoriesCRUD;
using GameHub.Data;
using GameHub.Models;
using System.Linq.Expressions;

namespace GameHub.CRUD.ApplicationUsersCRUD
{
    public class ApplicationUserCRUD : RepoCRUD<ApplicationUser>, IApplicationUserCRUD
	{
        private readonly ApplicationDbContext _db;
		public ApplicationUserCRUD(ApplicationDbContext db):base(db) {
            _db = db;
        }
        
        public void Update(ApplicationUser applicationUser)
        {
            _db.ApplicationUsers.Update(applicationUser);
        }

    }
}
