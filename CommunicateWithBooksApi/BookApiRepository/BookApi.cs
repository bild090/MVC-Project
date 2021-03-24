using CommunicateWithBooksApi.EntityFrameworkCore.BooksApiContract;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;



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

        public HttpContent GetBooksList(int levelNumber)
        {
            var client = GetBaseURL();
            var responseTask = client.GetAsync("BookApi/" + levelNumber);
            responseTask.Wait();

            return  responseTask.Result.Content;
        }


        public HttpContent GetPdfFile(int id)
        {
            var client = GetBaseURL();
            var responseTask = client.GetAsync("BookApi/pdf/" + id);
            responseTask.Wait();

            return responseTask.Result.Content;
        }
    }
}
