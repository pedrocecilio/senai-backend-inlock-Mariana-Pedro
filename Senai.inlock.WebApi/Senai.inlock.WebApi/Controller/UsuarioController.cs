using System;
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

    [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepositorycs _usuarioRepository { get; set; }

        public UsuarioController()

        {
            _usuarioRepository = new UsuarioRepository();
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomains novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return Ok(novoUsuario);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomains usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                return Ok(usuarioBuscado);
            }

            return NotFound("Nenhum usuário encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UsuarioDomains usuarioAtualizado)
        {
            UsuarioDomains usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }
            return NotFound
                (
                    new
                    {
                        mensagem = "Usuário não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UsuarioDomains usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                _usuarioRepository.Deletar(id);

                return Ok($"O usuário {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum usuário encontrado para o identificador informado");
        }
    }
}