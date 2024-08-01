using Data_Access.Models;

namespace Data_Access.Data
{
    public interface IUserData
    {
        Task AddOrUpdate(UserModel userModel);
        Task Delete(int Id);
        Task<UserModel> Get(int Id);
        Task<IEnumerable<UserModel>> GetAll();
    }
}