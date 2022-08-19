using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicacoesController : ControllerBase
    {
        private DbContextDesafio _context = new DbContextDesafio();

        //
        [HttpGet]
        public IActionResult ListarPublicacoes()
        {
            try
            {
                var listaPublicacoes = _context.Publicacoes.ToList();
                return Ok(listaPublicacoes);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }


        [HttpGet("{id}")]
        public IActionResult ListarPublicacao(int id)
        {
            try
            {
                var listaPublicacao = _context.Publicacoes.Find(id);
                return Ok(listaPublicacao);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        //
        [HttpPost]
        public IActionResult CriarNovaPublicacao([FromBody] Publicacao publicacao)
        {
            try
            {
                if (publicacao.Id == 0)
                {
                    publicacao.DataPublicacao = DateTime.Now;
                    _context.Publicacoes.Add(publicacao);
                    _context.SaveChanges();
                }

                return Ok(publicacao);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPublicacao(int id)
        {
            try
            {
                if (id != 0)
                {
                    var publicacao = _context.Publicacoes.Find(id);
                    _context.Remove(publicacao);
                }
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }

        }

        [HttpPut("{id}")]
        public IActionResult EditarPublicacao(int id,[FromBody]Publicacao publicacao)
        {
            try
            {
                var publicacaoAntiga = _context.Publicacoes.Find(id);
                if (publicacaoAntiga.Autor == publicacao.Autor)
                {

                }
                else
                {
                    publicacaoAntiga.Autor = publicacao.Autor;
                }

                if (publicacaoAntiga.Titulo == publicacao.Titulo)
                {

                }
                else
                {
                    publicacaoAntiga.Titulo = publicacao.Titulo;
                }

                if (publicacaoAntiga.Conteudo == publicacao.Conteudo)
                {

                } else
                {
                    publicacaoAntiga.Conteudo = publicacao.Conteudo;
                }

                publicacaoAntiga.DataPublicacao = DateTime.Now;
                _context.Publicacoes.Update(publicacaoAntiga);
                _context.SaveChanges();
                return Ok(publicacaoAntiga);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }


    }
}
