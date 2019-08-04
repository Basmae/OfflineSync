using OfflineSync.Model;
using OfflineSync.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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
        public ICommand DeleteCommand { get; set; }
        public User SelectedUser { get; set; }
        public UsersViewModel()
        {
            UserService = new UserService();
            DeleteCommand = new Command(DeleteUser);
            GetData();
        }
        private async void DeleteUser()
        {
            UserService.DeleteUser(SelectedUser.id);
           await App.Current.MainPage.DisplayAlert("", "User Deleted Successfully", "OK");
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void GetData()
        {
            await UserService.Initialize();
            Users = await UserService.GetUsers();
        }
    }
}
