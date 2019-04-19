namespace MyFirstEfCoreApp
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        private const string ConnectionString = @"
   Server=127.0.0.1,1433;
   Database=MyFirstEfCoreDb;
   User Id=SA;
   Password=Thetrainislateagain1
";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        
        public DbSet<Book> Books { get; set; }
    }
}