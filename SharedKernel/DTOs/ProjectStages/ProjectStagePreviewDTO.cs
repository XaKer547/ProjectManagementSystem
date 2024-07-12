﻿namespace SharedKernel.DTOs.ProjectStages;

public class ProjectStagePreviewDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime Deadline { get; init; }
}