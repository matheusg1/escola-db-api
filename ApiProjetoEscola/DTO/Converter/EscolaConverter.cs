using System.Collections.Generic;
using System;
using ApiProjetoEscola.Model;
using System.Linq;

namespace ApiProjetoEscola.DTO.Converter
{
    public class EscolaConverter : IParser<EscolaDTO, Escola>, IParser<Escola, EscolaDTO>
    {
        public Escola Parse(EscolaDTO origin)
        {
            if (origin == null)
            {
                return null;
            }
            return new Escola
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Endereco = origin.Endereco,
            };
        }

        public EscolaDTO Parse(Escola origin)
        {
            if (origin == null)
            {
                return null;
            }
            return new EscolaDTO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Endereco = origin.Endereco,
            };
        }

        public List<Escola> Parse(List<EscolaDTO> origin)
        {
            if (origin == null)
            {
                return null;
            }
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<EscolaDTO> Parse(List<Escola> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}