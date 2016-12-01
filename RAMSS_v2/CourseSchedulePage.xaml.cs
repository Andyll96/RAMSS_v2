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
    public sealed partial class CourseSchedulePage : Page
    {
        User violet;

        public CourseSchedulePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            violet = (User)e.Parameter;
        }

        private void calendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            DateTime selectedDate = args.AddedDates[0].Date;
            dayInfo.Text = selectedDate.DayOfWeek.ToString();
            if (violet.takingCoursesY3.Any())
            {
                foreach (var course in violet.takingCoursesY3)
                {
                    // System.Diagnostics.Debug.WriteLine(string.Join(",", course.Value.calendarInfo()));
                    if (course.Value.dayOfWeek.Equals(selectedDate.DayOfWeek.ToString()) && (( selectedDate < violet.majorProgram.semester5.endDate && selectedDate > violet.majorProgram.semester5.startDate) || (selectedDate < violet.majorProgram.semester6.endDate && selectedDate > violet.majorProgram.semester6.startDate)))
                    {
                        dayInfo.Text +=  "\n\t" + string.Join("", course.Value.calendarInfo(true));
                    }
                }
            }
          
        }

        private void listViewButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CourseScheduleListViewPage), violet);
        }
    }
}
