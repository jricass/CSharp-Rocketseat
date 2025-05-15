namespace TaskManager.Exception_.ExceptionsBase;
public class ErrorOnValidationException : TaskManagerException
{
    public List<string> Errors { get; set; }
    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
