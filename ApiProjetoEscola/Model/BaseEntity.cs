using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    public class BaseEntity
    {
        [Column("Id")]
        public int id { get; set; }
    }
}
