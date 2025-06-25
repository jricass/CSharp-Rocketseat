using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Entities;
using TaskManager.Application.UseCases.Tasks.Register;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private static List<TaskItem> Tasks = [];
    private static int nextId = 0;
    
    [HttpPost]
    public IActionResult Register(RequestRegisterTaskJson request)
    {
        var useCase = new RegisterTaskUseCase();

        var response = useCase.Execute(request);

        TaskItem task = new TaskItem()
        {
            Id = nextId++,
            Name = request.Name,
            Description = request.Description,
            DateLimit = request.DateLimit,
            Priority = request.Priority,
            Status = request.Status
        };

        Tasks.Add(task);

        return Created();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = Tasks.Select(task => new TaskResponseJson
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            DateLimit = task.DateLimit,
            Priority = task.Priority,
            Status = task.Status
        });
        
        return Ok(Tasks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return NotFound(new { message = "Tarefa não encontrada." });

        var response = new TaskResponseJson
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            DateLimit = task.DateLimit,
            Priority = task.Priority,
            Status = task.Status
        };

        return Ok(response);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] RequestRegisterTaskJson request)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return NotFound(new { message = "Tarefa não encontrada para atualização." });

        task.Name = request.Name;
        task.Description = request.Description;
        task.DateLimit = request.DateLimit;
        task.Priority = request.Priority;
        task.Status = request.Status;

        return Ok(new { message = "Tarefa atualizada com sucesso." });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return NotFound(new { message = "Tarefa não encontrada para exclusão." });

        Tasks.Remove(task);

        return Ok(new { message = "Tarefa excluída com sucesso." });
    }
}
