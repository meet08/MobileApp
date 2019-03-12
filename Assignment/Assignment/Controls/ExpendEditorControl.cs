using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Assignment.Controls
{
    public class ExpendEditorControl:Editor
    {
        public static BindableProperty PlaceholderProperty
          = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(ExpendEditorControl));

        public static BindableProperty PlaceholderColorProperty
           = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(ExpendEditorControl), Color.LightGray);

        public static BindableProperty HasRoundedCornerProperty
        = BindableProperty.Create(nameof(HasRoundedCorner), typeof(bool), typeof(ExpendEditorControl), false);

        public static BindableProperty IsExpandableProperty
        = BindableProperty.Create(nameof(IsExpandable), typeof(bool), typeof(ExpendEditorControl), false);

        public bool IsExpandable
        {
            get { return (bool)GetValue(IsExpandableProperty); }
            set { SetValue(IsExpandableProperty, value); }
        }
        public bool HasRoundedCorner
        {
            get { return (bool)GetValue(HasRoundedCornerProperty); }
            set { SetValue(HasRoundedCornerProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public ExpendEditorControl()
        {
            TextChanged += OnTextChanged;
        }

        ~ExpendEditorControl()
        {
            TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsExpandable)
                InvalidateMeasure();


        }

    }
}
