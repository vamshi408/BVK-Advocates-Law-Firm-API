using BVK_Advocates_Law_Firm.IRepository;
using BVK_Advocates_Law_Firm.Models;

namespace BVK_Advocates_Law_Firm.Repository
{
    public class ClientRepository : IClientRepository
    {
        List<ClientModel> clients;

        public ClientRepository()
        {

            clients = new List<ClientModel>() {
                new ClientModel
                {
                    Id = 1,
                    SurName = "Reddy",
                    FirstName = "Ramesh",
                    MiddleName = "Kumar",
                    PhoneNumber = "9876543210",
                    AltPhoneNumber = "9123456780",
                    WhatsAppPhoneNumber = "9876543210",
                    Email = "ramesh.kumar@example.com",
                    Country = "India",
                    State = "Telangana",
                    District = "Medchal-Malkajgiri",
                    Mandal = "Quthbullapur",
                    Village = "Bachupally",
                    ZipCode = "500090",
                    Jurisdiction = "Cyberabad"
                },
                new ClientModel
                {
                    Id = 2,
                    SurName = "Sharma",
                    FirstName = "Priya",
                    MiddleName = "Devi",
                    PhoneNumber = "9988776655",
                    AltPhoneNumber = "",
                    WhatsAppPhoneNumber = "9988776655",
                    Email = "priya.sharma@example.com",
                    Country = "India",
                    State = "Telangana",
                    District = "Hyderabad",
                    Mandal = "Ameerpet",
                    Village = "Ameerpet",
                    ZipCode = "500016",
                    Jurisdiction = "Hyderabad Central"
                }
            };
        }
        public bool AddEmployee(ClientModel client)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClientModel> GetAll()
        {
            return clients.ToList();
        }

        public ClientModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ClientModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public ClientModel UpdateEmployee(ClientModel client)
        {
            throw new NotImplementedException();
        }
    }
}
