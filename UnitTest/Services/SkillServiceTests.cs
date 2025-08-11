using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Site.Entites;
using Site.Repositories.Interfaces;
using Site.Services;
using Xunit;

namespace UnitTest.Services
{
    public class SkillServiceTests
    {
        private readonly Mock<ISkillRepository> _skillRepoMock;
        private readonly SkillService _service;

        public SkillServiceTests()
        {
            _skillRepoMock = new Mock<ISkillRepository>();
            _service = new SkillService(_skillRepoMock.Object);
        }

        [Fact]
        public async Task GetAllSkillsAsync_ShouldReturnSkills()
        {
            // Arrange
            var skills = new List<Skill>
            {
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "Blazor" }
            };

            _skillRepoMock
                .Setup(r => r.GetAllAsync(false, false))
                .ReturnsAsync(skills);

            // Act
            var result = await _service.GetAllSkillsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<Skill>)result).Count);
        }

        [Fact]
        public async Task GetSkillByIdAsync_ShouldReturnSkill_WhenFound()
        {
            // Arrange
            var skill = new Skill { Id = 1, Name = "C#" };
            _skillRepoMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(skill);

            // Act
            var result = await _service.GetSkillByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("C#", result.Name);
        }

        [Fact]
        public async Task GetSkillByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            _skillRepoMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Skill)null);

            // Act
            var result = await _service.GetSkillByIdAsync(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddSkillAsync_ShouldCallRepositoryAddAndSave()
        {
            // Arrange
            var skill = new Skill { Id = 1, Name = "New Skill" };

            // Act
            await _service.AddSkillAsync(skill);

            // Assert
            _skillRepoMock.Verify(r => r.AddAsync(skill), Times.Once);
            _skillRepoMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateSkillAsync_ShouldCallRepositoryUpdateAndSave()
        {
            // Arrange
            var skill = new Skill { Id = 1, Name = "Updated Skill" };

            // Act
            await _service.UpdateSkillAsync(skill);

            // Assert
            _skillRepoMock.Verify(r => r.UpdateAsync(skill), Times.Once);
            _skillRepoMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteSkillAsync_ShouldCallRepositoryDeleteAndSave()
        {
            // Act
            await _service.DeleteSkillAsync(1);

            // Assert
            _skillRepoMock.Verify(r => r.DeleteAsync(1), Times.Once);
            _skillRepoMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdsAsync_ShouldReturnSkills()
        {
            // Arrange
            var skillIds = new List<int> { 1, 2 };
            var skills = new List<Skill>
            {
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "Blazor" }
            };

            _skillRepoMock
                .Setup(r => r.GetByIdsAsync(skillIds, false, false))
                .ReturnsAsync(skills);

            // Act
            var result = await _service.GetByIdsAsync(skillIds);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
