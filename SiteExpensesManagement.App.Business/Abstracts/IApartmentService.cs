using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IApartmentService
    {
        Task<Apartment> GetById(int id);
        List<Apartment> GetAll();
    }
}
