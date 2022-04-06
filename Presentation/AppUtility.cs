using BusinessLayer.Repository;
using CommonLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Consult360
{
    public static class AppUtility
    {

        public static Auth Decrypt(string AuthHeader)
        {
            //Extract the Header here
            Auth auth = new();
            //MyString.TrimStart(AuthHeader);
            string Token = AuthHeader.Replace("Bearer ", "");

            var tokenS = new JwtSecurityTokenHandler().ReadToken(Token) as JwtSecurityToken;
            var payload = tokenS.Payload;

            foreach (var c in payload)
            {


                if (c.Key == "FirstName")
                {
                    auth.FirstName = c.Value.ToString();
                }
                if (c.Key == "LastName")
                {
                    auth.LastName = c.Value.ToString();
                }
                if (c.Key == "exp")
                {
                    auth.Exp = Convert.ToInt32(c.Value);
                }
                if (c.Key == "UserID")
                {
                    auth.UserID = c.Value.ToString();
                }
                if (c.Key == "CompanyID")
                {
                    auth.CompanyID = Convert.ToInt32(c.Value);
                }

                if (c.Key == "Email")
                {
                    auth.Email = c.Value.ToString();
                }

                if (c.Key == "RoleID")
                {
                    auth.RoleID = Convert.ToString(c.Value);


                }
            }
            return auth;
        }

           // public static User GetUser(string email)
           // {
           //     //Auth obj = Decrypt(token);
           //     User userObj = new AuthUserRepository().GetUserDetailByEmail(email);
           //     return userObj;
           // }

           // public static bool ValidateUser(LoginUser login)
           // {
           //     string res = new AuthUserRepository().ValidateUser(login);
           //     return res == "1" ? true : false;
           // }

           // public static bool ValidateEmail(string email)
           //=> new AuthUserRepository().ValidateEmail(email);

            public static IEnumerable<T> Split<T>(this string source, Func<string, T> converter, params char[] delimiters)
            {
                return source.Split(delimiters).Select(converter);
            }


        }
    }
