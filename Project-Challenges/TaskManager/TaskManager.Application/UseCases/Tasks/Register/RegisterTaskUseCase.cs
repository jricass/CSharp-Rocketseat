using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;
using TaskManager.Exception_.ExceptionsBase;

namespace TaskManager.Application.UseCases.Tasks.Register;
public class RegisterTaskUseCase
{
    public ResponseRegisterTaskJson Execute(RequestRegisterTaskJson request)
    {
        Validate(request);

        return new ResponseRegisterTaskJson();
    }

    private void Validate(RequestRegisterTaskJson request)
    {
        var validator = new RegisterTaskValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
