using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookRepository _repo;
    private readonly IMapper _mapper;

    public BookController(IBookRepository repo, ILogger<BookController> logger, IMapper mapper)
    {
        _repo = repo;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<GetBookResponce>> GetBookIdAsync(Guid id)
    {
        _logger.LogInformation("Запрос GetBookIdAsync получен");

        var result = await _repo.GetBookAsync(id);
        var responce = _mapper.Map<GetBookResponce>(result);

        _logger.LogInformation("Запрос GetBookIdAsync выполнен");

        return Ok(responce);
    }

    [HttpGet]
    [Route("name={name}")]
    public async Task<ActionResult<IEnumerable<GetBookResponce>>> GetBooksNameAsync(string name)
    {
        _logger.LogInformation("Запрос GetBookNameAsync получен");

        var result = await _repo.GetBooksAsync(name);
        var responce = _mapper.Map<IEnumerable<GetBookResponce>>(result);

        _logger.LogInformation("Запрос GetBookNameAsync выполнен");

        return Ok(responce);
    }

    [HttpGet]
    [Route("date={date:datetime}")]
    public async Task<ActionResult<IEnumerable<GetBookResponce>>> GetBooksDateAsync(DateTime date)
    {
        _logger.LogInformation("Запрос GetBookDateAsync получен");

        var result = await _repo.GetBooksAsync(date);
        var responce = _mapper.Map<IEnumerable<GetBookResponce>>(result);

        _logger.LogInformation("Запрос GetBookDateAsync выполнен");

        return Ok(responce);
    }

    [HttpGet]
    [Route("name={name}/date={date:datetime}")]
    public async Task<ActionResult<IEnumerable<GetBookResponce>>> GetBooksAsync(string name, DateTime date)
    {
        _logger.LogInformation("Запрос GetBookDateAsync получен");

        var result = await _repo.GetBooksAsync(name, date);
        var responce = _mapper.Map<IEnumerable<GetBookResponce>>(result);

        _logger.LogInformation("Запрос GetBookDateAsync выполнен");

        return Ok(responce);

    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<CreateBookResponce>> CreateBookAsync([FromBody] CreateBookRequest request)
    {
        _logger.LogInformation("Запрос GetBookDateAsync получен");

        var book = _mapper.Map<Book>(request);
        var result = await _repo.CreateBookAsync(book);
        var responce = _mapper.Map<CreateBookResponce>(result);

        _logger.LogInformation("Запрос GetBookDateAsync выполнен");

        return Ok(responce);
    }

    [HttpPost]
    [Route("update")]
    public async Task<ActionResult<UpdateBookResponce>> UpdateBookAsync([FromBody] UpdateBookRequest request)
    {
        _logger.LogInformation("Запрос GetBookDateAsync получен");

        var book = _mapper.Map<Book>(request);
        var result = await _repo.UpdateBookAsync(book);
        var responce = _mapper.Map<UpdateBookResponce>(result);

        _logger.LogInformation("Запрос GetBookDateAsync выполнен");

        return Ok(responce);
    }

    [HttpPost]
    [Route("remove={id:guid}")]
    public async Task<IActionResult> RemoveBookAsyncBookAsync(Guid id)
    {
        _logger.LogInformation("Запрос GetBookDateAsync получен");

        var result = await _repo.RemoveBookAsync(id);

        _logger.LogInformation("Запрос GetBookDateAsync выполнен");

        return Ok(result);
    }

    protected override void Dispose(bool disposing)
    {
        _repo.Dispose();
        base.Dispose(disposing);
    }
}