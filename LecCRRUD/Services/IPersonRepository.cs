using LecCRRUD.Models.Entities;

namespace LecCRRUD.Services;

public interface IPersonRepository
{
    Task<ICollection<Person>> ReadAllAsync();
}