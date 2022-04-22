using AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillPaymentService _billPaymentService;
        private readonly IDuesPaymentService _duesPaymentService;
        private readonly IMapper _mapper;

        public PaymentService(IHttpClientFactory httpClientFactory,
            IUnitOfWork unitOfWork,
            IBillPaymentService billPaymentService,
            IDuesPaymentService duesPaymentService,
            IMapper mapper)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44326");
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            _unitOfWork = unitOfWork;
            _billPaymentService = billPaymentService;
            _duesPaymentService = duesPaymentService;
            _mapper = mapper;
        }

        public async Task<IResult> Add(PaymentForBillDto paymentForAddDto)
        {
            try { 
            var paymentDto = _mapper.Map<PaymentDto>(paymentForAddDto);
            var url = "https://localhost:44326/api/payments";
            var json = JsonConvert.SerializeObject(paymentDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, data);
            var resultJson =await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Result>(resultJson);
                var paymentToAdd = new BillPayment
                {
                    BillId = paymentForAddDto.BillId,
                    CreatedAt = DateTime.Now,
                    UserId = paymentForAddDto.UserId
                };
                _billPaymentService.Add(paymentToAdd);
                }
                else
                {
                    return new ErrorResult();
                }
            }catch(Exception e)
            {
                return new ErrorResult("Başarısız" + e.Message.ToString());
            }

            return new SuccessResult("Başarılı");
        }
        public async Task<IResult> Add(PaymentForDuesDto paymentForAddDto)
        {
            try
            {
                var paymentDto = _mapper.Map<PaymentDto>(paymentForAddDto);
                var url = "https://localhost:44326/api/payments";
                var json = JsonConvert.SerializeObject(paymentDto);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, data);
                var resultJson = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var paymentToAdd = new DuesPayment
                    {
                        DuesId = paymentForAddDto.DuesId,
                        CreatedAt = DateTime.Now,
                        UserId = paymentForAddDto.UserId
                    };
                    _duesPaymentService.Add(paymentToAdd);
                }
                else
                {
                    return new ErrorResult();
                }

            }
            catch (Exception e)
            {
                return new ErrorResult("Başarısız" + e.Message.ToString());
            }
            return new SuccessResult("Ödeme gerçekleştirildi");
        }

        public async Task<CreditCard> GetUserCard(string id)
        {
            try
            {
                var url = $"https://localhost:44326/api/creditcards/getbyid?id={id}";
                var resultJson = await _httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<CreditCard>(resultJson);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}