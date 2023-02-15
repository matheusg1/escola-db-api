using System.Collections.Generic;
using System;
using ApiProjetoEscola.Model;
using System.Linq;

namespace ApiProjetoEscola.DTO.Converter
{
    public class TurmaConverter : IParser<TurmaDTO, Turma>, IParser<Turma, TurmaDTO>
    {
        public Turma Parse(TurmaDTO origin)
        {
            if (origin == null)
            {
                return null;
            }
            return new Turma
            {
                Id = origin.Id,
                Codigo = origin.Codigo
            };
        }

        public TurmaDTO Parse(Turma origin)
        {
            if (origin == null)
            {
                return null;
            }
            return new TurmaDTO
            {
                Id = origin.Id,
                Codigo = origin.Codigo,                
            };
        }

        public List<Turma> Parse(List<TurmaDTO> origin)
        {
            if (origin == null)
            {
                return null;
            }
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<TurmaDTO> Parse(List<Turma> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}