using Microsoft.EntityFrameworkCore;

namespace InterAcademic.Infrastructure.Persistence
{
    public class Connection : DbContext
    {
        public Connection(DbContextOptions<Connection> options) : base(options) { }

    }
}