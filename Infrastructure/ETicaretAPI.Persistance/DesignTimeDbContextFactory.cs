using ETicaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ETicaretAPI.Persistance;

public class DesignTimeDbContextFActory : IDesignTimeDbContextFactory<ETicaretApıDbContext>
{
    public ETicaretApıDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ETicaretApıDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer(Configuration.connectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}