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
            var jobPosting = new DevSpot.Models.JobPosting
            {
                Title = "Software Engineer",
                Description = "Develop and maintain software applications.",
                Company = "TechCorp",
                Location = "New York, NY",
                PostedOn = DateTime.UtcNow
            };

            //execute
            await repo.AddAsync(jobPosting);

            //result
            var result = db.JobPostings.SingleOrDefault(x => x.Title == "Software Engineer");

            //assert
            Assert.NotNull(result);
            Assert.Equal("TechCorp", result.Company);
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllJobPostings()
        {
            // db context
            var db = CreateDbContext();
            // jobPosting repository
            var repo = new JobPostingRepository(db);
            //job postings
            var jobPosting1 = new DevSpot.Models.JobPosting
            {
                Title = "Software Engineer",
                Description = "Develop and maintain software applications.",
                Company = "TechCorp",
                Location = "New York, NY",
                PostedOn = DateTime.UtcNow
            };
            var jobPosting2 = new DevSpot.Models.JobPosting
            {
                Title = "Data Scientist",
                Description = "Analyze and interpret complex data.",
                Company = "DataSolutions",
                Location = "San Francisco, CA",
                PostedOn = DateTime.UtcNow
            };
            //execute
            await repo.AddAsync(jobPosting1);
            await repo.AddAsync(jobPosting2);
            //result
            var result = await repo.GetAllAsync();
            //assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnJobPostingById()
        {
            // db context
            var db = CreateDbContext();
            // jobPosting repository
            var repo = new JobPostingRepository(db);
            //job posting
            var jobPosting = new DevSpot.Models.JobPosting
            {
                Title = "Software Engineer",
                Description = "Develop and maintain software applications.",
                Company = "TechCorp",
                Location = "New York, NY",
                PostedOn = DateTime.UtcNow
            };
            //execute
            await repo.AddAsync(jobPosting);
            //result
            var result = await repo.GetByIdAsync(jobPosting.Id);
            //assert
            Assert.NotNull(result);
            Assert.Equal("Software Engineer", result.Title);
        }
        [Fact]
        public async Task DeleteAsync_ShouldRemoveJobPosting()
        {
            // db context
            var db = CreateDbContext();
            // jobPosting repository
            var repo = new JobPostingRepository(db);
            //job posting
            var jobPosting = new DevSpot.Models.JobPosting
            {
                Title = "Software Engineer",
                Description = "Develop and maintain software applications.",
                Company = "TechCorp",
                Location = "New York, NY",
                PostedOn = DateTime.UtcNow
            };
            //execute
            await repo.AddAsync(jobPosting);
            await repo.DeleteAsync(jobPosting.Id);
            //result
            var result = db.JobPostings.SingleOrDefault(x => x.Id == jobPosting.Id);
            //assert
            Assert.Null(result);
        }
        [Fact]
        public async Task UpdateAsync_ShouldModifyJobPosting()
        {
            // db context
            var db = CreateDbContext();
            // jobPosting repository
            var repo = new JobPostingRepository(db);
            //job posting
            var jobPosting = new DevSpot.Models.JobPosting
            {
                Title = "Software Engineer",
                Description = "Develop and maintain software applications.",
                Company = "TechCorp",
                Location = "New York, NY",
                PostedOn = DateTime.UtcNow
            };
            //execute
            await repo.AddAsync(jobPosting);
            jobPosting.Title = "Senior Software Engineer";
            await repo.UpdateAsync(jobPosting);
            //result
            var result = await repo.GetByIdAsync(jobPosting.Id);
            //assert
            Assert.NotNull(result);
            Assert.Equal("Senior Software Engineer", result.Title);
        }
    }
}
