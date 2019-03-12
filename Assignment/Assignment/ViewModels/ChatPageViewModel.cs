using Assignment.Models;
using Assignment.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment.ViewModels
{
	public class ChatPageViewModel : ViewModelBase
	{
        DBFire db = new DBFire();
        Room rm = new Room();
        private string id;
        private string roomname;
        public DelegateCommand OnSend { private set; get; }
        private string message;
        public ObservableCollection<Chat> _lstChat;

        public bool ShowScrollTap { get; set; } = false; //Show the jump icon 
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }
        public Queue<Chat> DelayedMessages { get; set; } = new Queue<Chat>();

        public DelegateCommand MessageAppearingCommand { get; set; }
        public DelegateCommand MessageDisappearingCommand { get; set; }


        public ChatPageViewModel(INavigationService navigation) : base(navigation)
        {
            NavigationService = navigation;
            OnSend = new DelegateCommand(Handle_Clicked);
            _lstChat = new ObservableCollection<Chat>();
           
            //MessageAppearingCommand = new DelegateCommand<Chat>(OnMessageAppearing);
            //MessageDisappearingCommand = new DelegateCommand<Chat>(OnMessageDisappearing);
        }



        public ObservableCollection<Chat> ListChat
        {
            get
            {
                return _lstChat;
            }
            set
            {
                 SetProperty(ref _lstChat, value);
                    RaisePropertyChanged("ListChat");
            }
        }
        public string Message
        {
            get { return message; }
            set
            {
                SetProperty(ref message, value);
                RaisePropertyChanged("Message");
            }
        }
        public string RoomName
        {
            get { return roomname; }
            set
            {
                SetProperty(ref roomname, value);
                RaisePropertyChanged("RoomName");
            }
        }
        public string Id
        {
            get { return id; }
            set
            {
                SetProperty(ref id, value);
                RaisePropertyChanged("Id");
            }
        }

        public async override void OnNavigatingTo(INavigationParameters param)
        {
            
            Id = param["Id"] as string;
            RoomName = param["RoomName"] as string;
            await Init();
        }

        public async Task Init()
        {
            //MessagingCenter.Subscribe<RoomPageViewModel, object>(this, "RoomProp", (page, data) =>
            //{
            //    Room typed = (Room)data;
            //    ListChat = db.subChat(typed.Key);
            //    MessagingCenter.Unsubscribe<RoomPageViewModel, object>(this, "RoomProp");

            //});
            ListChat = db.subChat(Id);
            RaisePropertyChanged("ListChat");

        }

        public async void Handle_Clicked()
        {
            // firsth chat object
            //room name 1---okey

            //var chatOBJ = new Chat { UserMessage = Message, UserName = User.UserName };
            //await db.saveMessage(chatOBJ, Id);
            if (!string.IsNullOrEmpty(Message))
            {
                var chatOBJ = new Chat { UserMessage = Message, UserName = User.UserName };
              //  ListChat.Insert(0, chatOBJ);
               // Messages.Insert(0, new ListChat() { Text = TextToSend, User = App.User });
                await db.saveMessage(chatOBJ, Id);
                Message = string.Empty;
            }


        }
        public ChatPageViewModel()
        {

        }
        public async Task GettingChat()
        {

        }
    }
}
