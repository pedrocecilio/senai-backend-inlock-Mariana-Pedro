using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.inlock.WebApi.Domains;
using Senai.inlock.WebApi.Interfaces;
using Senai.inlock.WebApi.Repositories;

namespace Senai.inlock.WebApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }
        //listar
        [HttpGet]
        public IEnumerable<JogosDomains> Get()
        {
            return _jogosRepository.listar();
        }
        //cadastrar
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogosDomains novojogo)
        {
            _jogosRepository.Cadastrar(novojogo);
            return StatusCode(201);
        }


        //deletar
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _jogosRepository.Deletar(id);
            return Ok("jogo deletado");
        }

        //buscar por id ok
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogosDomains jogoBuscado = _jogosRepository.BuscarPorId(id);
            if (jogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado");
            }
            return Ok(jogoBuscado);
        }

    }
}