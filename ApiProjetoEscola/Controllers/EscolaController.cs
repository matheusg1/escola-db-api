﻿using ApiProjetoEscola.Services;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EscolaController : ControllerBase
    {
        public IEscolaService _service;

        public EscolaController(IEscolaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.FindAll());
        }
    }
}
