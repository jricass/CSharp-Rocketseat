﻿using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pets.Delete;
using Petfolio.Application.UseCases.Pets.GetAll;
using Petfolio.Application.UseCases.Pets.GetById;
using Petfolio.Application.UseCases.Pets.Register;
using Petfolio.Application.UseCases.Pets.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost] // Registro
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestPetJson request)
    {
        // business logic
        var useCase = new RegisterPetUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestPetJson request)
    {
        var useCase = new UpdatePetUseCase();

        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllPetsUseCase();

        var response = useCase.Execute();

        if (response.Pets.Any())
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult GetById(int id)
    {
        var useCase = new GetPetByIdUseCase();

        var response = useCase.Execute(id);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Delete(int id)
    {
        var useCase = new DeletePetByIdUseCase();

        useCase.Execute(id);

        return NoContent();
    }
}
