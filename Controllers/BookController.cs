using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : Controller
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _bookService.GetBookList();

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var result = await _bookService.GetBook(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        var result = await _bookService.CreateBook(book);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook([FromBody] Book book)
    {
        var result = await _bookService.UpdateBook(book);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _bookService.DeleteBook(id);

        return Ok(result);
    }
}