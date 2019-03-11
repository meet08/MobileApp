using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Assignment.CustomControls
{
    public class RoundedCornerList: Grid{
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create<RoundedCornerList, double>(w =>w.RoundedCornerRadius, 3);
        public double RoundedCornerRadius
        {
            get
            {
                return (double)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }
    }
}
