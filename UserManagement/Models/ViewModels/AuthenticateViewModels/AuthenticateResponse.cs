using UserManagement.Common.Enums;

namespace UserManagement.Models.ViewModels.AuthenticateViewModels
{
    public class AuthenticateResponse
    {
        public AuthenticateStatus Status { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }

        public static class Messages
        {
            public const string NotRegistered = "User Not Exist";
            public const string UpdatePasswordSucceeded = "Update Password Succeeded";
            public const string PasswordCriteria = "Password Should Follow These Criteria";
        }

    }
}
