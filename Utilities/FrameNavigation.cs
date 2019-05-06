using System;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WaldenHospitalConsumer.Utilities
{
    public class FrameNavigation
    { 

        public static void ActivateFrameNavigation(Type type)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(type);
            Window.Current.Content = frame;
            Window.Current.Activate();
        }
    }
}
