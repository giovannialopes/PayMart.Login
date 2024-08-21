﻿using Microsoft.AspNetCore.Mvc;
using PayMart.Application.Login.UseCases.GetUser;
using PayMart.Application.Login.UseCases.RegisterUser;
using PayMart.Domain.Login.Request.GetUser;
using PayMart.Domain.Login.Request.RegisterUser;

namespace PayMart.API.Login.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetUser(
        [FromServices] IGetUserLoginUseCases useCases,
        [FromBody] RequestGetUserLogin request)
    {
        var response = await useCases.Execute(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(
    [FromServices] IRegisterUserLoginUseCases useCases,
    [FromBody] RequestRegisterUserLogin request)
    {
        var response = await useCases.Execute(request);
        return Ok(response);
    }

}
