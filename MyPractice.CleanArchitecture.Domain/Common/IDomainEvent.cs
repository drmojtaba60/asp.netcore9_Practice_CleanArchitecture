﻿namespace MyPractice.CleanArchitecture.Domain.Common;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
