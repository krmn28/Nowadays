using Nowadays.Api.Entities;

namespace Nowadays.Api.DataAccess.Repositories.ProjectRepositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}