using ApiPedido.Context;
using ApiPedido.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPedido.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidosProdutosController : ControllerBase
    {

        private readonly AppDbContext _context;
        
        public PedidosProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PedidoProduto>> Get()
        {
            return _context.PedidosProdutos.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<PedidoProduto> GetPedidoProduto(int id)
        {
            var pedidoProduto = _context.PedidosProdutos.FirstOrDefault(p => p.PedidoProdutoId == id);

            if(pedidoProduto is null)
            {
                return NotFound($"Id {id} não encontrado");
            }

            return Ok(pedidoProduto);
        }

        [HttpPost]
        public ActionResult<PedidoProduto> Post(PedidoProduto pedido)
        {
            _context.PedidosProdutos.Add(pedido);
            _context.SaveChanges();

            return Ok(pedido);
        }

        [HttpPut("{id:int}")]
        public ActionResult<PedidoProduto> Put(int id, PedidoProduto pedidoproduto)
        {
            if (id != pedidoproduto.PedidoProdutoId)
            {
                return NotFound($"Id {id} não encontrado");
            }

            _context.Entry(pedidoproduto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(pedidoproduto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<PedidoProduto> Delete(int id)
        {
            var pedidoproduto = _context.PedidosProdutos.FirstOrDefault(p => p.PedidoProdutoId==id);

            if (pedidoproduto is null)
            {
                return NotFound($"Id {id} não encontrado");
            }

            _context.PedidosProdutos.Remove(pedidoproduto);
            _context.SaveChanges();

            return Ok(pedidoproduto);
        }
    }
}
