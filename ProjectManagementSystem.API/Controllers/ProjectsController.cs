using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Infrastucture.Models;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Application.Commands.ProjectStageAnswers;
using ProjectManagementSystem.Application.Queries.Projects;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Students;
using SharedKernel.DTOs.Projects;
using SharedKernel.DTOs.ProjectStages;
using ProjectManagementSystem.Domain.StudentProjectStages;

namespace ProjectManagementSystem.Infrastucture.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProjectsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    /// <summary>
    /// Добавить студенческую работу
    /// </summary>
    /// <response code="201">Успешно создана</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на добавление студенческой работы</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> CreateProject(CreateProjectDTO createProject)
    {
        var command = new CreateProjectCommand()
        {
            Name = createProject.Name,
            SubjectArea = createProject.SubjectArea,
            ProjectType = createProject.ProjectType,
            DisciplineId = new DisciplineId(createProject.DisciplineId),
            GroupId = new GroupId(createProject.GroupId)
        };

        var projectId = await mediator.Send(command);

        return Created(string.Empty, projectId);
    }

    /// <summary>
    /// Получить студенческие работу
    /// </summary>
    /// <response code="200"></response>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IReadOnlyCollection<ProjectDTO>))]
    public async Task<IActionResult> GetProjects()
    {
        var query = new GetProjectsQuery();

        var projects = await mediator.Send(query);

        return Ok(projects);
    }

    /// <summary>
    /// Получить студенческую работу
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <response code="200"></response>
    /// <response code="404">работа не найдена</response>
    [HttpGet("{projectId}")]
    [ProducesResponseType(200, Type = typeof(ProjectDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProject(Guid projectId)
    {
        var query = new GetProjectQuery()
        {
            ProjectId = new ProjectId(projectId)
        };

        var project = await mediator.Send(query);

        return Ok(project);
    }

    /// <summary>
    /// Завершить студенческую работу
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <response code="200"></response>
    /// <response code="400">Работа уже завершена</response>
    /// <response code="403">Пользователь не имеет доступ на завершение студенческой работы</response>
    /// <response code="404">работа не найдена</response>
    [HttpPatch("{projectId}/complete")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> CompleteProject(Guid projectId)
    {
        var command = new CompleteProjectCommand()
        {
            ProjectId = new ProjectId(projectId)
        };

        await mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Обновить работу
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="updateProject"></param>
    /// <response code="204">Успешное обновление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на изменение работы</response>
    /// <response code="404">работа не найдена</response>
    [HttpPatch("{projectId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateProject(Guid projectId, UpdateProjectDTO updateProject)
    {
        var command = new UpdateProjectCommand()
        {
            ProjectId = new ProjectId(projectId),
            Name = updateProject.Name,
            SubjectArea = updateProject.SubjectArea,
            DisciplineId = new DisciplineId(updateProject.DisciplineId),
            GroupId = new GroupId(updateProject.GroupId),
            ProjectType = updateProject.ProjectType
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Добавить этап работы
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="model"></param>
    /// <response code="201">Успешно добавлен</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на добавление этапов работы</response>
    /// <response code="404">работа не найдена</response>
    [HttpPost("{projectId}/stages")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> AddProjectStage(Guid projectId, CreateProjectStageModel model)
    {
        var command = new CreateProjectStageCommand()
        {
            ProjectId = new ProjectId(projectId),
            Deadline = model.CreateProjectStage.Deadline,
            Description = model.CreateProjectStage.Description,
            Name = model.CreateProjectStage.Name,
            PinnedFiles = model.Files?.ToDTO()
            .ToArray()
        };

        var projectStageId = await mediator.Send(command);

        return Created(string.Empty, projectStageId);
    }

    /// <summary>
    /// Обновить этап работы
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="stageId">Идентификатор этапа работы</param>
    /// <param name="model"></param>
    /// <response code="204">Успешное обновление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на изменение этапа работы</response>
    /// <response code="404">работа не найдена</response>
    [HttpPatch("{projectId}/stages/{stageId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateProjectStage(Guid projectId, Guid stageId, UpdateProjectStageModel model)
    {
        var command = new UpdateProjectStageCommand()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new ProjectStageId(stageId),
            Deadline = model.UpdateProjectStage.Deadline,
            Description = model.UpdateProjectStage.Description,
            Name = model.UpdateProjectStage.Name,
            PinnedFiles = model.Files?.ToDTO()
            .ToArray()
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Удалить этап работы
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="stageId">Идентификатор этапа работы</param>
    /// <response code="204">Успешное удаление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на удаление этапа работы</response>
    /// <response code="404">работа не найдена</response>
    [HttpDelete("{projectId}/stages/{stageId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteProjectStage(Guid projectId, Guid stageId)
    {
        var command = new DeleteProjectStageCommand()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new ProjectStageId(stageId),
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Получить этапы работы
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <response code="200"></response>
    /// <response code="404">работа не найдена</response>
    [HttpGet("{projectId}/stages")]
    [ProducesResponseType(200, Type = typeof(IReadOnlyCollection<ProjectStageDTO>))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProjectStages(Guid projectId)
    {
        var query = new GetProjectStagesQuery()
        {
            ProjectId = new ProjectId(projectId)
        };

        var stages = await mediator.Send(query);

        return Ok(stages);
    }

    /// <summary>
    /// Получить этапы работы
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="stageId">Идентификатор этапа работы</param>
    /// <response code="200"></response>
    /// <response code="404">работа или этап работы не найден</response>
    [HttpGet("{projectId}/stages/{stageId}")]
    [ProducesResponseType(200, Type = typeof(ProjectStageDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProjectStage(Guid projectId, Guid stageId)
    {
        var query = new GetProjectStageQuery()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new StudentProjectStageId(stageId)
        };

        var stage = await mediator.Send(query);

        return Ok(stage);
    }

    /// <summary>
    /// Отправить ответ на задание
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="stageId">Идентификатор этапа работы</param>
    /// <param name="file"></param>
    /// <response code="200"></response>
    /// <response code="404">работа или этап работы не найден</response>
    [HttpPost("{projectId}/stages/{stageId}/answer")]
    [ProducesResponseType(201, Type = typeof(ProjectStageDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> AnswerStage(Guid projectId, Guid stageId, IFormFile file)
    {
        var command = new CreateProjectStageAnswerCommand()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new StudentProjectStageId(stageId),
            PinnedFile = file.ToDTO()
        };

        var answerId = await mediator.Send(command);

        return Created(string.Empty, answerId);
    }

    /// <summary>
    /// Вернуть работу студента
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="stageId">Идентификатор этапа работы</param>
    /// <param name="model"></param>
    /// <response code="201"></response>
    /// <response code="404">работа или этап работы не найден</response>
    [HttpPatch("{projectId}/stages/{stageId}/answer/return")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> ReturnStageAnswer(Guid projectId, Guid stageId, ReturnStageAnswerModel model)
    {
        var command = new ReturnProjectStageAnswerCommand()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new StudentProjectStageId(stageId),
            Remark = model.Remark,
            PinnedFile = model.File?.ToDTO()
        };

        await mediator.Send(command);

        return Created();
    }

    /// <summary>
    /// Изменить ответ на задание
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="stageId">Идентификатор этапа работы</param>
    /// <param name="file"></param>
    /// <response code="204"></response>
    /// <response code="404">работа или этап работы не найден</response>
    [HttpPatch("{projectId}/stages/{stageId}/answer")]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> ChangeStageAnswer(Guid projectId, Guid stageId, IFormFile file)
    {
        var command = new UpdateProjectStageAnswerCommand()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new StudentProjectStageId(stageId),
            PinnedFile = file.ToDTO()
        };

        await mediator.Send(command);

        return Created();
    }

    /// <summary>
    /// Выставить оценку за этап
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="stageId">Идентификатор этапа работы</param>
    /// <response code="204"></response>
    /// <response code="404">работа или этап работы не найден</response>
    [HttpPatch("{projectId}/stages/{stageId}/grade")]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GradeProjectStage(Guid projectId, Guid stageId, GradeProjectStageDTO gradeProjectStage)
    {
        var command = new GradeProjectStageCommand()
        {
            ProjectId = new ProjectId(projectId),
            StudentId = new StudentId(gradeProjectStage.StudentId),
            ProjectStageId = new StudentProjectStageId(stageId),
            Grade = gradeProjectStage.Grade,
        };

        await mediator.Send(command);

        return Created();
    }

    /// <summary>
    /// Выставить итоговую оценку
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="gradeProject"></param>
    /// <response code="204"></response>
    /// <response code="404">работа или этап работы не найден</response>
    [HttpPatch("{projectId}/grade")]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GradeProject(Guid projectId, GradeProjectDTO gradeProject)
    {
        var command = new GradeProjectCommand()
        {
            ProjectId = new ProjectId(projectId),
            StudentId = new StudentId(gradeProject.StudentId),
            Grade = gradeProject.Grade,
        };

        await mediator.Send(command);

        return Created();
    }

    /// <summary>
    /// Получить ведомость итоговых оценок
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <response code="204"></response>
    /// <response code="404">работа или этап работы не найден</response>
    [HttpGet("{projectId}/reports/final-grades")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetFinalGradesReport(Guid projectId)
    {
        var query = new GetProjectFinalGradesQuery()
        {
            ProjectId = new ProjectId(projectId)
        };

        var grades = await mediator.Send(query);

        return File(grades.File, "text/csv", grades.Name);
    }

    /// <summary>
    /// Получить ведомость распределенных работ
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <response code="204"></response>
    /// <response code="404">работа или этап работы не найден</response>
    [HttpGet("{projectId}/reports/work-assingment")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetWorkAssingmentReport(Guid projectId)
    {
        var query = new GetProjectWorkAssignmentQuery()
        {
            ProjectId = new ProjectId(projectId)
        };

        var assignment = await mediator.Send(query);

        return File(assignment.File, "text/csv", assignment.Name);
    }
}