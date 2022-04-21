using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiteExpensesManagement.App.Business.Concretes
{
    public class BillPaymentService : IBillPaymentService
    {
        private readonly IRepository<BillPayment> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;

        public BillPaymentService(IRepository<BillPayment> repository, IUnitOfWork unitOfWork, IBillService billService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _billService = billService;
        }

        public void Add(BillPayment billPayment)
        {
            _repository.Add(billPayment);
            _billService.UpdateBillAsPaid(billPayment.BillId);
            _unitOfWork.Commit();
        }

        public List<BillPayment> GetAll()
        {
            return _repository.GetAll().Include(x => x.Bill).Include(x => x.User).ToList();
        }

        public List<BillPayment> GetUserPayments(string id)
        {
            return _repository.Get(x => x.UserId == id).Include(x => x.Bill).ToList();
        }
    }
}
