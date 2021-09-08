using Xunit;

namespace AspNetSandbox.Tests
{
    public class BookServiceTest
    {
        private BookService bookService;

        [Fact]
        public void BookServiceTesting()
        {
            // assume
            bookService = new BookService();

            // act
            bookService.PostBook(new Book
            {
                Title = "Test.Book.Title Nr1",
                Author = "Test.Book.Author Nr1",
                Language = "Test.Book.Language Nr1",
            });
            bookService.DeleteBook(2);
            bookService.PutBook(2, new Book
            {
                Title = "Test.Book.Title Nr2",
                Author = "Test.Book.Author Nr2",
                Language = "Test.Book.Language Nr2",
            });

            // assert
            Assert.Equal("Test.Book.Title Nr1", bookService.GetBookById(3).Title);
            Assert.Equal("Test.Book.Author Nr1", bookService.GetBookById(3).Author);
            Assert.Equal("Test.Book.Language Nr1", bookService.GetBookById(3).Language);
            Assert.Equal("Test.Book.Title Nr2", bookService.GetBookById(2).Title);
            Assert.Equal("Test.Book.Author Nr2", bookService.GetBookById(2).Author);
            Assert.Equal("Test.Book.Language Nr2", bookService.GetBookById(2).Language);
        }
    }
}
