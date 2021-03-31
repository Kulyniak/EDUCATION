using EDUCATION.Models;
using EDUCATION.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EDUCATION.Services
{
    public class UsersService : BaseService
    {
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            return await GetResponseAsync(async () =>
            {
                var response = new LoginResponse();

                using (var db = new EFDbContext())
                {
                    if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                    {
                        throw new Exception("Incorrect data to login");
                    }

                    var userEntity = await db.Users
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);

                    if(userEntity == null)
                    {
                        throw new Exception("user not found");
                    }

                    response.DisplayName = $"{userEntity.FirstName} {userEntity.LastName}";
                    response.Progress = userEntity.Progress;
                    response.UserId = userEntity.Id;
                    response.UserLevel = userEntity.Level;
                    response.Role = userEntity.Role;
                }

                return response;
            });
        }
    }
}
