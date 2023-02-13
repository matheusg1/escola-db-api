using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Escola")]
    public class Escola : BaseEntity
    {
        [Column("Id")]
        public int id { get; set; }
        [Column("Nome")]
        public string nome { get; set; }
        [Column("Endereco")]
        public string endereco { get; set; }
    }
}
