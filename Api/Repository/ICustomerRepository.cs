using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Model;

namespace Api.Repository
{
    public interface ICustomerRepository 
    {
        Task<List<Customers>> GetCustomers();

     
        Task<Customers> GetCustomer(int? CusomerId);

        Task<int> AddCustomer(Customers customers);

        Task<int> DeleteCustomer(int? CusomerId);

        Task UpdateCustomer(Customers Customers);
    }
}