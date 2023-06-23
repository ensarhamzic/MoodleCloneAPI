using MoodleCloneAPI.Data.Models;

namespace MoodleCloneAPI.Data.Services
{
    public class ZvanjeService
    {
        private readonly AppDbContext dbContext;

        public ZvanjeService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Zvanje> GetZvanja()
        {
            return dbContext.Zvanja.ToList();
        }

        public Zvanje GetZvanje(int id)
        {
            return dbContext.Zvanja.Find(id);
        }

    }
}
