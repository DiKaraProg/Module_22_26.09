using Module_21_MVC.Dal.Interfaces;
using Module_21_MVC.Service.Interfaces;
using Module_21_MVC_Domain.Entity;
using Module_21_MVC_Domain.Helpers;
using Module_21_MVC_Domain.Response;
using Module_21_MVC_Domain.Unum;
using Module_21_MVC_Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<User> userRepository;

        public AccountService(IBaseRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            var user = await userRepository.GetByName(model.Name);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>()
                { Description = "Пользователь не найден" };
            }
            if (user.Password!=HashPasswordHelper.HashPassword(model.Password))
            {
                return new BaseResponse<ClaimsIdentity>()
                { Description = "Неверный пароль" };
            }

            
                var result = Authenticate(user);

            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                StatuseCode = StatusCode.OK,
            };
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            var user = userRepository.GetByName(model.Name);
            if (user==null)
            {
                return new BaseResponse<ClaimsIdentity>()
                { Description = "Пользоваель не найден" };
            }
              var  newuser = new User()
                {
                    Name = model.Name,
                    Role = model.Role,
                    Password = HashPasswordHelper.HashPassword(model.Password),
                };

            await userRepository.Create(newuser);
            var result = Authenticate(newuser);
            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description ="OK"
            };
        }
        public ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims,"ApplicationCookie",ClaimsIdentity.DefaultNameClaimType,ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
