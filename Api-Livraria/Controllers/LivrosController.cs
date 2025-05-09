using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaLivraria.Models;

namespace SistemaLivraria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivrosController : ControllerBase
{
    private static List<Livro> livros = new List<Livro>();

    [HttpPost("criar-livros")]
    public IActionResult AdicionarLivro([FromBody] Livro livro)
    {
        livros.Add(livro);

        return CreatedAtAction(nameof(AdicionarLivro), new { id = livro.Id }, livro);
    }

    [HttpGet("obter-todos")]
    public IActionResult ObterTodos()
    {
        return Ok(livros);
    }

    [HttpGet("buscar-livro/{id}")]
    public IActionResult ObterPorId(int id)
    {
        var livro = livros.FirstOrDefault(l => l.Id == id);
        if (livro == null) return NotFound();

        return Ok(livro);
    }

    [HttpPut("atualizar-livro/{id}")]
    public IActionResult AtualizarLivro(int id, [FromBody] Livro livroAtualizado)
    {
        var livro = livros.FirstOrDefault(l => l.Id == id);
        if (livro == null) return NotFound();

        livro.Titulo = livroAtualizado.Titulo;
        livro.Autor = livroAtualizado.Autor;
        livro.Genero = livroAtualizado.Genero;
        livro.Preco = livroAtualizado.Preco;
        livro.QuantidadeEmEstoque = livroAtualizado.QuantidadeEmEstoque;

        return Ok(livro);
    }

    [HttpDelete("excluir-livro/{id}")]
    public IActionResult DeletarLivro(int id)
    {
        var livro = livros.FirstOrDefault(l => l.Id == id);
        if (livro == null) return NotFound();

        livros.Remove(livro);
        return NoContent();
    }
}
