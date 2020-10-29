using MongoCRUD.Data.Entities;
using MongoCRUD.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoCRUD.Services.Users
{
    public interface IUserService
    {
        Task<BaseResponse<User>> GetUserByIdAsync(int id);

        Task<List<User>> GetAllUsersAsync();

        Task<BaseResponse<User>> UpdateUserAsync(User model);

        Task<BaseResponse<int>> InsertUserAsync(User model);

        Task DeleteUserAsync(int id);

    }
}