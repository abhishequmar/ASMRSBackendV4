using AsmrsBackend.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;


namespace AsmrsBackend.Data
{

    //public class AppDbContext : DbContext
    //{

    //    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    //    public DbSet<User> Users { get; set; }
    //    public DbSet<Site> Sites { get; set; }  
    //    public DbSet<Artifact> Artifacts { get; set; }  
    //    public DbSet<Excavation> Excavations { get; set; }
    //    public DbSet<Publication> Publications { get; set; }
    //    public DbSet<VisitorTour> VisitorTours { get; set; }   
    //    public DbSet<Map> Maps { get; set; }
    //    public DbSet<ArtifactTracking> ArtifactTrackings { get; set; }  
    //    public DbSet<ConservationProject> ConservationProjects { get; set; }
    //    public DbSet<Report> Reports { get; set; }
    //    public DbSet<Notification> Notifications { get; set; }
    //    public DbSet<Platform> Platforms { get; set; }


    //    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    //    {


    //    //        ////////////////////////Artifact-Site//////////////////////////////////// 1
    //    //        // Configure Many-to-One Relationship between Artifact and Site
    //    //        modelBuilder.Entity<Artifact>()
    //    //            .HasOne(a => a.Site)
    //    //            .WithMany(s => s.Artifacts)
    //    //            .HasForeignKey(a => a.SiteId);


    //    //        ////////////////////////ArtifactTracking-Artifact////////////////////////////////////2
    //    //        // Configure One-to-One Relationship between Artifact and ArtifactTracking
    //    //        modelBuilder.Entity<ArtifactTracking>()
    //    //            .HasOne(at => at.Artifact)
    //    //            .WithOne(a => a.ArtifactTracking)
    //    //            .HasForeignKey<ArtifactTracking>(at => at.ArtifactId);



    //    //        ////////////////////////ConservationProject-Site////////////////////////////////////3
    //    //        //Configures a many - to - one relationship between ConservationProject and Site
    //    //        modelBuilder.Entity<ConservationProject>()
    //    //            .HasOne(cp => cp.Site)
    //    //            .WithMany(s => s.ConservationProjects)
    //    //            .HasForeignKey(cp => cp.SiteId);


    //    //        ////////////////////////Excavation-Site////////////////////////////////////4
    //    //        // Configure Many-to-One relationship between Excavation and Site
    //    //        modelBuilder.Entity<Excavation>()
    //    //            .HasOne(e => e.Site)                // Each Excavation belongs to one Site
    //    //            .WithMany(s => s.Excavations)       // Each Site can have many Excavations
    //    //            .HasForeignKey(e => e.SiteId);       // Foreign key is SiteId


    //    //        ////////////////////////Excavation-User////////////////////////////////////5

    //    //        // Configure Many-to-One relationship between Excavation and User
    //    //        modelBuilder.Entity<Excavation>()
    //    //            .HasOne(e => e.User)                // Each Excavation has one User (LeadArchaeologist)
    //    //            .WithMany(u => u.Excavations)       // Each User can lead many Excavations
    //    //            .HasForeignKey(e => e.LeadArchaeologist); // Foreign key is LeadArchaeologist

    //    //        ////////////////////////Map-Site////////////////////////////////////6
    //    //        // Configure one-to-one relationship between Map and Site
    //    //        modelBuilder.Entity<Map>()
    //    //            .HasOne(m => m.Site)                 // Each Map has one Site
    //    //            .WithOne(s => s.Map)                 // Each Site has one Map
    //    //            .HasForeignKey<Map>(m => m.SiteId);   // Foreign key is SiteId in Map


    //    //        ////////////////////////Notification-User////////////////////////////////////7
    //    //        // Configure Many-to-One relationship between Notification and User
    //    //        modelBuilder.Entity<Notification>()
    //    //            .HasOne(n => n.User)              // Each Notification belongs to one User
    //    //            .WithMany(u => u.Notifications)   // Each User can have many Notifications
    //    //            .HasForeignKey(n => n.UserId);     // Foreign key is UserId


    //    //        ////////////////////////Platform-User////////////////////////////////////8
    //    //        // Configure one-to-one relationship between Platform and User
    //    //        modelBuilder.Entity<Platform>()
    //    //            .HasOne(p => p.User)                // Each Platform has one User
    //    //            .WithOne(u => u.Platform)           // Each User has one Platform
    //    //            .HasForeignKey<Platform>(p => p.UserId); // Foreign key is UserId in Platform


