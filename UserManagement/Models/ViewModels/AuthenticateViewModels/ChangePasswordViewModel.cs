namespace UserManagement.Models.ViewModels.AuthenticateViewModels
{
    public class ChangePasswordViewModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
