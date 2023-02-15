using System.Collections.Generic;
using System;
using ApiProjetoEscola.Model;
using System.Linq;

namespace ApiProjetoEscola.DTO.Converter
{
    public class MateriaConverter : IParser<MateriaDTO, Materia>, IParser<Materia, MateriaDTO>
    {
        public Materia Parse(MateriaDTO origin)
        {
            if (origin == null)
            {
                return null;
            }
            return new Materia
            {                
                Id = origin.Id,
                Nome = origin.Nome,
                Professor = origin.Professor
            };
        }

        public MateriaDTO Parse(Materia origin)
        {
            if (origin == null)
            {
                return null;
            }

            return new MateriaDTO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Professor = origin.Professor
            };
        }

        public List<Materia> Parse(List<MateriaDTO> origin)
        {
            if (origin == null)
            {
                return null;
            }
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<MateriaDTO> Parse(List<Materia> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}