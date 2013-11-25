namespace Momento.Models
{
    public class MemberViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    
        public bool IsAuthenticated { get; set; }
    }
}
