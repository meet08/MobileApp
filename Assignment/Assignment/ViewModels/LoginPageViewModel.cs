using Assignment.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
        public DelegateCommand LoginCommand { get; }

        public LoginPageViewModel(INavigationService navigation) :base(navigation)
        {
            NavigationService = navigation;
            LoginCommand = new DelegateCommand(LogInCommandExecuted, LogInCommandCanExecute)
                .ObservesProperty(() => UserName);
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); RaisePropertyChanged("Username"); }
        }

        public bool LogInCommandCanExecute()
        {
            if (string.IsNullOrWhiteSpace(UserName))
                return false; 
            else return true;
        }

        public async void LogInCommandExecuted()
        {
            User.UserName = UserName;
            await NavigationService.NavigateAsync("RoomPage");
        }
    }
}
