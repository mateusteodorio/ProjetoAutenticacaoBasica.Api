using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAutenticacaoBasica.Api.Data;
using ProjetoAutenticacaoBasica.Api.Models;
using ProjetoAutenticacaoBasica.Api.Models.DTOs;

namespace ProjetoAutenticacaoBasica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public AuthController(AppDbcontext context)
        {
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            var novoUsuario = new Usuario
            {
                Nome = usuarioDTO.Nome,
                Username = usuarioDTO.Username,
                Password = usuarioDTO.Password,
                CreatedAt = DateTime.Now
            };
            _context.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return Ok("Usuario Registrado");
        }

        [HttpPost]
        public async Task<IActionResult> LoginUsuario(LoginDTO loginDTO)
        {
            var Login = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == loginDTO.Username && u.Password == loginDTO.Password);
            if (Login == null)
            {
                return NotFound("Usuario não encontrado");
            }

            return Ok("Bem vindo " + Login.Nome);



        }
    }
}
