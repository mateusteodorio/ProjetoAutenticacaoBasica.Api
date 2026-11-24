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
    public class VoosController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public VoosController(AppDbcontext context)
        {
            _context = context;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> CriarVoo(VooDTO vooDTO)
        {
            var novovoo = new Voo
            {
                Origem = vooDTO.Origem,
                Destino = vooDTO.Destino,
                Codigo = vooDTO.Codigo,
            };
            _context.Voos.Add(novovoo);
            await _context.SaveChangesAsync();

            return Ok("Voo criado com sucesso");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResumoVooDTO>>> GetResumoDeVoo()
        {
            var voando = await _context.Voos.AsNoTracking().OrderBy(v => v.Codigo).Select(v => new ResumoVooDTO 
            {ID = v.Id, Codigo = v.Codigo, Trajeto = v.Origem + " -> " + v.Destino}
            ).ToListAsync();

            return Ok(voando);
        }

        [HttpGet("codigo/{codigo}")]
        public async Task<ActionResult<IEnumerable<VooManifestoDTO>>> GetResumoCodigo(int codigo)
        {
            var organizacao = await _context.Voos.AsNoTracking().Where(v => v.Codigo == codigo).Select
                (v => new VooManifestoDTO
                {
                    Id = v.Id,
                    Codigo = v.Codigo,
                    Trajeto = v.Origem + " -> " + v.Destino,
                    Passageiro = v.Passagens.Select(p => new PassageiroNoVooDTO { Nome = p.Passageiro.Nome, Assento = p.Assento }).ToList()
                }).FirstOrDefaultAsync();
            if (organizacao is null)
            {
                return NotFound(new { mensagem = "Voo não encontrado" });
            }

            return Ok(organizacao);
        }
    }
}
