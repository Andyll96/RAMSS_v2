using RAMSS_v2.UserDataSource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class CourseEnrollmentPage : Page
    {

        User violet;
        public List<Course> fullCurriculum;
        ComboBoxItem comboBoxItem;

        public CourseEnrollmentPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            violet = (User)e.Parameter;
            fullCurriculum = violet.majorProgram.curriculum;
            courseList.ItemsSource = fullCurriculum;
            System.Diagnostics.Debug.WriteLine(e.Parameter);
        }

        private async void enrollButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxItem != null)
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
            else
                await new MessageDialog("Select a Semester Using the Drop Down Box", "Select a Semester").ShowAsync();
        }

        private void dropButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void swapButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void viewScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CourseSchedulePage), violet);
        }

        private void courseList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void semesterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            if (content != null)
            {
                getSemester(content);
            }
        }


        private void getSemester(string semester)
        {
            switch (semester.ToUpper())
            {
                case ("SEMESTER 1"):
                    
                    clearTextBoxes();

                    foreach (var season in violet.majorProgram.year1)
                    {
                        if(season.Key == 1)
                        {
                            foreach (var course in season.Value.courseList)
                            {
                                if(course.missing == true)
                                {
                                    if(R1C1.Text == "")
                                        R1C1.Text = course.code;
                                    else if(R2C1.Text == "")
                                        R2C1.Text = course.code;
                                    else if (R3C1.Text == "")
                                        R3C1.Text = course.code;
                                    else if (R4C1.Text == "")
                                        R4C1.Text = course.code;
                                    else if (R5C1.Text == "")
                                        R5C1.Text = course.code;
                                }
                            }
                        }
                    }
                    return;
                case ("SEMESTER 2"):
                    clearTextBoxes();

                    foreach (var season in violet.majorProgram.year1)
                    {
                        if (season.Key == 2)
                        {
                            foreach (var course in season.Value.courseList)
                            {
                                if (course.missing == true)
                                {
                                    if (R1C1.Text == "")
                                        R1C1.Text = course.code;
                                    else if (R2C1.Text == "")
                                        R2C1.Text = course.code;
                                    else if (R3C1.Text == "")
                                        R3C1.Text = course.code;
                                    else if (R4C1.Text == "")
                                        R4C1.Text = course.code;
                                    else if (R5C1.Text == "")
                                        R5C1.Text = course.code;
                                    //JUST A TEST TO SEE IF GITHUB COMMIT WORKS RIGHT
                                }
                            }
                        }
                    }
                    return;
                case ("SEMESTER 3"):
                    clearTextBoxes();

                    return;
                case ("SEMESTER 4"):
                    clearTextBoxes();

                    return;
                case ("SEMESTER 5"):
                    clearTextBoxes();

                    return;
                case ("SEMESTER 6"):
                    clearTextBoxes();

                    return;
                case ("SEMESTER 7"):
                    clearTextBoxes();

                    return;
                case ("SEMESTER 8"):
                    clearTextBoxes();

                    return;
            }
        }

        private void clearTextBoxes()
        {
            R1C1.Text = "";
            R2C1.Text = "";
            R3C1.Text = "";
            R4C1.Text = "";
            R5C1.Text = "";
            R1C2.Text = "";
            R2C2.Text = "";
            R3C2.Text = "";
            R4C2.Text = "";
            R5C2.Text = "";
            R1C3.Text = "";
            R2C3.Text = "";
            R3C3.Text = "";
            R4C3.Text = "";
            R5C3.Text = "";
        }
    }
}
