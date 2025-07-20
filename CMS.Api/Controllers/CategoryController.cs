using AutoMapper;
using CMS.Application.Commands;
using CMS.Application.Interfaces.Repository;
using CMS.Application.Models.Dto.CategoryDto;
using CMS.Application.Queries;
using CMS.Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers;

[ApiController]
[Route("/api/category")]
public class CategoryController : BaseController
{
    private readonly IMediator _mediator;
    public CategoryController(ICategoryRepository categoryRepository
        , IMapper mapper,IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetCategory/{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        try
        {
            var query = new GetCategoryByIdQuery(){Id = id};
            var result = await _mediator.Send(query);
            return CustomOk(result);
        }
        catch (Exception e)
        {
            return CustomError(message:e.Message);
        }
    }

    [HttpGet("GetAllCategories")]
    public async Task<IActionResult> GetCategories()
    {
        try
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);
            return CustomOk(result);
        }
        catch (Exception e)
        {
            return CustomError(message:e.Message);
        }
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory([FromBody] CategoryAddDto category)
    {
        try
        {
            var command = new CategoryAddCommand()
            {
                Title = category.Title
            };
            var result = await _mediator.Send(command);
            return CustomOk(true);
        }
        catch (Exception e)
        {
            return CustomError(message:e.Message);
        }
    }

    [HttpPut("UpdateCategory/{id}")]
    public async Task<IActionResult> UpdateCategory(int id,[FromBody] CategoryEditDto category)
    {
        if (id == null)
        {
            return CustomError(message:"Id cannot be null");
        }else if (id != category.Id)
        {
            return CustomError("Ids don't match");
        }

        try
        {
            var command = new CategoryEditCommand()
            {
                Id = id,
                Title = category.Title
            };
            var result = await _mediator.Send(command);
            return CustomOk(data:result,message:"Category updated successfully");
        }
        catch (Exception e)
        {
            return CustomError(message:e.Message);
        }
    }
}