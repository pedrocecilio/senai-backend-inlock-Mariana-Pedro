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

    [Authorize(Roles = "1")]
    public class TipoUsuarioController : ControllerBase
    {

            private ITipoUsuarioRepositorycs _tipoUsuarioRepository { get; set; }


            public TipoUsuarioController()
            {
                _tipoUsuarioRepository = new TipoUsuarioRepository();
            }


            [HttpGet]
            public IActionResult Get()
            {

                return Ok(_tipoUsuarioRepository.Listar());
            }


            [HttpPost]
            public IActionResult Post(TipoUsuarioDomains novoTipoUsuario)
            {

                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);


                return Ok( novoTipoUsuario);
            }


            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {

                TipoUsuarioDomains tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);


                if (tipoUsuarioBuscado != null)
                {

                    return Ok(tipoUsuarioBuscado);
                }


                return NotFound("Nenhum tipo de usuário encontrado para o identificador informado");
            }


            [HttpPut("{id}")]
            public IActionResult Put(int id, TipoUsuarioDomains tipoUsuarioAtualizado)
            {

                TipoUsuarioDomains tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);


                if (tipoUsuarioBuscado != null)
                {

                    try
                    {

                        _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);


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
                            mensagem = "Tipo de usuário não encontrado",
                            erro = true
                        }
                    );
            }


            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {

                TipoUsuarioDomains tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);


                if (tipoUsuarioBuscado != null)
                {

                    _tipoUsuarioRepository.Deletar(id);


                    return Ok($"O tipo de usuário {id} foi deletado com sucesso!");
                }


                return NotFound("Nenhum tipo de usuário encontrado para o identificador informado");
            }
        }
    }
