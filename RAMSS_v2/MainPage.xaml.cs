﻿using RAMSS_v2.PageDataSource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        SearchQueries squeries = new SearchQueries();

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1280, 720);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
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

        private void searchBar_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if(args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var matchingPages = squeries.getMatchingPages(sender.Text);
                sender.ItemsSource = matchingPages.ToList();
            }
        } 

        private void searchBar_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if(args.ChosenSuggestion != null)
            {
                SelectPages(args.ChosenSuggestion as Pages);
            }
            else
            {
                var matchingPages = squeries.getMatchingPages(args.QueryText);
                if(matchingPages.Count() >= 1)
                {
                    SelectPages(matchingPages.FirstOrDefault());
                }
            }
        }

        private void SelectPages(Pages pages)
        {
            if(pages != null)
            {
                searchBar.Text = pages.name;
                if (pages.name.ToUpper().Equals("HOME"))
                {
                    myFrame.Navigate(typeof(HomePage));
                }
                else if (pages.name.ToUpper().Equals("ACADEMICS"))
                {
                    myFrame.Navigate(typeof(AcademicsPage));
                }
                else if (pages.name.ToUpper().Equals("ALERTS"))
                {
                    myFrame.Navigate(typeof(AlertsPage));
                }
                else if (pages.name.ToUpper().Equals("COURSE SCHEDULE"))
                {
                    myFrame.Navigate(typeof(CourseSchedulePage));
                }
                else if (pages.name.ToUpper().Equals("FAVOURITES"))
                {
                    myFrame.Navigate(typeof(FavouritesPage));
                }
                else if (pages.name.ToUpper().Equals("STUDENT FEES"))
                {
                    myFrame.Navigate(typeof(FinancialPage));
                }
                else if (pages.name.ToUpper().Equals("MY GRADES"))
                {
                    myFrame.Navigate(typeof(MyGradesPage));
                }
            }
        }

        private void searchBar_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var pages = args.SelectedItem as Pages;
            sender.Text = string.Format("{0}", pages.name);
        }

        private void backButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (!myFrame.CanGoForward)
                backButton.Visibility = Visibility.Collapsed;
            else
                backButton.Visibility = Visibility.Visible;
        }

        private void forwardButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (!myFrame.CanGoForward)
                forwardButton.Visibility = Visibility.Collapsed;
            else
                forwardButton.Visibility = Visibility.Visible;
        }

        private void myFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (!myFrame.CanGoBack)
                backButton.Visibility = Visibility.Collapsed;
            else
                backButton.Visibility = Visibility.Visible;
            if (!myFrame.CanGoForward)
                forwardButton.Visibility = Visibility.Collapsed;
            else
                forwardButton.Visibility = Visibility.Visible;
        }

        private void addFavouriteListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }
    }
}
