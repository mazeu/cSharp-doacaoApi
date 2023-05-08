using System.Collections.Immutable;
using doacaoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace doacaoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private static List<Item> itens = new List<Item>();//Cria uma lista para salvar os itens enquanto nao utiliza o banco
        private static int id = 1;//id do item criado

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public void AdicionaItem([FromBody] Item item)
        {
            item.Id = id++;
            itens.Add(item);//salva o item na lista
        }

        [HttpGet]
        public List<Item> RecuperaTodosItem()
        {
            return itens;
        }

        [HttpGet("{id}")]
        public Item? RecuperaItemPorId(int id)
        {

            return itens.FirstOrDefault(item => item.Id == id);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaItem(int id, [FromBody] Item item)
        {
            var itemEncontrado = itens.FirstOrDefault(itens => itens.Id == id);
            //itens.Remove(itemIndex);
            itemEncontrado.Name = item.Name;
            itemEncontrado.DescricaoLonga = item.DescricaoLonga;
            itemEncontrado.Condicao = item.Condicao;
            if (itemEncontrado == null) return NotFound();
            return NoContent();
            //itens.Add(item);//salva o item na lista
        }


        [HttpDelete("{id}")]
        public IActionResult RemoverItem(int id)
        {
            var item = itens.FirstOrDefault(item => item.Id == id);
            if(item is null) return NotFound();
            itens.Remove(item);

            return NoContent();
        }
    }
}
