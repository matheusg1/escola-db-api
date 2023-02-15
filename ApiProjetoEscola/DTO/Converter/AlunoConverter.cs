using System.Collections.Generic;
using System;
using ApiProjetoEscola.Model;
using System.Linq;

namespace ApiProjetoEscola.DTO.Converter
{
    public class AlunoConverter : IParser<AlunoDTO, Aluno>, IParser<Aluno, AlunoDTO>
    {
        public Aluno Parse(AlunoDTO origin)
        {
            if (origin == null)
            {
                return null;
            }
            return new Aluno
            {
                Id = origin.Id,
                Cpf = origin.Cpf,
                Matricula = origin.Matricula,
                DataNascimento = origin.DataNascimento,
                NomeCompleto = origin.NomeCompleto
            };
        }

        public AlunoDTO Parse(Aluno origin)
        {
            if (origin == null)
            {
                return null;
            }
            return new AlunoDTO
            {                
                Id = origin.Id,
                Cpf = origin.Cpf,
                Matricula = origin.Matricula,
                DataNascimento = origin.DataNascimento,
                NomeCompleto = origin.NomeCompleto                     
            };
        }

        public List<Aluno> Parse(List<AlunoDTO> origin)
        {
            if (origin == null)
            {
                return null;
            }
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<AlunoDTO> Parse(List<Aluno> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}