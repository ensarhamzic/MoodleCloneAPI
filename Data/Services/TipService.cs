using MoodleCloneAPI.Data.Models;

namespace MoodleCloneAPI.Data.Services
{
    public class TipService
    {
        private readonly AppDbContext dbContext;

        public TipService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Tip> GetTipovi()
        {
            return dbContext.Tipovi.ToList();
        }

        public Tip GetTip(int id)
        {
            return dbContext.Tipovi.Find(id);
        }

    }
}
