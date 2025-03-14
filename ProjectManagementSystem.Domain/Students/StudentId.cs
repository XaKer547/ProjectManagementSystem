﻿using SharedKernel;

namespace ProjectManagementSystem.Domain.Students;

public sealed class StudentId : EntityId
{
    public StudentId(Guid id) : base(id) { }
    public StudentId() : base() { }
}