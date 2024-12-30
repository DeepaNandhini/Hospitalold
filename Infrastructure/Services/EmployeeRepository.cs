using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return  _appDbContext.Employees.ToList();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
