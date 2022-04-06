using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLayer.Utility.SqlUtility;

namespace DataLayer.DBContext
{
    public class AuthUserDBContext: GenericDBContext
    
    {
        public User GetUserDetailByEmail(string email)
        {
            var com = new DynamicParameters();
            //com.Add("@Email", email);
            return Get<User>(com, "Get_SampleSp").FirstOrDefault(); 
        }

        public async Task<ResponseStatus> CreateOTP(string PhoneNumber, string UserLoginOTPDetails)
        {
            var com = new DynamicParameters();
            com.Add("@PhoneNumber", PhoneNumber);
            com.Add("@P_UserLoginOTP_Details", UserLoginOTPDetails);
            return await Task.Run(()=>Get<ResponseStatus>(com, "Create_OTP").FirstOrDefault());
        }

        public async Task<bool> ValidateOTP(string PhoneNumber, string OTP)
        {
            var com = new DynamicParameters();
            com.Add("@PhoneNumber", PhoneNumber);
            com.Add("@P_UserLoginOTP_Details", OTP);
            return await Task.Run(() => Get<bool>(com, "Get_OTPValidated").FirstOrDefault());
        }
        public async Task<User> GetPortalUserDetails(string PhoneNumber)
        {
            var com = new DynamicParameters();
            com.Add("@PhoneNumber", PhoneNumber);
            return await Task.Run(() => Get<User>(com, "Get_PortalUser_Details").FirstOrDefault());
        }

        



        public string ValidateUser(LoginUser login)
        {
            var com = new DynamicParameters();
            com.Add("@Email", login.Email);
            com.Add("@Password", login.Password);
            return Get<string>(com, "USP_ValidateUser").FirstOrDefault();
        }


        public async Task<bool> ValidatePhoneNumber(string PhoneNumber)
        {
            var com = new DynamicParameters();
            com.Add("@PhoneNumber", PhoneNumber);
            return await Task.Run(()=> Get<bool>(com, "USP_ValidatePhoneNumber").FirstOrDefault()) ;
        }
      
    }
}
