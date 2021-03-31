using CommunicateWithBooksApi.EntityFrameworkCore.BooksApiContract;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommunicateWithBooksApi.EntityFrameworkCore.BookApiRepository
{
    public class BookApi : IBookApi
    {
        public HttpClient GetBaseURL()
        {

            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            var client = new HttpClient(httpClientHandler);

            //HttpClientHandler clientHandler = new HttpClientHandler();

            //clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            ////HttpClient client = new HttpClient(clientHandler);

            client.BaseAddress = new Uri("https://192.168.100.63:44310/api/");
            return client;
        }

        public async Task<HttpContent> GetBooksList(int levelNumber)
        {
            var client = GetBaseURL();
            var responseTask = await client.GetAsync("BookApi/" + levelNumber);
            //responseTask.Wait();

            return responseTask.Content;
        }


        public async Task<HttpContent> GetPdfFile(int id)
        {
            var client = GetBaseURL();
            var responseTask = await client.GetAsync("BookApi/pdf/" + id);
            try
            {
                //responseTask.Wait();

                return responseTask.Content;
            }
            catch (Exception)
            {
                return responseTask.Content;
            }
            
        }
    }
}
