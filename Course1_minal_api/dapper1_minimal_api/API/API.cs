using Data_Access.Models;
using Microsoft.AspNetCore.Mvc;

namespace API
{
     public static class Apiconfig
    {


        public static void ConfigurationAPI(this WebApplication app) {

            app.MapGet("/GetAll", GetAll);
            app.MapGet("/Get", Get);
            app.MapPost("/AddOrUpdate", AddOrUpdate);
            app.MapGet("/delete", Delete);

        }

        public async static Task<IResult> GetAll(IUserData _ud)
        {
            try
            {
                var results = await _ud.GetAll();
                return Results.Ok(results);
            }catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


        public async static Task<IResult> Get(int Id , IUserData _ud)
        {
            try
            {
                var result = await _ud.Get(Id);
                return Results.Ok(result);
            }catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


        public async static Task<IResult> AddOrUpdate([FromBody]UserModel userModel , IUserData _ud)
        {
            try
            {
                await _ud.AddOrUpdate(userModel); 
                return Results.Ok("successfull");
            }catch( Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }



        public async static Task<IResult> Delete(int Id , IUserData _ud)
        {
            try
            {
                await _ud.Delete(Id);
                return Results.Ok();
            }catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
