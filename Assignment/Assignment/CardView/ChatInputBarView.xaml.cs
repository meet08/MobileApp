using Assignment.ViewModels;
using Assignment.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment.CardView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatInputBarView : ContentView
	{
        public ChatInputBarView()
        {
            InitializeComponent();
        }
        public void Handle_Completed(object sender, EventArgs e)
        {
            (this.Parent.Parent.BindingContext as ChatPageViewModel).OnSend.Execute();
            chatTextInput.Focus();

            (this.Parent.Parent as ChatPage).ScrollListCommand.Execute(null);
        }
    }
}