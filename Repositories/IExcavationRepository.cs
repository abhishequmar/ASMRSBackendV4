//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface IExcavationRepository
//    {
//        Task<Excavation> GetExcavationByIdAsync(int excavationId);
//        Task<IEnumerable<Excavation>> GetAllExcavationsAsync();
//        Task CreateExcavationAsync(Excavation excavation);
//        Task UpdateExcavationAsync(Excavation excavation);
//        Task DeleteExcavationAsync(int excavationId);
//    }
//}


using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface IExcavationRepository
    {
        Task<Excavation> GetExcavationByIdAsync(string excavationId);
        Task<IEnumerable<Excavation>> GetAllExcavationsAsync();
        Task CreateExcavationAsync(Excavation excavation);
        Task UpdateExcavationAsync(Excavation excavation);
        Task DeleteExcavationAsync(string excavationId);
        Task<IEnumerable<Excavation>> GetExcavationsByLeadArchaeologistAsync(string leadArchaeologistId);
    }
}
