using Microsoft.EntityFrameworkCore;

namespace arabiquantum.Models
{
    public class ApplicetionDbContext : DbContext
    {

        public ApplicetionDbContext(DbContextOptions<ApplicetionDbContext>options) base(options) {
        }
    }
}
