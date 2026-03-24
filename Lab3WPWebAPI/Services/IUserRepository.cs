using Lab3WPWebAPI.Models.Entities;

namespace Lab3WPWebAPI.Services;

public interface IUserRepository
{
    Task<ICollection<ApplicationUser>> ReadAllAsync();

}