    //    //        ////////////////////////Publication-User////////////////////////////////////9
    //    //        // Configure many-to-one relationship between Publication and User (Author)
    //    //        modelBuilder.Entity<Publication>()
    //    //            .HasOne(p => p.Author)           // Each Publication has one Author (User)
    //    //            .WithMany(u => u.Publications)       // Each User can have many Publications
    //    //            .HasForeignKey(p => p.AuthorId);      // Foreign key is AuthorId in Publication


    //    //        ////////////////////////Publication-Site////////////////////////////////////10
    //    //        // Configure many-to-one relationship between Publication and Site
    //    //        modelBuilder.Entity<Publication>()
    //    //            .HasOne(p => p.Site)                 // Each Publication has one Site
    //    //            .WithMany(s => s.Publications)       // Each Site can have many Publications
    //    //            .HasForeignKey(p => p.SiteId);       // Foreign key is SiteId in Publication



    //    //        ////////////////////////Report-Site////////////////////////////////////11
    //    //        // Configure many-to-one relationship between Report and Site
    //    //        modelBuilder.Entity<Report>()
    //    //            .HasOne(r => r.Site)               // Each Report has one Site
    //    //            .WithMany(s => s.Reports)          // Each Site can have many Reports
    //    //            .HasForeignKey(r => r.SiteId);     // Foreign key is SiteId in Report


    //    //        ////////////////////////Report-User////////////////////////////////////12
    //    //        // Configure many-to-one relationship between Report and User (GeneratedBy)
    //    //        modelBuilder.Entity<Report>()
    //    //            .HasOne(r => r.User)               // Each Report has one User (GeneratedBy)
    //    //            .WithMany(u => u.Reports)          // Each User can generate many Reports
    //    //            .HasForeignKey(r => r.GeneratedBy); // Foreign key is GeneratedBy in Report


    //    //        ////////////////////////VisitTour-Site////////////////////////////////////13
    //    //        // One-to-Many Relationship between Site and VisitorTour
    //    //        modelBuilder.Entity<VisitorTour>()
    //    //            .HasOne(vt => vt.Site)                 // VisitorTour has one Site
    //    //            .WithMany(s => s.VisitorTours)         // Site can have many VisitorTours
    //    //            .HasForeignKey(vt => vt.SiteId);        // Foreign key is SiteId in VisitorTour


    //    //        ////////////////////////VisitTour-User////////////////////////////////////14
    //    //        // One-to-Many Relationship between User and VisitorTour
    //    //        modelBuilder.Entity<VisitorTour>()
    //    //            .HasOne(vt => vt.TourGuideUser)               // VisitorTour has one User
    //    //            .WithMany(u => u.VisitorTours)       // User can have many VisitorTours
    //    //            .HasForeignKey(vt => vt.TourGuideId);      // Foreign key is UserId in VisitorTour

    //    //        ////////////////////////Site-User////////////////////////////////////14
    //    //        //many to one relation between site and user
    //    //        modelBuilder.Entity<Site>()
    //    //            .HasOne(vt => vt.DiscoveredByUser)               
    //    //            .WithMany(u => u.DiscoveredSites)     
    //    //            .HasForeignKey(vt => vt.DiscoveredBy)
    //    //            .OnDelete(DeleteBehavior.Restrict);    


    //    //    }
    //}



    public class AppDbContext
    {
        public IMongoDatabase _database { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDBSettings:ConnectionString").Value;
            var databaseName = configuration.GetSection("MongoDBSettings:DatabaseName").Value;

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public class MongoDBSettings
        {
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Site> Sites => _database.GetCollection<Site>("Sites");
        public IMongoCollection<Artifact> Artifacts => _database.GetCollection<Artifact>("Artifacts");
        public IMongoCollection<Excavation> Excavations => _database.GetCollection<Excavation>("Excavations");
        public IMongoCollection<Publication> Publications => _database.GetCollection<Publication>("Publications");
        public IMongoCollection<VisitorTour> VisitorTours => _database.GetCollection<VisitorTour>("VisitorTours");
        public IMongoCollection<Map> Maps => _database.GetCollection<Map>("Maps");
        public IMongoCollection<ArtifactTracking> ArtifactTrackings => _database.GetCollection<ArtifactTracking>("ArtifactTrackings");
        public IMongoCollection<ConservationProject> ConservationProjects => _database.GetCollection<ConservationProject>("ConservationProjects");
        public IMongoCollection<Report> Reports => _database.GetCollection<Report>("Reports");
        public IMongoCollection<Notification> Notifications => _database.GetCollection<Notification>("Notifications");
        public IMongoCollection<Platform> Platforms => _database.GetCollection<Platform>("Platforms");
    }
}
