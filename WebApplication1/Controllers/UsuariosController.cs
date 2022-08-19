using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class UsuariosController : ControllerBase
    {
        private DbContextDesafio _context = new DbContextDesafio();

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            try
            {
                var listaUsers = _context.Usuarios.ToList();
                return Ok(listaUsers);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult ListarUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            return Ok(usuario);
        }
        //
        [HttpPost]
        public IActionResult CriarNovoUsuario([FromBody] Usuarios usuario)
        {
            try
            {
                if (usuario.Id == 0)
                {
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                }

                return Ok(usuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                if (id != 0)
                {
                    var usuarioBd = _context.Usuarios.Find(id);
                    _context.Usuarios.Remove(usuarioBd);
                }
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception msg)
            {
                return BadRequest(msg);
                throw;
            }

        }

        [HttpPut("{id}")]
        public IActionResult EditarUsuario(int id, [FromBody] Usuarios usuario)
        {
            try
            {
                var UsuarioAntigo = _context.Usuarios.Find(id);
                if (UsuarioAntigo.Nome == usuario.Nome)
                {

                }
                else
                {
                    UsuarioAntigo.Nome = usuario.Nome;
                }

                if (UsuarioAntigo.Email == usuario.Email)
                {

                }
                else
                {
                    UsuarioAntigo.Email = usuario.Email;
                }

                _context.Usuarios.Update(UsuarioAntigo);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }


    }


}