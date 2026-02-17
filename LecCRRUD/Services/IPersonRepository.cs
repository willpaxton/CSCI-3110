using LecCRRUD.Models.Entities;

namespace LecCRRUD.Services;

public interface IPersonRepository
{
    Task<ICollection<Person>> ReadAllAsync();
    Task<Person> CreateAsync(Person newPerson);
    // we want this to be nullable since the id may not exist, and therefore, we would get back null
    Task<Person?> ReadAsync(int id);
    Task UpdateAsync(int oldId, Person person);
    Task DeleteAsync(int id);
}