using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly salesdbContext _dbcontext;

        public CustomerRepository( salesdbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public async Task<int> AddCustomer(Customers customers)
        {
           if(_dbcontext!=null)
           {
               await _dbcontext.Customers.AddAsync(customers);
               await _dbcontext.SaveChangesAsync();
               return customers.CustomerId;

           }
           return 0;
        }

        public async Task<int> DeleteCustomer(int? CusomerId)
        {
            int result=0;
             if(_dbcontext!=null)
             {
                 var customer= await _dbcontext.Customers.FirstOrDefaultAsync(x=>x.CustomerId==CusomerId);
                 if(customer!=null)
                 {
                     _dbcontext.Customers.Remove(customer);
                     result=await _dbcontext.SaveChangesAsync();
                 }
                 
             }
             return result;
        }

        public async Task<Customers> GetCustomer(int? CusomerId)
        {
           if(_dbcontext!=null)
           {
              var customer= await _dbcontext.Customers.FirstOrDefaultAsync(x=>x.CustomerId==CusomerId);
                 if(customer!=null)
                 {
                    return customer;
                     
                 }
           }
           return null;
        }

        public async Task<List<Customers>> GetCustomers()
        {
             if(_dbcontext!=null)
           {
              var customers= await _dbcontext.Customers.ToListAsync();
                
                    return customers;
                     
                 
           }
           return null;
        }

        public async Task UpdateCustomer(Customers customers)
        {
             if(_dbcontext!=null)
           {
              
                 if(customers!=null)
                 {
                     _dbcontext.Customers.Update(customers);
                     await _dbcontext.SaveChangesAsync();
                     
                 }
           }
           
        }
    }
}