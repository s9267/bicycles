using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using bicycles.Models;
using bicycles.Services;
using Xamarin.Forms;

namespace bicycles.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; private set; } = new ObservableCollection<User>();

        private UserServices userServices = new UserServices();
        public Command LoadUsersCommand { get; set; }

        public UsersViewModel()
        {
            LoadUsersCommand = new Command(async () => await ExecuteLoadUsersCommand());
        }

        public async Task RetrieveUsers() {
            var users = await userServices.GetAll();
            Users.Clear();

            foreach (User user in users)
            {
                Users.Add(user);
            }
        }

        async Task ExecuteLoadUsersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await RetrieveUsers();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
