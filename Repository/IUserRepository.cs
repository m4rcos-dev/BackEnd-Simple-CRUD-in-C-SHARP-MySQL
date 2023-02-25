using BackEnd_Simple_CRUD_in_C_SHARP_MySQL.Models;

namespace BackEnd_Simple_CRUD_in_C_SHARP_MySQL.Repository
{
  public interface IUserRepository
    {
      Task<List<UserModel>> GetAllUsers();
      Task<UserModel> GetById(int id);
      void CreateUser(UserModel user);
      void UpdateUser(UserModel user);
      void DeleteUser(UserModel user);
      Task<bool> SaveChangeAsync();
    }
}
