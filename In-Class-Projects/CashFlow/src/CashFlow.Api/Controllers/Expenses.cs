using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;
using CashFlow.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly CashFlowDbContext _dbContext;

    public ExpensesController(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Register(
        [FromServices] IRegisterExpenseUseCase useCase,
        [FromBody] RequestRegisterExpenseJson request)
    {
        var response = useCase.Execute(request);

        return Ok(response);
    }
}