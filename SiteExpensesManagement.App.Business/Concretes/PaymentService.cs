using Newtonsoft.Json;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Contracts.Dtos.Payments;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.Business.Concretes
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44326/creditcards/");
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<CreditCard>> Add(PaymentForBillDto paymentForAddDto)
        {
            var url = "https://localhost:44326/api/creditcards/getusercreditcards";
            var resultJson = await _httpClient.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<List<CreditCard>>(resultJson);

            Task.WaitAll();
            return result;
        }
        public async Task<List<CreditCard>> Add(PaymentForDuesDto paymentForAddDto)
        {
            var url = "https://localhost:44326/api/creditcards/getusercreditcards";
            var resultJson = await _httpClient.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<List<CreditCard>>(resultJson);

            Task.WaitAll();
            return result;
        }

        public async Task<CreditCard> GetUserCard(string id)
        {
            var url = $"https://localhost:44326/api/creditcards/getbyid?id={id}";
            var resultJson = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<CreditCard>(resultJson); 
        }
    }
}