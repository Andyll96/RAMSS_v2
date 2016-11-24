using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RAMSS_v2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            myFrame.Navigate(typeof(HomePage));
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Color.FromArgb(0,63,63,63);
            titleBar.ForegroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = Color.FromArgb(0, 63, 63, 63);
            titleBar.ButtonForegroundColor = Colors.White;
            
        }

       

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(typeof(HomePage));
        }

        private void hamburgerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void courseScheduleListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myFrame.Navigate(typeof(CourseSchedulePage));
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void academicsListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myFrame.Navigate(typeof(AcademicsPage));
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void favouritesListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myFrame.Navigate(typeof(FavouritesPage));
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void studentFeesListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myFrame.Navigate(typeof(FinancialPage));
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void alertsListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myFrame.Navigate(typeof(AlertsPage));
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void myGradesListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myFrame.Navigate(typeof(MyGradesPage));
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (myFrame.CanGoBack)
                myFrame.GoBack();
        }

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (myFrame.CanGoForward)
                myFrame.GoForward();
        }
    }
}
