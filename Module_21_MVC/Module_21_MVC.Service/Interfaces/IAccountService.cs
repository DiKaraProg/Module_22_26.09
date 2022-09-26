using Module_21_MVC_Domain.Entity;
using Module_21_MVC_Domain.Response;
using Module_21_MVC_Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        ClaimsIdentity Authenticate(User user);
    }
}
