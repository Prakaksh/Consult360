using System.ComponentModel.DataAnnotations;

namespace CommonLayer.RequestModels
{
    public class Auth : User
    {
        //  public string Email { get; set; }
        public int Exp { get; set; }


    }

    public class User
    {

        public string PortalUser_FirstName { get; set; }
        public string PortalUser_LastName { get; set; }
        public string Practice_Name { get; set; }
        public string Practice_Id { get; set; }
        public string PortalUserRole_Name { get; set; }
        

        public int CompanyID { get; set; }
        
        public string UserID { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? RoleName { get; set; }
        public string? RoleID { get; set; }

    }

    public class LoginUser
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
