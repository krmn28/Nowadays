namespace Nowadays.Api.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NowadaysDbContext _context;

        public UnitOfWork(NowadaysDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}