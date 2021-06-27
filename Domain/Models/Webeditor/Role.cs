using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Webeditor
{
    [Table("webeditor_roles")]
    public class Role : BaseEntity
    {
        public Role(string name, string label)
        {
            Name = name;
            Label = label;
        }

        public bool IsValid
        {
            get
            {
                return Name.Length > 3 &&
                Name.Length <= 50 &&
                Label.Length > 3 &&
                Label.Length <= 50;
            }
        }

        public void setName(string name)
        {
            Name = name;
        }

        public void setLabel(string label)
        {
            Label = label;
        }

        [Column("name")]
        public string Name { get; private set; }

        [Column("label")]
        public string Label { get; private set; }
    }
}
