using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("{number}")]
        public async Task<ActionResult<BooksOrdersResponces>> GetBookIdAsync(int number)
        {
            try
            {
                _logger.LogInformation("Запрос GetBookIdAsync получен");
                var result = await _repo.GetOrderNumberAsync(number);
                var responce = _mapper.Map<BooksOrdersResponces>(result);
                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<BooksOrdersResponces>> CreateOrderAsync(int number)
        {
            try
            {
                _logger.LogInformation("Запрос GetBookIdAsync получен");
                var result = await _repo.GetOrderNumberAsync(number);
                var responce = _mapper.Map<BooksOrdersResponces>(result);
                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}
