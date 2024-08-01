
namespace Data_Access.DBAccess
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string procedure, U parameters, string connectionId = "Default");
        Task SaveData<T>(string procedure, T parameters, string connectionId = "Default");
    }
}