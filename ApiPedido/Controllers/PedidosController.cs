using ApiPedido.Context;
using ApiPedido.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPedido.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> Get() {

            return _context.Pedidos.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.PedidoId == id);

            if (pedido is null)
            {
                return NotFound($"Não existe um pedido com id {id}");
            }

            return Ok(pedido);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Pedido> Put(int id, Pedido pedido)
        {
            //var pedido = _context.Pedidos.
            if (id != pedido.PedidoId)
            {
                return NotFound($"O pedido com id {id} não existe para ser alterado");
            }

            _context.Entry(pedido).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(pedido);
        }

        [HttpPost]
        public ActionResult<Pedido> Post(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return Ok(pedido);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Pedido> Delete(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.PedidoId == id);
            if (pedido is null)
            {
                return NotFound($"O pedido com id {id} não foi encontrado");
            }

            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();

            return Ok();
        }

        


    }
}
