using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class BookServiceTest
    {
        [Fact]
        public void BookServiceTesting()
        {
            //assume
            var bookService = new BookService();

            //act
            bookService.Post(new Book
            {
                Title = "Test.Book.Title Nr1",
                Author = "Test.Book.Author Nr1",
                Language = "Test.Book.Language Nr1"
            });
            bookService.Delete(2);
            bookService.Put(2 ,new Book
            {
                Title = "Test.Book.Title Nr2",
                Author = "Test.Book.Author Nr2",
                Language = "Test.Book.Language Nr2"
            });
            
            //assert
            Assert.Equal("Test.Book.Title Nr1", bookService.Get(3).Title);
            Assert.Equal("Test.Book.Author Nr1", bookService.Get(3).Author);
            Assert.Equal("Test.Book.Language Nr1", bookService.Get(3).Language);
            Assert.Equal("Test.Book.Title Nr2", bookService.Get(2).Title);
            Assert.Equal("Test.Book.Author Nr2", bookService.Get(2).Author);
            Assert.Equal("Test.Book.Language Nr2", bookService.Get(2).Language);
        }
    }
}
