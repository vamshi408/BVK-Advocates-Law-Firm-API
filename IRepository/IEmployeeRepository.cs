using BVK_Advocates_Law_Firm.Models;

namespace BVK_Advocates_Law_Firm.IRepository
{
    public interface IEmployeeRepository
    {
        bool AddEmployee(EmployeeModel employee);
        EmployeeModel UpdateEmployee(EmployeeModel employee);
        bool DeleteById(int id);
        List<EmployeeModel> GetAll();
        EmployeeModel GetById(int id);
        EmployeeModel GetByName(string name);
    }
}
