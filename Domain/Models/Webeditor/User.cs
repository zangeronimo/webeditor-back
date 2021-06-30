using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Webeditor
{
    [Table("webeditor_users")]
    public class User : BaseEntity
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public bool IsValid
        {
            get
            {
                return Name.Length > 3 &&
                Name.Length <= 150 &&
                Email.Length > 3 &&
                Email.Length <= 150 &&
                !string.IsNullOrEmpty(Password);
            }
        }

        public void setName(string name)
        {
            Name = name;
        }

        public void setEmail(string email)
        {
            Email = email;
        }

        public void setPassword(string password)
        {
            Password = password;
        }

        [Column("name")]
        public string Name { get; private set; }

        [Column("email")]
        public string Email { get; private set; }

        [Column("password")]
        public string Password { get; private set; }

        [Column("id_webeditor_companies")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
