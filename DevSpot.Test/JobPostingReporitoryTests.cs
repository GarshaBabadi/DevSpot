using DevSpot.Data;
using DevSpot.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSpot.Test
{
    public class JobPostingReporitoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        public JobPostingReporitoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("JobPostingDb")
                .Options;
        }

        private ApplicationDbContext CreateDbContext()
        {
            return new ApplicationDbContext(_options);
        }

        [Fact]
        public async Task AddAsync_ShouldAddToJobPosting()
        {
            // db context
            var db = CreateDbContext();

            // jobPosting repository
            var repo = new JobPostingRepository(db);

            //job posting

            //execute

            //result

            //asser
        }
    }
}
