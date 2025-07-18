using CMS.Domain.Domain;

namespace CMS.Application.Interfaces.Repository;

public interface ICategoryRepository
{
    Task<Category> GetById(int id);
    Task<List<Category>> GetAll();
    Task<bool> Add(Category category);
    Task<Category> Edit(Category category);
    Task Delete(int id);
}