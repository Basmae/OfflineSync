using OfflineSync.Model;
using OfflineSync.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfflineSync.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new UsersViewModel();
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var vm = (UsersViewModel)(BindingContext);
            vm.DeleteCommand.Execute((User)e.SelectedItem);

        }
    }
}