
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreSystem.Data;
using OnlineBookStoreSystem.ViewModels;
using OnlineBookStoreSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookStoreSystem.Controllers
{
    [Route("api/v1/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private OnlineDbContext _dbContext;
        public BookController(OnlineDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("AllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _dbContext.Books.ToList();
            if (books.Count > 0)
            {
                return Ok(books);
            }
            return Ok("No records");
        }
        [HttpGet]
        [Route("book/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _dbContext.Books.Where(x => x.Id == id).FirstOrDefault();
            if (book != null)
            {
                return Ok(book);
            }
            return Ok("Record does not exist");
        }
        [HttpPost]
        [Route("books/add")]
        public IActionResult AddBook(BookViewModel model)
        {
            var book = new Book
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                Genre = model.Genre,
                Description = model.Description,
                Quantity = model.Quantity,
                Price = model.Price,
                Availability = model.Availability
            };
            _dbContext.Books.Add(book);
            _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        [Route("bookToCart/add")]
        public IActionResult AddBookToCart(BookViewModel model)
        {
            var book = new Book
            {
                Id = model.Id,
                Quantity = model.Quantity
            };
            _dbContext.Books.Add(book);
            _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("BooksInCart")]
        public IActionResult GetAllBooksInCart(int id, int quantity)
        {
            var books = _dbContext.Books.Where(x => x.Id == id && x.Quantity == quantity).FirstOrDefault();
            if (books != null)
            {
                return Ok(books);
            }
            return Ok("No records");
        }

        [HttpPost]
        [Route("order/add")]
        public IActionResult AddOrder(OrderViewModel model)
        {
            var order = new Order
            {
                Id = model.Id,
                OrderTotal = model.OrderTotal
            };
            _dbContext.Orders.Add(order);
            _dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpGet]
        [Route("order/{id}")]
        public IActionResult GetOrder(int id)
        {
            var orders = _dbContext.Orders.Where(x => x.Id == id).FirstOrDefault();
            if (orders != null)
            {
                return Ok(orders);
            }
            return Ok("Record not found!");
        }
    

}

    }
