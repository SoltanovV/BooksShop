using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderRepository _repo;
    private readonly IMapper _mapper;

    public OrderController(IOrderRepository repo, ILogger<OrderController> logger, IMapper mapper)
    {
        _repo = repo;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("id={id}")]
    public async Task<ActionResult<IEnumerable<GetOrderResponce>>> GetOrderAsync(Guid id)
    {
        _logger.LogInformation("Запрос GetOrderAsync получен");

        var result = await _repo.GetOrderAsync(id);

        var responce = _mapper.Map<IEnumerable<GetOrderResponce>>(result);

        _logger.LogInformation("Запрос GetOrderAsync выполнен");

        return Ok(result);
    }

    [HttpGet]
    [Route("date={date:datetime}")]
    public async Task<ActionResult<IEnumerable<GetOrderResponce>>> GetOrdersAsync(DateTime date)
    {
        _logger.LogInformation("Запрос GetOrderNumAsync получен");

        var result = await _repo.GetOrdersAsync(date);

        var responce = _mapper.Map<IEnumerable<GetOrderResponce>>(result);

        _logger.LogInformation("Запрос GetOrdersAsync выполнен");

        return Ok(result);
    }

    [HttpGet]
    [Route("id={id:guid}/date={date:datetime}")]
    public async Task<ActionResult<IEnumerable<GetOrderResponce>>> GetOrdersAsync(Guid id, DateTime date)
    {
        _logger.LogInformation("Запрос GetOrdersAsync получен");

        var result = await _repo.GetOrdersAsync(id, date);

        var responce = _mapper.Map<GetOrderResponce>(result);

        _logger.LogInformation("Запрос GetOrdersAsync выполнен");

        return Ok(result);

    }


    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<CreateOrderResponces>> CreateOrderAsync([FromBody] CreateOrderRequest request)
    {
        _logger.LogInformation("Запрос CreateOrderAsync получен");

        var order = _mapper.Map<Order>(request);
        var result = await _repo.CreateOrderAsync(order, request.ArrayBooksId);
        var responce = _mapper.Map<CreateOrderResponces>(result);

        _logger.LogInformation("Запрос CreateOrderAsync выполнен");

        return Ok(responce);

    }

    [HttpPost]
    [Route("update")]
    public async Task<ActionResult<UpdateOrderResponces>> UpdateOrderAsync(
        [FromBody] UpdateOrderRequest request)
    {
        _logger.LogInformation("Запрос UpdateOrderAsync получен");

        var order = _mapper.Map<Order>(request);
        var result = await _repo.UpdateOrderAsync(order, request.ArrayBooksId);
        var responce = _mapper.Map<CreateOrderResponces>(result);

        _logger.LogInformation("Запрос UpdateOrderAsync выполнен");

        return Ok(responce);
    }

    [HttpPost]
    [Route("Remove={id}")]
    public async Task<IActionResult> RemoveOrderAsync(Guid id)
    {
        _logger.LogInformation("Запрос RemoveOrderAsync получен");

        var result = await _repo.RemoveOrderAsync(id);

        _logger.LogInformation("Запрос RemoveOrderAsync выполнен");

        return Ok(result);

    }

    [HttpPost]
    [Route("Remove/Order={orderId}/Book={bookId}")]
    public async Task<IActionResult> RemoveOrderAsync(Guid orderId, Guid bookId)
    {
        _logger.LogInformation("Запрос RemoveOrderAsync получен");

        var result = await _repo.RemoveBookInOrderAsync(orderId, bookId);

        _logger.LogInformation("Запрос RemoveOrderAsync выполнен");

        return Ok(result);

    }


    protected override void Dispose(bool disposing)
    {
        _repo.Dispose();
        base.Dispose(disposing);
    }
}