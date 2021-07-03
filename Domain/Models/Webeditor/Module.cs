using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Webeditor
{
    [Table("webeditor_modules")]
    public class Module : BaseEntity
    {
        public Module(string name)
        {
            Name = name;
        }

        public bool IsValid
        {
            get
            {
                return Name.Length > 3 && Name.Length <= 30;
            }
        }

        public void setName(string name)
        {
            Name = name;
        }

        [Column("name")]
        public string Name { get; private set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
