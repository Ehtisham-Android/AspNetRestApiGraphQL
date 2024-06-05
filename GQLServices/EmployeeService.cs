using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestApiGraphQL.Controllers;
using RestApiGraphQL.Models.Emp;
using System.Data;

namespace RestApiGraphQL.GQLServices
{
    public class EmployeeService : IEmployeeService
    {
        public Task<IEnumerable<EmpTbl>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public EmpTbl GetEmployeeById(long id)
        {
            return GetEmployeeByIdAsync(id).Result;
        }

        public Task<EmpTbl> GetEmployeeByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IEmployeeService {
        // getEmployeeById
        EmpTbl GetEmployeeById(long id);
        // getEmployeeByIdAsync
        Task<EmpTbl> GetEmployeeByIdAsync(long id);
        // getAllEmployees
        Task<IEnumerable<EmpTbl>> GetAllEmployeesAsync();
        
    }
}
