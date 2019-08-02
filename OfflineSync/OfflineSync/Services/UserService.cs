using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfflineSync.Model;
using Plugin.Connectivity;

namespace OfflineSync.Services
{
    public class UserService : IUserService
    {
        private string urlService = "https://offlinesyncservice.azurewebsites.net";
       
        public MobileServiceClient MobileService { get; set; }
        IMobileServiceSyncTable<User> userTable;
        public UserService()
        {

        }
        public async Task Initialize()
        {
            const string path = "localStore.db";
            MobileService = new MobileServiceClient(urlService);
            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<User>();
            await MobileService.SyncContext.InitializeAsync(store,new MobileServiceSyncHandler());
            userTable = MobileService.GetSyncTable<User>();
        }
        private async void Synchronization()
        {
            if (!CrossConnectivity.Current.IsConnected)
                return;
            try
            {
                await MobileService.SyncContext.PushAsync();
                await userTable.PullAsync(null, userTable.CreateQuery());
            }
            catch(Exception e)
            {
            }
        }
        public async void AddUser(string userName)
        {
            var user = new User
            {
                UserName=userName
            };
            try
            {
                 await userTable.InsertAsync(user);
                Synchronization();
            }
            catch(Exception e)
            {

            }
           
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            Synchronization();
            IEnumerable<User> users = await userTable.ToListAsync();
            var x = 3;
            return users;
            
        }
    }
}
