using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace App15
{
    public sealed partial class PageHeader : UserControl
    {
        public PageHeader()
        {
            this.InitializeComponent();
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(object), typeof(PageHeader), new PropertyMetadata(null));
        public object Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register("SubTitle", typeof(object), typeof(PageHeader), new PropertyMetadata(null));
        public object SubTitle
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
