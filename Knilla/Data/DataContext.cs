using Knilla.Models;
using Microsoft.EntityFrameworkCore;

namespace Knilla.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ContactsModel> ContactsTBL { get; set; }
        public DbSet<UserMasterModel> UserMasterTBL { get; set; }
    }
}
