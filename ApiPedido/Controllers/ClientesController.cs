using Microsoft.AspNetCore.Mvc;
using ApiPedido.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using ApiPedido.Models;

namespace ApiPedido.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("pedidos")]
        public ActionResult<IEnumerable<Cliente>> GetClientesPedidos()
        {
           return _context.Clientes.Include(p => p.Pedidos).ToList();

        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = _context.Clientes.ToList();

            return clientes;
        }


        [HttpGet("{id:int}", Name = "ObterCliente")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == id);

            if (cliente is null)
            {
                return NotFound("Este cliente não exixte");
            }

            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCliente", new
            {
                id = cliente.ClienteId
            }, cliente);
        }


        [HttpPut("{id:int}")]
        public ActionResult PutCliente(int id, Cliente cliente)
        {

                if (id != cliente.ClienteId)
                {
                    return NotFound($"Não foi possível realizar a atualização do cliente com id{id}");
                }

                _context.Entry(cliente).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(cliente);
        }

        [HttpDelete]
        public ActionResult DeleteCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == id);

            if (cliente is null)
            {
                return NotFound("Este cliente não existe");
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }         
    }
}
