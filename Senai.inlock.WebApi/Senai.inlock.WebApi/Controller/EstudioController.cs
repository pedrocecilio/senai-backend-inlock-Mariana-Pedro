﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Senai.inlock.WebApi.Domains;
using Senai.inlock.WebApi.Interfaces;
using Senai.inlock.WebApi.Repositories;


namespace Senai.inlock.WebApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EstudioController : ControllerBase
    {


            private IEstudioRepository _estudioRepository { get; set; }

            public EstudioController()
            {
                _estudioRepository = new EstudioRepository();
            }

            //listar ok

            [HttpGet]
            public IEnumerable<EstudioDomains> Get()
            {
                return _estudioRepository.listar();
            }

            //cadastrar ok
            [Authorize(Roles = "1")]
            [HttpPost]
            public IActionResult Post(EstudioDomains novoEstudio)
            {
                _estudioRepository.Cadastrar(novoEstudio);
                return StatusCode(201);
            }

        //atualizar ok
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomains EstudioAtualizado)
            {
                EstudioDomains estudioBuscado = _estudioRepository.BuscarPorId(id);
                if (estudioBuscado == null)
                {
                  return NotFound(
                    new
                       {
                           mensagem = "Estudio não encontrado",
                           erro = true
                       }
                        );
                }
                try
                {
                    _estudioRepository.Atualizar(id, EstudioAtualizado);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }


            //deletar ok
            [Authorize(Roles = "1")]
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _estudioRepository.Deletar(id);
                return Ok("estudio deletado");
            }

            //buscar por id ok
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                EstudioDomains estudioBuscado = _estudioRepository.BuscarPorId(id);
                if (estudioBuscado == null)
                {
                    return NotFound("Nenhum estudio encontrado");
                }
                return Ok(estudioBuscado);
            }
        

    }

}
