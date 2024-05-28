using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<bool> CreateBook(Book book);
        Task<List<Book>> GetBookList();
        Task<Book> UpdateBook(Book book);
        Task<Book> GetBook(int id);
        Task<bool> DeleteBook(int key);
    }
}
