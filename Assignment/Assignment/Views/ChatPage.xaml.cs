using Assignment.Models;
using Assignment.ViewModels;
using Prism.Navigation;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Assignment.Views
{
    public partial class ChatPage : ContentPage
    {
        //public ChatPageViewModel chatVM;
        public ICommand ScrollListCommand { get; set; }
        int Count = 0;
        public ChatPage()
        {
            InitializeComponent();
            
            //ScrollListCommand = new Command(() =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //      ChatList.ScrollTo((this.BindingContext as ChatPageViewModel).ListChat.Last(), ScrollToPosition.End, false)
            //  );
            //});
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //var target = chatvm.ListChat.Last();
            //ChatList.ScrollTo(target, ScrollToPosition.Start, true);
        }
        private void listItemAppearing(object sender, ItemVisibilityEventArgs args)
        {
            var chatvm = BindingContext as ChatPageViewModel;
            if (chatvm.ListChat.Count > 0)
            {
                if (chatvm.ListChat.Count != Count)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        var target = ChatList.ItemsSource.OfType<Chat>().Last();
                        ChatList.ScrollTo(target, ScrollToPosition.End, false);
                    });

                }
            }


        }
    }
}
