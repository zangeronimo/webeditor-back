using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Webeditor
{
    [Table("webeditor_companies_has_webeditor_modules")]
    public class CompanyHasModule
    {
        [Column("id_webeditor_companies")]
        public int CompanyId { get; set; }

        [Column("id_webeditor_modules")]
        public int ModuleId { get; set; }

        public virtual Company Company { get; set; }

        public virtual Module Module { get; set; }
    }
}
