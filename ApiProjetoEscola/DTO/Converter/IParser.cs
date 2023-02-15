using System.Collections.Generic;

namespace ApiProjetoEscola.DTO.Converter
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
