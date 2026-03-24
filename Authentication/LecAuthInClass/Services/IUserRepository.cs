namespace LecAuthInClass.Services;
using LecAuthInClass.Models.Entities;



public interface IUserRepository
{
    Task<ApplicationUser?> ReadByUsernameAsync(string username);
}