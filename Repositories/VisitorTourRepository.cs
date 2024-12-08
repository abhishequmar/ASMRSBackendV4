//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class VisitorTourRepository : IVisitorTourRepository
//    {
//        private readonly AppDbContext _context;

//        public VisitorTourRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<VisitorTour> GetVisitorTourByIdAsync(int tourId)
//        {
//            return await _context.VisitorTours.FindAsync(tourId);
//        }

//        public async Task<IEnumerable<VisitorTour>> GetAllVisitorToursAsync()
//        {
//            return await _context.VisitorTours.ToListAsync();
//        }

//        public async Task CreateVisitorTourAsync(VisitorTour visitorTour)
//        {
//            await _context.VisitorTours.AddAsync(visitorTour);
//            await _context.SaveChangesAsync();
//        }
//        public async Task SaveChangesAsync(VisitorTour visitorTour)
//        {

//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateVisitorTourAsync(VisitorTour visitorTour)
//        {
//            _context.VisitorTours.Update(visitorTour);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteVisitorTourAsync(int tourId)
//        {
//            var visitorTour = await _context.VisitorTours.FindAsync(tourId);
//            if (visitorTour != null)
//            {
//                _context.VisitorTours.Remove(visitorTour);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<IEnumerable<VisitorTour>> GetVisitorToursByVisitorIdAsync(int visitorId)
//        {
//            return await _context.VisitorTours
//                                 .Where(vt => vt.VisitorIds.Contains(visitorId))
//                                 .ToListAsync();
//        }
//        public async Task<IEnumerable<VisitorTour>> GetVisitorToursByTourGuideIdAsync(int tourGuideId)
//        {
//            return await _context.VisitorTours
//                                 .Where(vt => vt.TourGuideId == tourGuideId)
//                                 .ToListAsync();
//        }



//    }
//}

using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class VisitorTourRepository : IVisitorTourRepository
    {
        private readonly IMongoCollection<VisitorTour> _visitorTours;

        public VisitorTourRepository(IMongoDatabase database)
        {
            _visitorTours = database.GetCollection<VisitorTour>("VisitorTours");
        }

        public async Task<VisitorTour> GetVisitorTourByIdAsync(string tourId)
        {
            return await _visitorTours.Find(vt => vt.TourId == tourId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<VisitorTour>> GetAllVisitorToursAsync()
        {
            return await _visitorTours.Find(Builders<VisitorTour>.Filter.Empty).ToListAsync();
        }


        public async Task CreateVisitorTourAsync(VisitorTour visitorTour)
        {
            await _visitorTours.InsertOneAsync(visitorTour);
        }

        public async Task SaveChangesAsync(VisitorTour visitorTour)
        {
            // MongoDB doesn't require explicit save changes, so this is a no-op
        }

        public async Task UpdateVisitorTourAsync(VisitorTour visitorTour)
{
    var filter = Builders<VisitorTour>.Filter.Eq(vt => vt.TourId, visitorTour.TourId);

    var updateDefinition = Builders<VisitorTour>.Update
        .Set(vt => vt.SiteId, visitorTour.SiteId)
        .Set(vt => vt.TourGuideId, visitorTour.TourGuideId)
        .Set(vt => vt.Date, visitorTour.Date)
        .Set(vt => vt.Time, visitorTour.Time)
        .Set(vt => vt.Capacity, visitorTour.Capacity)
        .Set(vt => vt.Duration, visitorTour.Duration)
        .Set(vt => vt.Description, visitorTour.Description)
        .Set(vt => vt.BookingStatus, visitorTour.BookingStatus)
        .Set(vt => vt.ImageUrl, visitorTour.ImageUrl)
        .Set(vt => vt.SiteName, visitorTour.SiteName)
        .Set(vt => vt.VisitorIds, visitorTour.VisitorIds);

    await _visitorTours.UpdateOneAsync(filter, updateDefinition);
}


        public async Task DeleteVisitorTourAsync(string tourId)
        {
            var filter = Builders<VisitorTour>.Filter.Eq(vt => vt.TourId, tourId);
            await _visitorTours.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<VisitorTour>> GetVisitorToursByVisitorIdAsync(string visitorId)
        {
            var filter = Builders<VisitorTour>.Filter.Where(vt => vt.VisitorIds.Contains(visitorId));
            return await _visitorTours.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<VisitorTour>> GetVisitorToursByTourGuideIdAsync(string tourGuideId)
        {
            var filter = Builders<VisitorTour>.Filter.Eq(vt => vt.TourGuideId, tourGuideId);
            return await _visitorTours.Find(filter).ToListAsync();
        }
    }
}
