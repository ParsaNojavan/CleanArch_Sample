using System.Data;
using AutoMapper;
using CMS.Application.Interfaces.Repository;
using CMS.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Data.Respository;

public class CategoryRepository : ICategoryRepository
{
    private readonly CmsDbContext _context;
    private readonly IMapper _mapper;
    
    public CategoryRepository(CmsDbContext context
        , IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Domain.Domain.Category> GetById(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        return (_mapper.Map<Domain.Domain.Category>(category));
    }

    public async Task<List<Domain.Domain.Category>> GetAll()
    {
        var categories = await _context.Categories.ToListAsync();
        return (_mapper.Map<List<Domain.Domain.Category>>(categories));
    }

    public async Task<bool> Add(Domain.Domain.Category category)
    {
        var data =  _mapper.Map<Infrastructure.Data.Category>(category);
        await _context.Categories.AddAsync(data);
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DBConcurrencyException e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<Domain.Domain.Category> Edit(Domain.Domain.Category category)
    {
        var item = await _context.Categories.FirstOrDefaultAsync(c=>c.Id == category.Id);
        if (item == null)
            throw new Exception("Category not found");
        _mapper.Map(category, item);
        _context.Categories.Update(item);
        await _context.SaveChangesAsync();
        return (_mapper.Map<Domain.Domain.Category>(item));
    }

    public async Task Delete(int id)
    {
        var data = await _context.Categories.FirstOrDefaultAsync(c=>c.Id == id);
        if (data != null)
        {
            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new DBConcurrencyException();
        }
    }
}