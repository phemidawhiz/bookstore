using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IDbService _dbService;

        public BookService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateBook(Book book)
        {
            var result =
                await _dbService.EditData(
                    "INSERT INTO public.book (id,name, age, address, mobile_number) VALUES (@Id, @Name, @Age, @Address, @MobileNumber)",
                    book);
            return true;
        }

        public async Task<List<Book>> GetBookList()
        {
            var bookList = await _dbService.GetAll<Book>("SELECT * FROM public.book", new { });
            return bookList;
        }


        public async Task<Book> GetBook(int id)
        {
            var bookList = await _dbService.GetAsync<Book>("SELECT * FROM public.book where id=@id", new { id });
            return bookList;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var updateBook =
                await _dbService.EditData(
                    "Update public.book SET name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber WHERE id=@Id",
                    book);
            return book;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var deleteBook = await _dbService.EditData("DELETE FROM public.book WHERE id=@Id", new { id });
            return true;
        }
    }
}
