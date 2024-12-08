using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface IExcavationService
    {
        Task<Excavation> GetExcavationByIdAsync(string excavationId);
        Task<IEnumerable<Excavation>> GetAllExcavationsAsync();
        Task CreateExcavationAsync(Excavation excavation);
        Task UpdateExcavationAsync(Excavation excavation);
        Task DeleteExcavationAsync(string excavationId);
        Task<IEnumerable<Excavation>> GetExcavationsByLeadArchaeologistAsync(string leadArchaeologistId);
    }
}
