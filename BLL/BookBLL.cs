using System;
using System.Collections.Generic;
using System.Text;

using Dal;
using Entities;

namespace BLL
{
    public class BookBLL
    {
        private readonly BookDal _bookDal = new BookDal();

        public List<Book> GetAll(string search = "") => _bookDal.GetAll(search);

        public void Save(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.ISBN))
                throw new ArgumentException("ISBN is required.");
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Title is required.");
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("Author is required.");
            if (book.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");
            if (book.Stock < 0 || book.MinStock < 0)
                throw new ArgumentException("Stock values cannot be negative.");

            if (book.BookId == 0)
                _bookDal.Insert(book);
            else
                _bookDal.Update(book);
        }

        public void Deactivate(int bookId)
        {
            if (bookId <= 0)
                throw new ArgumentException("Invalid book ID.");

            _bookDal.Deactivate(bookId);
        }
    }
}
