//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class ConservationProjectRepository : IConservationProjectRepository
//    {
//        private readonly AppDbContext _context;

//        public ConservationProjectRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<ConservationProject> GetConservationProjectByIdAsync(int projectId)
//        {
//            return await _context.ConservationProjects.FindAsync(projectId);
//        }

//        public async Task<IEnumerable<ConservationProject>> GetAllConservationProjectsAsync()
//        {
//            return await _context.ConservationProjects.ToListAsync();
//        }

//        public async Task CreateConservationProjectAsync(ConservationProject conservationProject)
//        {
//            await _context.ConservationProjects.AddAsync(conservationProject);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateConservationProjectAsync(ConservationProject conservationProject)
//        {
//            _context.ConservationProjects.Update(conservationProject);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteConservationProjectAsync(int projectId)
//        {
//            var conservationProject = await _context.ConservationProjects.FindAsync(projectId);
//            if (conservationProject != null)
//            {
//                _context.ConservationProjects.Remove(conservationProject);
//                await _context.SaveChangesAsync();
//            }
//        }
//        public async Task<List<ConservationProject>> GetProjectsByContributorIdAsync(int contributorId)
//        {
//            return await _context.ConservationProjects
//                .Where(p => p.ContributorIds.Contains(contributorId)) // Assuming ContributorIds is a List
//                .ToListAsync();
//        }
//    }
//}


using System.Linq;
using AsmrsBackend.Data;
using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class ConservationProjectRepository : IConservationProjectRepository
    {
        private readonly IMongoCollection<ConservationProject> _conservationProjects;

        public ConservationProjectRepository(AppDbContext context)
        {
            _conservationProjects = context.ConservationProjects;
        }

        public async Task<ConservationProject> GetConservationProjectByIdAsync(string projectId)
        {
            return await _conservationProjects.Find(cp => cp.ProjectId == projectId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ConservationProject>> GetAllConservationProjectsAsync()
        {
            return await _conservationProjects.Find(_ => true).ToListAsync();
        }

        public async Task CreateConservationProjectAsync(ConservationProject conservationProject)
        {
            await _conservationProjects.InsertOneAsync(conservationProject);
        }

        public async Task UpdateConservationProjectAsync(ConservationProject conservationProject)
{
    var updateDefinition = Builders<ConservationProject>.Update
        .Set(cp => cp.SiteName, conservationProject.SiteName)
        .Set(cp => cp.Objective, conservationProject.Objective)
        .Set(cp => cp.ConservationMethod, conservationProject.ConservationMethod)
        .Set(cp => cp.StartDate, conservationProject.StartDate)
        .Set(cp => cp.EndDate, conservationProject.EndDate)
        .Set(cp => cp.FundingSource, conservationProject.FundingSource);

    // Use the project ID to find and update the document
    await _conservationProjects.UpdateOneAsync(
        cp => cp.ProjectId == conservationProject.ProjectId, 
        updateDefinition
    );
}


        public async Task DeleteConservationProjectAsync(string projectId)
        {
            await _conservationProjects.DeleteOneAsync(cp => cp.ProjectId == projectId);
        }

        public async Task<List<ConservationProject>> GetProjectsByContributorIdAsync(string contributorId)
        {
            return await _conservationProjects
                .Find(cp => cp.ContributorIds.Contains(contributorId)) // Assuming ContributorIds is a List
                .ToListAsync();
        }
    }
}
