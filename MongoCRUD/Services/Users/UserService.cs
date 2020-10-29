using MongoCRUD.Data.Entities;
using MongoCRUD.Data.Repositories;
using MongoCRUD.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoCRUD.Services.Users
{
    public class UserService : IUserService
    {
        private readonly MongoRepository<User> _userRepository;
        public UserService(MongoRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(Convert.ToString(id));
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<BaseResponse<User>> GetUserByIdAsync(int id)
        {
            var response = new BaseResponse<User>();
            var document = await _userRepository.GetByIdAsync(Convert.ToString(id));
            if (document != null)
            {
                response.Data = document;
                return response;
            }
            response.Errors.Add($"{id}'li kullanıcı bulunamadı");
            return response;
        }

        public async Task<BaseResponse<int>> InsertUserAsync(User model)
        {
            var response = new BaseResponse<int>();
            var result = await _userRepository.InsertAsync(model);
            if (Convert.ToInt32(result.Id) != default)
            {
                response.Data = Convert.ToInt32(result.Id);
                return response;
            }
            response.Errors.Add("Kullanıcı kayıt işlemi sırasında hata oluştu");
            return response;
        }

        public async Task<BaseResponse<User>> UpdateUserAsync(User model)
        {
            var response = new BaseResponse<User>();
            var document = await _userRepository.UpdateAsync(Convert.ToString(model.Id), model);
            if (document == null)
            {
                response.Errors.Add("Kullanıcı güncelleme sırasında bir hata oluştu");
                return response;
            }
            response.Data = document;
            return response;
        }
    }
}
