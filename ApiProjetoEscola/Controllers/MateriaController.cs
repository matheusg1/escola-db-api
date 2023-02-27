﻿using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MateriaController : ControllerBase
    {
        public IMateriaService _service;

        public MateriaController(IMateriaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("findAll")]
        [ProducesResponseType((200), Type = typeof(List<Materia>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> FindAllAsync()
        {
            return Ok(await _service.FindAllAsync());
        }

        [HttpGet]
        [Route("findByID")]
        [ProducesResponseType((200), Type = typeof(Materia))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> FindByIDAsync([FromQuery] int id)
        {
            return Ok(await _service.FindByIDAsync(id));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType((200), Type = typeof(Materia))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] Materia materia)
        {
            if (materia == null) return BadRequest();

            return Ok(_service.Create(materia));
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType((200), Type = typeof(Materia))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Update([FromBody] Materia materia)
        {
            if (materia == null) return BadRequest();
            return Ok(_service.Update(materia));
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
