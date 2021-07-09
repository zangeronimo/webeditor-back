namespace Domain.Models.Webeditor
{
    public class Auth
    {
        public Auth(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public bool IsValid
        {
            get
            {
                return Email.Length > 3 &&
                Email.Length <= 150 &&
                !string.IsNullOrEmpty(Password);
            }
        }

        public void setEmail(string email)
        {
            Email = email;
        }

        public void setPassword(string password)
        {
            Password = password;
        }

        public string Email { get; private set; }

        public string Password { get; private set; }
    }
}
