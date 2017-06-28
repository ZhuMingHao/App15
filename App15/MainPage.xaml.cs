using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var list = new List<User>();
            for(var i = 0; i < 50; i++)
            {
                list.Add(new User());
            }
         
            MyList.ItemsSource = list;
        
          
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var scrollviewer = MyList.GetScrollViewer();
            CompositionPropertySet scrollerViewerManipulation = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(scrollviewer);
            Compositor compositor = scrollerViewerManipulation.Compositor;
            ExpressionAnimation expression = compositor.CreateExpressionAnimation("ScrollManipululation.Translation.Y * ParallaxMultiplier");
            expression.SetScalarParameter("ParallaxMultiplier", 0.3f);
            expression.SetReferenceParameter("ScrollManipululation", scrollerViewerManipulation);
            Visual textVisual = ElementCompositionPreview.GetElementVisual(header);
            textVisual.StartAnimation("Offset.Y", expression);
        }
    }
    public class User
    {

    }

    public static class Extensions
    {
        public static ScrollViewer GetScrollViewer(this DependencyObject element)
        {
            if (element is ScrollViewer scrollViewer)
            {
                return scrollViewer;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                var child = VisualTreeHelper.GetChild(element, i);

                var result = GetScrollViewer(child);
                if (result == null) continue;

                return result;
            }

            return null;
        }

        public static bool AlmostEqual(this float x, float y, float tolerance = 0.01f) =>
            Math.Abs(x - y) < tolerance;
    }
}
