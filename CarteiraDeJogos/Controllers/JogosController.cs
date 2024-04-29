using CarteiraDeJogos.Data;
using CarteiraDeJogos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers
{
    [ApiController]
    [Route("Jogos")]
    public class JogosController : ControllerBase
    {
        private JogosContext _context;
        public JogosController(JogosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Jogos> BuscaJogos()
        {
            List<Jogos> jogos = _context.Jogos.ToList();
            return jogos;
        }

        [HttpPost]
        public IActionResult CadastrarJogo([FromBody] Jogos jogos)
        {
            _context.Jogos.Add(jogos);
            _context.SaveChanges();
            return Ok();
        }
    }
}
