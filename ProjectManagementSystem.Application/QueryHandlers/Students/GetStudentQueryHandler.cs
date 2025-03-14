﻿using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Queries.Students;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.Students;

namespace ProjectManagementSystem.Application.QueryHandlers.Students;

public sealed class GetStudentQueryHandler(IUnitOfWork unitOfWork, IValidator<GetStudentQuery> validator) : IRequestHandler<GetStudentQuery, StudentDTO>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GetStudentQuery> validator = validator;

    public async Task<StudentDTO> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var student = unitOfWork.Repository.Students.Where(s => s.Id == request.StudentId)
            .Select(s => new StudentDTO
            {
                Id = s.Id.Value,
                FirstName = s.FirstName,
                MiddleName = s.MiddleName,
                LastName = s.LastName,
                Graduated = s.Graduated,
            }).Single();

        return student;
    }
}