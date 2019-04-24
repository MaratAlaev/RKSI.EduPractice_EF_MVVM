using System.Data.Entity;

namespace RKSI.EduPractice_EF_MVVM
{
    public class CitizenDbContext : DbContext
    {
        public CitizenDbContext() : base("ConnectionString") { }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
