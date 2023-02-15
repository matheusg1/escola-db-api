using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.DTO
{
    public class MateriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Professor { get; set; }
    }
}
