using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoAutenticacaoBasica.Api.Data;
using ProjetoAutenticacaoBasica.Api.Models;
using ProjetoAutenticacaoBasica.Api.Models.DTOs;

namespace ProjetoAutenticacaoBasica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageirosController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public PassageirosController(AppDbcontext context)
        {
            _context = context;
            {

            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegistrarPassageiro(PassageiroDTO passageiroDTO)
        {
            var novopassageiro = new Passageiro
            {
                Nome = passageiroDTO.Nome,
                CPF = passageiroDTO.CPF,
            };
            _context.Passageiros.Add(novopassageiro);
            await _context.SaveChangesAsync();
            return Ok(new { Mensagem = "Passageiro criado sucesso" });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassageiroInfoDTO>>> GetInfos([FromQuery] string? nome)
        {
            var informa = await _context.Passageiros.AsNoTracking().Where(p => string.IsNullOrEmpty(nome) || p.Nome.Contains(nome)).OrderBy(P => P.Id).Select(p => new PassageiroInfoDTO { ID = p.Id, Nome = p.Nome }).ToListAsync();
            return Ok(informa);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<IEnumerable<PassageiroInfoDTO>>> GetPassageiroPorCPF(string cpf)
        {
          var passageiros = await _context.Passageiros.AsNoTracking().Where(p => p.CPF == cpf).Select(p => new PassageiroInfoDTO { ID = p.Id, Nome = p.Nome }).FirstOrDefaultAsync();
          if (passageiros is null)
           {
              return NotFound(new { mensagem = "Passageiro não encontrado" });
           }

          return Ok(passageiros);
        }
    }

} 
