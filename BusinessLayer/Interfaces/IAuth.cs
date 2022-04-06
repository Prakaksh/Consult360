using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface  IAuth
    {
        Task<ResponseStatus> CreateOTP();
        Task<bool> ValidatePhoneNumber(string PhoneNumber);
        Task<bool> ValidateOTP(string PhoneNumber,string OTP);
        Task<User> GetPortalUserDetails(string PhoneNumber);

    }
}
