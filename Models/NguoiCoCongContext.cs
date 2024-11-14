using Microsoft.EntityFrameworkCore;

namespace KienGiangApplication.Models
{
    public class NguoiCoCongContext : DbContext
    {
        public NguoiCoCongContext(DbContextOptions<NguoiCoCongContext> options) : base (options)
        {

        }
        public DbSet<NguoiCoCong> NguoiCoCongs { get; set; } = null!;
    }
}
