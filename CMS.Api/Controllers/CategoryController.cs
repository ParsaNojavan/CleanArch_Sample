using AutoMapper;
using CMS.Application.Interfaces.Repository;
using CMS.Application.Models;
using CMS.Domain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers;

[ApiController]
[Route("/api/category")]
public class CategoryController : BaseController
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryController(ICategoryRepository categoryRepository
        , IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet("GetCategory/{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        try
        {
            var category = await _categoryRepository.GetById(id);
            return CustomOk(category);
        }
        catch (Exception e)
        {
            return CustomError(message:e.Message);
        }
    }

    [HttpGet("/GetCategories")]
    public async Task<IActionResult> GetCategories()
    {
        try
        {
            var category = await _categoryRepository.GetAll();
            return CustomOk(category);
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
            await _categoryRepository.Add(_mapper.Map<Domain.Domain.Category>(category));
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
            await _categoryRepository.Edit(_mapper.Map<Domain.Domain.Category>(category));
            return CustomOk(data:category,message:"Category updated successfully");
        }
        catch (Exception e)
        {
            return CustomError(message:e.Message);
        }
    }
}