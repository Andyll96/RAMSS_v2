﻿using RAMSS_v2.UserDataSource;
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
    public sealed partial class AcademicsPage : Page
    {

        User violet;

        public AcademicsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            violet = (User)e.Parameter;
            System.Diagnostics.Debug.WriteLine(e.Parameter);
        }

        private void courseEnrollmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CourseEnrollmentPage),violet);
        }

        private void academciCareerOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AcademicCareerOptions),violet);
        }
    }
}
