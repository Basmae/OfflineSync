using OfflineSync.Services;
using OfflineSync.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OfflineSync.ViewModel
{
    public class MainViewModel:PropertyChange
    {
        private string userName;
        public string UserName { get=>userName; set {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            } }
        public ICommand AddUserCommand { get; set; }
        public ICommand GetUsersCommand { get; set; }
        private IUserService UserService { get; set; }

        public MainViewModel()
        {
            AddUserCommand = new Command(AddUser);
            GetUsersCommand = new Command(GetUsers);
            UserService = new UserService();
        }
        private async void AddUser()
        {
           await UserService.Initialize();
           UserService.AddUser(UserName);
           await App.Current.MainPage.DisplayAlert("Added User", "User Added Successfully", "OK");
          //  UserName = "";
        }
        private void GetUsers()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new UsersPage());
        }
    }
}
