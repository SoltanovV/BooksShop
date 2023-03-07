using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
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
        [Route("{id}")]
        public async Task<ActionResult<BooksOrdersResponces>> GetBookIdAsync (int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetBookIdAsync получен");
                var result = await _repo.GetIdAsync(id);
                var responce = _mapper.Map<BooksOrdersResponces>(result);
                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("name=/{name}")]
        public async Task<ActionResult<IEnumerable<BooksOrdersResponces>>> GetBookNameAsync(string name)
         {
            try
            {
                _logger.LogInformation("Запрос GetBookNameAsync получен");
                var result = await _repo.GetListBooksNameAsync(name);
                var responce = _mapper.Map<BooksOrdersResponces>(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("date=/{date}")]
        public async Task<ActionResult<IEnumerable<BooksOrdersResponces>>> GetBookDateAsync(DateTime date)
        {
            try
            {
                _logger.LogInformation("Запрос GetBookNameAsync получен");
                var result = await _repo.GetListBooksDateAsync(date);
                var responce =_mapper.Map<BooksOrdersResponces>(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
