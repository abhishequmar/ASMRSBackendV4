using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class ExcavationService : IExcavationService
    {
        private readonly IExcavationRepository _excavationRepository;

        public ExcavationService(IExcavationRepository excavationRepository)
        {
            _excavationRepository = excavationRepository;
        }

        public async Task<Excavation> GetExcavationByIdAsync(string excavationId)
        {
            return await _excavationRepository.GetExcavationByIdAsync(excavationId);
        }

        public async Task<IEnumerable<Excavation>> GetAllExcavationsAsync()
        {
            return await _excavationRepository.GetAllExcavationsAsync();
        }

        public async Task CreateExcavationAsync(Excavation excavation)
        {
            await _excavationRepository.CreateExcavationAsync(excavation);
        }

        public async Task UpdateExcavationAsync(Excavation excavation)
        {
            await _excavationRepository.UpdateExcavationAsync(excavation);
        }

        public async Task DeleteExcavationAsync(string excavationId)
        {
            await _excavationRepository.DeleteExcavationAsync(excavationId);
        }

        public async Task<IEnumerable<Excavation>> GetExcavationsByLeadArchaeologistAsync(string leadArchaeologistId)
    {
        return await _excavationRepository.GetExcavationsByLeadArchaeologistAsync(leadArchaeologistId);
    }
    }

    

}
