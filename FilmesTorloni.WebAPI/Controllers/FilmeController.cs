using FilmesTorloni.WebAPI.Interfaces;
using FilmesTorloni.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmeController : ControllerBase
{
    private readonly IFilmeRepository _filmeRepository;

    public FilmeController(IFilmeRepository filmeRepository)
    {
        _filmeRepository = filmeRepository;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            return Ok(_filmeRepository.BuscarPorId(id)); // Retorna o filme encontrado com status 200 OK
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message); // Retorna uma resposta de erro com status 400 Bad Request e a mensagem de erro
        }
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_filmeRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPost]
    public IActionResult Post(Filme NovoFilme)
    {
        try
        {
            _filmeRepository.Cadastrar(NovoFilme);
            return StatusCode(201);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, Filme filmeAtualizado)
    {
        try
        {
            _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);
            return NoContent();// Retorna status 204 NoContent para indicar que a atualização foi bem-sucedida, sem retornar um corpo de resposta
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    [HttpPut]
    public IActionResult PutBody(Filme filmeAtualizado)
    {
        try
        {
            _filmeRepository.AtualizarIdCorpo(filmeAtualizado);
            return NoContent();// Retorna status 204 NoContent para indicar que a atualização foi bem-sucedida, sem retornar um corpo de resposta
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _filmeRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}