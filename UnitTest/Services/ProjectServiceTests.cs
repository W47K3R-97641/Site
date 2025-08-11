using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Site.CustomExceptions;
using Site.Dtos;
using Site.Entites;
using Site.Repositories.Interfaces;
using Site.Services;
using Xunit;

namespace UnitTest.Services
{
    public class ProjectServiceTests
    {
        private readonly Mock<IProjectRepository> _projectRepoMock;
        private readonly Mock<ISkillRepository> _skillRepoMock;
        private readonly ProjectService _service;

        public ProjectServiceTests()
        {
            _projectRepoMock = new Mock<IProjectRepository>();
            _skillRepoMock = new Mock<ISkillRepository>();

            _service = new ProjectService(_projectRepoMock.Object, _skillRepoMock.Object);
        }

        [Fact]
        public async Task GetAllProjectsAsync_ShouldReturnProjects()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project { Id = 1, Name = "Test Project" }
            };
            _projectRepoMock
                .Setup(r => r.GetAllAsync(false, false))
                .ReturnsAsync(projects);

            // Act
            var result = await _service.GetAllProjectsAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal("Test Project", result.First().Name);
        }

        [Fact]
        public async Task GetProjectByIdAsync_ShouldReturnDto_WhenFound()
        {
            // Arrange
            var project = new Project { Id = 1, Name = "Proj" };
            _projectRepoMock
                .Setup(r => r.GetByIdAsync(1, false, false))
                .ReturnsAsync(project);

            // Act
            var result = await _service.GetProjectByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Proj", result.Name);
        }

        [Fact]
        public async Task GetProjectByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            _projectRepoMock
                .Setup(r => r.GetByIdAsync(1, false, false))
                .ReturnsAsync((Project)null);

            // Act
            var result = await _service.GetProjectByIdAsync(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddProjectAsync_ShouldThrowSkillNotFoundException_WhenMissingSkills()
        {
            // Arrange
            var dto = new CreateProjectDto
            {
                Name = "Proj",
                SkillIds = new List<int> { 1, 2 }
            };

            _skillRepoMock
                .Setup(r => r.GetByIdsAsync(dto.SkillIds, false, false))
                .ReturnsAsync(new List<Skill> { new Skill { Id = 1, Name = "C#" } });

            // Act & Assert
            await Assert.ThrowsAsync<SkillNotFoundException>(() => _service.AddProjectAsync(dto));
        }

        [Fact]
        public async Task AddProjectAsync_ShouldAddProject_WhenAllSkillsExist()
        {
            // Arrange
            var dto = new CreateProjectDto
            {
                Name = "Proj",
                SkillIds = new List<int> { 1 }
            };

            var skills = new List<Skill> { new Skill { Id = 1, Name = "C#" } };
            _skillRepoMock
                .Setup(r => r.GetByIdsAsync(dto.SkillIds, false, false))
                .ReturnsAsync(skills);

            // Act
            await _service.AddProjectAsync(dto);

            // Assert
            _projectRepoMock.Verify(r => r.AddAsync(It.Is<Project>(p => p.Name == "Proj")), Times.Once);
            _projectRepoMock.Verify(r => r.SaveAsync(), Times.Once);
        }
    }
}
