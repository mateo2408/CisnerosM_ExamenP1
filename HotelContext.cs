using Microsoft.EntityFrameworkCore;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

    public DbSet<ClienteModel> Clientes { get; set; }
    public DbSet<ReservaModel> Reservas { get; set; }
    public DbSet<PlanDeRecompensasModel> PlanesDeRecompensas { get; set; }
    
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       if (!optionsBuilder.IsConfigured)
       {
           optionsBuilder.UseSqlServer(
               "Server=tcp:sqlcisneros.database.windows.net,1433;Initial Catalog=Prueba;Persist Security Info=False;User ID=sqlcisneros;Password=zagmok-cydgo1-mAjdif;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;",
               options => options.EnableRetryOnFailure(
                   maxRetryCount: 5, // Number of retry attempts
                   maxRetryDelay: TimeSpan.FromSeconds(10), // Delay between retries
                   errorNumbersToAdd: null // Additional SQL error codes to consider transient
               )
           );
       }
   }
}