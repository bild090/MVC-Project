using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CommunicateWithBooksApi.EntityFrameworkCore.BooksApiContract
{
    public interface IBookApi
    {
        HttpClient GetBaseURL();
        HttpContent GetBooksList(int levelNumber);
        HttpContent GetPdfFile(int id);

    }
}
