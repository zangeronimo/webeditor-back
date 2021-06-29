using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Webeditor
{
    [Table("webeditor_companies")]
    public class Company : BaseEntity
    {
        public Company(string name)
        {
            Name = name;
        }

        public bool IsValid
        {
            get
            {
                return Name.Length > 3 && Name.Length <= 150;
            }
        }

        public void setName(string name)
        {
            Name = name;
        }

        [Column("name")]
        public string Name { get; private set; }

        public ICollection<Module> Modules { get; set; }
    }
}
