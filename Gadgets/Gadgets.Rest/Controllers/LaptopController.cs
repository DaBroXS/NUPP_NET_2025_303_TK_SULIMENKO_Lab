using Gadgets.Common.Contracts;
using Gadgets.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gadgets.Rest.Controllers;

[Route("/laptops")]
public class LaptopController : ControllerBase
{
    [HttpGet] 
    public async Task<IResult> GetAll(
        [FromServices] IAsyncCrudService<LaptopModel> service)
    {
        try
        {
            return Results.Ok(await service.ReadAllAsync());
        }
        catch (Exception ex)
        {
            return Results.Problem(
                title: "Помилка при обробці запиту",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IResult> Get(
        [FromRoute] Guid id,
        [FromServices] IAsyncCrudService<LaptopModel> service)
    {
        try
        {
            var laptop = await service.ReadAsync(id);
    
            if (laptop == null)
            {
                return Results.NotFound($"Ноутбук з id {id} не знайдено");
            }
    
            return Results.Ok(laptop);
        }
        catch (Exception ex)
        {
            return Results.Problem(
                title: "Помилка при обробці запиту",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IResult> Create(
        [FromBody] LaptopModel value,
        [FromServices] IAsyncCrudService<LaptopModel> service)
    {
        try
        {
            var result = await service.CreateAsync(value);
    
            if (result)
                return Results.Created($"/laptops/{value.Id}", value);
    
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(
                title: "Помилка при обробці запиту",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
    
    [Authorize(Roles = Roles.Admin)]
    [HttpPatch("{id:guid}")]
    public async Task<IResult> Update(
        [FromRoute] Guid id,
        [FromBody] LaptopModel value,
        [FromServices] IAsyncCrudService<LaptopModel> service)
    {
        try
        {
            value.Id = id;
            
            var result = await service.UpdateAsync(value);
    
            if (result)
                return Results.Ok(value);
    
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(
                title: "Помилка при обробці запиту",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
    
    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(
        [FromRoute] Guid id,
        [FromServices] IAsyncCrudService<LaptopModel> service)
    {
        try
        {
            var found = await service.ReadAsync(id);
    
            if (found == null)
                return Results.NotFound();
            
            var result = await service.RemoveAsync(found);
    
            if (result)
                return Results.Ok();
    
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(
                title: "Помилка при обробці запиту",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
    
    [Authorize]
    [HttpPost("/grant/{role}")]
    public async Task<IResult> Grant(
        [FromRoute] string role,
        [FromServices] UserManager<IdentityUser> userManager)
    {
        try
        {
            var user = await userManager.GetUserAsync(User);
            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
                return Results.Ok();
            }
            
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(
                title: "Помилка при обробці запиту",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
}