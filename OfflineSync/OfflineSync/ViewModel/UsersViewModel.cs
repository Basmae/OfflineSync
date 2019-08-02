using OfflineSync.Model;
using OfflineSync.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OfflineSync.ViewModel
{
    public class UsersViewModel:PropertyChange
    {
        private IEnumerable<User> users;
        public IEnumerable<User> Users { get => users; set {
                if (users != value)
                {
                    users = value;
                    OnPropertyChanged(nameof(Users));
                }
            } }
        private IUserService UserService { get; set; }
        public UsersViewModel()
        {
            UserService = new UserService();
            GetData();
        }
        private async void GetData()
        {
            await UserService.Initialize();
            Users = await UserService.GetUsers();
        }
    }
}
