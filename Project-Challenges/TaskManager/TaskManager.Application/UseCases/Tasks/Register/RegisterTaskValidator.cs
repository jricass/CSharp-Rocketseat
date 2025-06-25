using FluentValidation;
using TaskManager.Communication.Requests;
using TaskManager.Exception_;

namespace TaskManager.Application.UseCases.Tasks.Register;
public class RegisterTaskValidator : AbstractValidator<RequestRegisterTaskJson>
{
    public RegisterTaskValidator()
    {
        RuleFor(task => task.Name).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(task => task.Status).IsInEnum().WithMessage(ResourceErrorMessages.TASK_STATUS_INVALID);
        RuleFor(task => task.Priority).IsInEnum().WithMessage(ResourceErrorMessages.TASK_PRIORITY_TYPE_INVALID);
    }
}
