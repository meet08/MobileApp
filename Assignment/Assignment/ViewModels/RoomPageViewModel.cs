using Assignment.Models;
using Assignment.Service;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment.ViewModels
{
	public class RoomPageViewModel : ViewModelBase
	{
        DBFire db = new DBFire();
        private List<Room> rm { get; set; }
        public DelegateCommand<object>Handle_ItemSelected { get; }
        public DelegateCommand Handle_Refreshing { get; }
        public DelegateCommand OnToolbarItemClicked { get; }
        public RoomPageViewModel(INavigationService navigation) : base(navigation)
        {
            NavigationService = navigation;
            Handle_ItemSelected = new DelegateCommand<object>(async (object item) => await SelectedItemExecuted(item));
            Handle_Refreshing = new DelegateCommand(RefreshCommandExecuted);
            OnToolbarItemClicked = new DelegateCommand(ToolbarCommandExecuted);
            rm = new List<Room>();
        }
        public List<Room> RM
        {
            get { return rm; }
            set
            {
                rm = value;
                RaisePropertyChanged("RM");
            }
        }
        public async Task SelectedItemExecuted(object obj)
        {
            var selectRoom = obj;
            await NavigationService.NavigateAsync("ChatPage");
            MessagingCenter.Send<RoomPageViewModel, object>(this, "RoomProp", selectRoom);
        }

        public async void RefreshCommandExecuted()
        {

        }

        public async void ToolbarCommandExecuted()
        {
            await NavigationService.NavigateAsync("AddRoomPage");
        }

        public async override void OnNavigatedTo(INavigationParameters param)
        {
            await Init();
        }

        public async Task Init()
        {
            IsBusy = true;
            var list = await db.getRoomList();
            RM = list;
            IsBusy = false;
        }

    }
}
