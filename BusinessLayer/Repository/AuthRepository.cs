using BusinessLayer.Interfaces;
using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using DataLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class AuthRepository : IAuth
    {
        private readonly AuthUserDBContext _authUserDBContext;
        public AuthRepository()
        {
            _authUserDBContext = new AuthUserDBContext();
        }


        public Task<ResponseStatus> CreateOTP()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetPortalUserDetails(string PhoneNumber)
            => await _authUserDBContext.GetPortalUserDetails(PhoneNumber);
       
        public async Task<bool> ValidateOTP(string PhoneNumber, string OTP)
        {
            return await _authUserDBContext.ValidateOTP(PhoneNumber, OTP);

        }

        public async Task<bool> ValidatePhoneNumber(string PhoneNumber)
        {
            bool result = await _authUserDBContext.ValidatePhoneNumber(PhoneNumber);
            if (result)
            {
                // Generate OTP
                //Generate OTP Logic here
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                string sRandomOTP = GenerateRandomOTP(4, saAllowedCharacters);

                ResponseStatus Response = await _authUserDBContext.CreateOTP(PhoneNumber, sRandomOTP);
                //
                if (Response.StatusCode == 1)
                {
                    // send OTP To Respective Email ID

                }

            }
            return result;
        }


        private string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)

        {

            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;

            }

            return sOTP;

        }
    }
}
