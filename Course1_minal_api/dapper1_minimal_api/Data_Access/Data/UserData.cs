using Data_Access.DBAccess;
using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Data
{
    public class UserData : IUserData
    {
        private readonly IDataAccess _da;

        public UserData(IDataAccess da)
        {
            _da = da;
        }


        // Getall () 

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _da.LoadData<UserModel, dynamic>("dbo.user_GetAll", null);
        }





        public async Task<UserModel> Get(int Id)
        {
            var result = await _da.LoadData<UserModel, dynamic>("dbo.user_Get", new { Id = Id });

            return result.FirstOrDefault();
        }





        public async Task AddOrUpdate(UserModel userModel)
        {

            var userexist = this.Get(userModel.Id);

            if (userexist != null)
            {
                await _da.SaveData<UserModel>("dbo.Update", userModel);
                return;
            }
            await _da.SaveData<UserModel>("dbo.Insert", userModel);

            return;

        }



        public async Task Delete(int Id)
        {
            var userexist = this.Get(Id);

            if (userexist != null)
            {
                await _da.SaveData<dynamic>("dbo.Delete", new { Id = Id });
            }

            return;
        }



    }
}
