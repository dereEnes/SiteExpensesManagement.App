using Newtonsoft.Json;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Contracts.Dtos.CreditCards;
using SiteExpensesManagement.App.Contracts.Dtos.Payments;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.Business.Concretes
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly IRepository<BillPayment> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentService(IHttpClientFactory httpClientFactory, IRepository<BillPayment> repository, IUnitOfWork unitOfWork)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44326");
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(PaymentForBillDto paymentForAddDto)
        {
            
            var card = new PaymentDto()
            {
                
            };
            var url = "https://localhost:44326/api/payments/";
            var json = JsonConvert.SerializeObject(card);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, data);
            var resultJson =await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<SuccessResult>(resultJson);

            if (result.Success)
            {
                var paymentToAdd = new BillPayment
                {
                    BillId = paymentForAddDto.BillId,
                    CreatedAt = DateTime.Now,
                    UserId = paymentForAddDto.UserId
                };
                _repository.Add(paymentToAdd);
            }

            return new SuccessResult();
        }
        public async Task<IResult> Add(PaymentForDuesDto paymentForAddDto)
        {
            var card = new CreditCardDto()
            {
                Price = paymentForAddDto.Amount,
                CardNumber = paymentForAddDto.CreditCard.CardNumber,
                NameOnCard = paymentForAddDto.CreditCard.NameOnCard,
                ExpiryMonth = paymentForAddDto.CreditCard.ExpiryMonth,
                ExpiryYear = paymentForAddDto.CreditCard.ExpiryYear,
                Cvv = paymentForAddDto.CreditCard.Cvv
            };
            var url = "https://localhost:44326/api/creditCards";
            var json = JsonConvert.SerializeObject(card);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, data);
            var resultJson = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<SuccessResult>(resultJson);
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