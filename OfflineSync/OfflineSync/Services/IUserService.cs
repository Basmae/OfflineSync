using OfflineSync.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSync.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        void AddUser(string userName);
        Task Initialize();
        void DeleteUser(string UserId);

    }
}
