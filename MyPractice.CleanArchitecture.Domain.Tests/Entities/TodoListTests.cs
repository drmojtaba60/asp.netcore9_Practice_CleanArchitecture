using FluentAssertions;
using MyPractice.CleanArchitecture.Domain.Entities;
using MyPractice.CleanArchitecture.Domain.ValueObjects;

namespace MyPractice.CleanArchitecture.Domain.Tests.Entities;

public class TodoListTests
{
    [Fact]
    public void Constructor_ShouldSetProperties()
    {
        // Arrange
        const int actorId = 1;
        const int id = 0;
        var title = "ToDo1";
        
        // Act
        var todoList = new TodoList(title,Colour.Blue,actorId,id);
        
        // Assert
        Assert.Equal(title,todoList.Title);
        Assert.Equal(id,todoList.Id);
        Assert.Equal(actorId,todoList.CreatedBy);
        Assert.Equal(Colour.Blue.ToString(), todoList.Colour.ToString());
    }
    
    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenTitleIsNullSimple()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            string title = string.Empty; // null
            var todoList = new TodoList(title,Colour.Grey,0,0);
        });
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("Test")]
    public void Constructor_ShouldThrowArgumentNullException_WhenTitleIsNull(string title)
    {
        var action = () =>
        {
            var todoList = new TodoList(title, Colour.Green, 0, 0);
        };
        Assert.Throws<ArgumentNullException>(action);
    }
    
    [Theory]
    [InlineData("Test")]
    [InlineData("123")]
    public void Theory_ShouldThrowArgumentNotNullException_WhenTitleIsNotNull_WithInlineData(string title)
    {
        var action = () =>
        {
            var todoList = new TodoList(title, Colour.Green, 0, 0);
        };
        action.Should().NotThrow();
    }
    [Fact]
    public void Constructor_ShouldThrowArgumentNotNullException_WhenTitleIsNotNull()
    {
        var action = () =>
        {
            var todoList = new TodoList("test", Colour.Green, 0, 0);
        };
        action.Should().NotThrow();
    }
}