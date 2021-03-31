using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommunicateWithBooksApi.EntityFrameworkCore.BooksApiContract
{
    public interface IBookApi
    {
        HttpClient GetBaseURL();
        Task<HttpContent> GetBooksList(int levelNumber);
        Task<HttpContent> GetPdfFile(int id);

    }
}
