using Microsoft.EntityFrameworkCore;

public class HotelContext : DbContext
{
    public DbSet<ClienteModel> Clientes { get; set; }
    public DbSet<ReservaModel> Reservas { get; set; }
    public DbSet<PlanDeRecompensasModel> PlanesDeRecompensas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=CisnerosM_HotelDB;Trusted_Connection=True;");
    }
}