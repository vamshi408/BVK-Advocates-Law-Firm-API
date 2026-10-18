using BVK_Advocates_Law_Firm.Models;

namespace BVK_Advocates_Law_Firm.IRepository
{
    public interface IClientRepository
    {
        bool AddEmployee(ClientModel client);
        ClientModel UpdateEmployee(ClientModel client);
        bool DeleteById(int id);
        List<ClientModel> GetAll();
        ClientModel GetById(int id);
        ClientModel GetByName(string name);
    }
}
