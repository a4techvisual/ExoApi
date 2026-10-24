using ExoApi.Interfaces;
using ExoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExoApi.Controllers
{
    // Controller: recebe as requisições HTTP e devolve respostas em JSON
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetosController(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        // GET api/projetos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_projetoRepository.Listar());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao listar projetos.", erro = ex.Message });
            }
        }

        // GET api/projetos/{id}
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorId(int id)
        {
            Projeto projeto = _projetoRepository.BuscarPorId(id);
            if (projeto == null)
                return NotFound(new { mensagem = $"Projeto {id} não encontrado." });

            return Ok(projeto);
        }

        // POST api/projetos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(Projeto projeto)
        {
            if (string.IsNullOrWhiteSpace(projeto.Titulo))
                return BadRequest(new { mensagem = "O campo Titulo é obrigatório." });

            try
            {
                _projetoRepository.Cadastrar(projeto);
                return CreatedAtAction(nameof(BuscarPorId), new { id = projeto.Id }, projeto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao cadastrar projeto.", erro = ex.Message });
            }
        }

        // PUT api/projetos/{id}
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            if (string.IsNullOrWhiteSpace(projeto.Titulo))
                return BadRequest(new { mensagem = "O campo Titulo é obrigatório." });

            try
            {
                bool atualizado = _projetoRepository.Atualizar(id, projeto);
                if (!atualizado)
                    return NotFound(new { mensagem = $"Projeto {id} não encontrado." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao atualizar projeto.", erro = ex.Message });
            }
        }

        // DELETE api/projetos/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Deletar(int id)
        {
            try
            {
                bool deletado = _projetoRepository.Deletar(id);
                if (!deletado)
                    return NotFound(new { mensagem = $"Projeto {id} não encontrado." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao deletar projeto.", erro = ex.Message });
            }
        }
    }
}
