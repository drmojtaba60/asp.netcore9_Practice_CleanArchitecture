//using MyPractice.Localization.Resources;

using MyPractice.Application.Contract.Command;
using MyPractice.CleanArchitecture.Domain.Enums;

namespace MyPractice.Application.Contract.Exceptions;

//public class TodoListTitleNullException() : Exception(TodoListResource.NotNullTitle);

public class TodoListTitleNullException : BaseException
{
    public TodoListTitleNullException() 
        : base(ResourceType.TodoList, "NotNullTitle") {}
}
