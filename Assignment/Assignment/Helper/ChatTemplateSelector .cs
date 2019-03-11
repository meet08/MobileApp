using Assignment.CardView;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Assignment.Helper
{
    class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;
        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as Chat;
            if (messageVm == null)
            {
                return null;
            }
            return (messageVm.UserName == User.UserName) ? outgoingDataTemplate : incomingDataTemplate;
        }
    }
}
