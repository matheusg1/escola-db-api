﻿using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurmaController : ControllerBase
    {
        public ITurmaService _service;

        public TurmaController(ITurmaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("findAll")]
        [ProducesResponseType((200), Type = typeof(List<Turma>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> FindAllAsync()
        {
            return Ok(await _service.FindAllAsync());
        }


        [HttpGet]
        [Route("findByID")]
        [ProducesResponseType((200), Type = typeof(Turma))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> FindByIdAsync([FromQuery] int id)
        {
            return Ok(await _service.FindByIdAsync(id));
        }

        [HttpGet]
        [Route("GetQuantidadeAlunosByTurma")]
        public async Task<IActionResult> GetQuantidadeAlunosByTurmaAsync(int id)
        {
            var result = await _service.GetQuantidadeAlunosByTurmaAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new { quantidadeAlunos = result });
        }


        [HttpPost]
        [Route("create")]
        [ProducesResponseType((200), Type = typeof(Turma))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] CreateTurmaDTO turmaDto)
        {
            if (turmaDto == null) return BadRequest();
            var turma = new Turma(turmaDto.Codigo, turmaDto.EscolaId);

            return Ok(_service.Create(turma));
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType((200), Type = typeof(Turma))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Update([FromBody] Turma turma)
        {
            if (turma == null) return BadRequest();
            return Ok(_service.Update(turma));
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete([FromQuery] int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
