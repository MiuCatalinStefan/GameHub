using GameHub.Data;
using GameHub.Models;

namespace GameHub.CRUD.PlatformsCRUD
{
    public class PlatformCRUD : RepoCRUD<Platform>, IPlatformCRUD
    {
        private readonly ApplicationDbContext _db;

        public PlatformCRUD(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
