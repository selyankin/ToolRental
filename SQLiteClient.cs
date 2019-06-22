using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToolsRental;

namespace ToolRental
{
    public sealed class SQLiteClient : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Tool> Tools { get; set; }

        public SQLiteClient() : base("DefaultConnection")
        {
        }

        public IEnumerable<Client> FindClients(List<int> ids)
        {
            return ids.Select(id => Clients.Find(id));
        }

        public IEnumerable<Tool> FindTools(List<int> ids)
        {
            return ids.Select(id => Tools.Find(id));
        }
    }
}
