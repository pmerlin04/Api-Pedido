using ApiPedido.Context;
using ApiPedido.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiPedido.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return _context.Produtos.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Produto> GetProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound($"Não foi encontrado o produto com id {id}");
            }

            return Ok(produto);
            
        }

        [HttpPost]
        public ActionResult<Produto> Post(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult<Produto> Put(int id,  Produto produto)
        {

            if(id != produto.ProdutoId)
            {
                return NotFound($"Id {id} não encontrado");

            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId==id);

            if(produto is null)
            {
                return NotFound("Id não encontrado para deletar");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok();
        }



    }
}
