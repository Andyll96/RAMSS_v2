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
    public sealed partial class CourseScheduleListViewPage : Page
    {
        User violet;

        public CourseScheduleListViewPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            violet = (User)e.Parameter;

            listView.Text = "Monday\n";
            foreach (var course in violet.takingCoursesY3)
            {
                if (course.Value.dayOfWeek.Equals("Monday"))
                listView.Text +=  string.Join("", course.Value.calendarInfo(false));
            }
            listView.Text += "Tuesday\n";
            foreach (var course in violet.takingCoursesY3)
            {
                if (course.Value.dayOfWeek.Equals("Tuesday"))
                    listView.Text += string.Join("", course.Value.calendarInfo(false));
            }
            listView.Text += "Wednesday\n";
            foreach (var course in violet.takingCoursesY3)
            {
                if (course.Value.dayOfWeek.Equals("Wednesday"))
                    listView.Text += string.Join("", course.Value.calendarInfo(false));
            }
            listView.Text += "Thursday\n";
            foreach (var course in violet.takingCoursesY3)
            {
                if (course.Value.dayOfWeek.Equals("Thursday"))
                    listView.Text += string.Join("", course.Value.calendarInfo(false));
            }
            listView.Text += "Friday\n";
            foreach (var course in violet.takingCoursesY3)
            {
                if (course.Value.dayOfWeek.Equals("Friday"))
                    listView.Text += string.Join("", course.Value.calendarInfo(false));
            }
        }
    }
}
