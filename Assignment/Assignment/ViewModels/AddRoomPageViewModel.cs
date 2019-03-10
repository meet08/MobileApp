using Assignment.Models;
using Assignment.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.ViewModels
{
	public class AddRoomPageViewModel : ViewModelBase
	{

        DBFire db = new DBFire();

        public DelegateCommand OnPressedButton { get; }
        public AddRoomPageViewModel(INavigationService navigation) : base(navigation)
        {
            NavigationService = navigation;
            OnPressedButton = new DelegateCommand(AddCommandExecuted, AddCommandCanExecute).ObservesProperty(() => RoomName);
        }

        private string roomname;

        public string RoomName
        {
            get { return roomname; }
            set { SetProperty(ref roomname, value); RaisePropertyChanged("RoomName"); }
        }

        public bool AddCommandCanExecute()
        {
            if (string.IsNullOrWhiteSpace(RoomName))
                return false;
            else return true;
        }

        public async void AddCommandExecuted()
        {
            var db = new DBFire();
            await db.saveRoom(new Room() { Name = roomname });
            await NavigationService.GoBackAsync();
        }
    }
	
}
