using BPKB_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BPKB_API.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Bpkb> tr_bpkb { get; set; }
    public DbSet<Location> ms_storage_location { get; set; }
    public DbSet<User> ms_user { get; set; }
}
