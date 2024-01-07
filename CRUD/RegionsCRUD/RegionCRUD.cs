using GameHub.Data;
using GameHub.Models;

namespace GameHub.CRUD.RegionsCRUD
{
    public class RegionCRUD : RepoCRUD<Region>, IRegionCRUD
    {
        private readonly ApplicationDbContext _db;

        public RegionCRUD(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
