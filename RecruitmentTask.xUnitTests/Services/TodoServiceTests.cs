using FluentAssertions;
using Moq;
using RecruitmentTask.Domain.Dto;
using RecruitmentTask.Domain.Entities;
using RecruitmentTask.Domain.Repositories;
using RecruitmentTask.Domain.Services;
using RecruitmentTask.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RecruitmentTask.xUnitTests.Services
{
    public class TodoServiceTests
    {
        private readonly Mock<ITodoService> _mockTodoService;
        private readonly Mock<ITodoRepository> _mockTodoRepository;
        private readonly TodoService _service;

        public TodoServiceTests()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);

            _mockTodoService = mockRepository.Create<ITodoService>();
            _mockTodoRepository = mockRepository.Create<ITodoRepository>();
            _service = new TodoService(_mockTodoRepository.Object);
        }

        [Fact]
        public async Task GivenAssetWithValues_WhenDataIsCorrect_ThenReturnsSomeGuid()
        {
            // Arrange
            var guid = new Guid("72ab8981-21cd-4e91-b6e7-7c8bf14ee52f");
            var sampleTodoRequest = new TodoRequestDto( "TestTitle", "TestDescription", DateTime.UtcNow);

            _mockTodoService.Setup(m => m.CreateTodo(sampleTodoRequest))
                .Returns(Task.FromResult(guid));

            _mockTodoRepository.Setup(m => m.CreateAsync(It.IsAny<Todo>()))
                .Returns(Task.FromResult(guid));

            // Act
            var result = await _service.CreateTodo(sampleTodoRequest);

            // Assert
            result.Should().NotBeEmpty().And.Be(guid);
        }

        [Fact]
        public async Task GivenThreeElementsAsResult_WhenDataAreExpired_ThenReturnsThreeExpiredTodos()
        {
            // Arrange
            IEnumerable<TodoDto> optionsService = new List<TodoDto>
            {
                new TodoDto(new Guid(),"","","","", true),
                new TodoDto(new Guid(),"","","","", true),
                new TodoDto(new Guid(),"","","","", true)
            };

            IEnumerable<Todo> optionsRepository = new List<Todo>
            {
                new Todo(),
                new Todo(),
                new Todo()
            };

            _mockTodoService.Setup(m => m.FindExpiredTodos())
                .Returns(Task.FromResult(optionsService));

            _mockTodoRepository.Setup(m => m.FindExpiredTodo())
                .Returns(Task.FromResult(optionsRepository));

            // Act
            var result = await _service.FindExpiredTodos();

            // Assert
            result.Should().NotBeEmpty().And.HaveCount(3);
        }
    }
}
