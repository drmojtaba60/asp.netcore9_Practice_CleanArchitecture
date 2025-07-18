using MyPractice.Localization.Resources;

namespace MyPractice.Application.Contract.Exceptions;

public class TodoListTitleNullException() : Exception(TodoListResource.NotNullTitle);