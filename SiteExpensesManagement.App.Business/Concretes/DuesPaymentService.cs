using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SiteExpensesManagement.App.Business.Concretes
{
    public class DuesPaymentService : IDuesPaymentService
    {
        private readonly IRepository<DuesPayment> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;

        public DuesPaymentService(IRepository<DuesPayment> repository, IUnitOfWork unitOfWork, IBillService billService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _billService = billService;
        }
        public void Add(DuesPayment billPayment)
        {
            _repository.Add(billPayment);
            _billService.UpdateBillAsPaid(billPayment.DuesId);
            _unitOfWork.Commit();
        }

        public List<DuesPayment> GetAll()
        {
            return _repository.GetAll().Include(x => x.Dues).Include(x => x.User).ToList();
        }

        public List<DuesPayment> GetUserPayments(string id)
        {
            return _repository.Get(x => x.UserId == id).Include(x => x.Dues).ToList();
        }
    }
}
