using Microsoft.WindowsAzure.MobileServices;
using OfflineSync.Model;
using OfflineSync.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OfflineSync
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
      /*  private MobileServiceCollection<User, User> users;
        private IMobileServiceTable<User> userTable = App.MobileService*/
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
