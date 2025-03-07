using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Models
{
    public class _DbContext: DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
