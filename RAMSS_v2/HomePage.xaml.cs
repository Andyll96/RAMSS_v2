using RAMSS_v2.UserDataSource;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RAMSS_v2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            User violet = (User)e.Parameter;
            personalInfoTextBlock.Text = "Name: " + violet.name + "\nAddress: " + violet.address + "\nEmail: " + violet.email + "\nPhone Number: " + violet.phoneNumber;
            emergencyInfoTextBlock.Text = "Name: " + violet.emergencyContactName + "\nPhone Number: " + violet.emergencyContactPhoneNumber;
            System.Diagnostics.Debug.WriteLine(e.Parameter);
        }

        private void courseScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CourseSchedulePage));
        }

        private void studentFeesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FinancialPage));
        }

        private void academicsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AcademicsPage));
        }

        private void favouritesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FavouritesPage));
        }

        private void alertsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AlertsPage));
        }

        private void myGradesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyGradesPage));
        }
    }
}
