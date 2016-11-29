﻿using RAMSS_v2.UserDataSource;
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
        String content;

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
            taking1.IsEnabled = !taking1.IsEnabled;
            taking2.IsEnabled = !taking2.IsEnabled;
            taking3.IsEnabled = !taking3.IsEnabled;
            taking4.IsEnabled = !taking4.IsEnabled;
            taking5.IsEnabled = !taking5.IsEnabled;

        }

        private void viewScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CourseSchedulePage), violet);
        }

        private void courseList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedCourseToEnroll = (Course)e.ClickedItem;
            System.Diagnostics.Debug.WriteLine("selected Item: " + selectedCourseToEnroll.code);
            System.Diagnostics.Debug.WriteLine("semester: " + comboBoxItem.Content.ToString());
            if(comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 1"))
            {
                violet.enroll(1, selectedCourseToEnroll);
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                R1C2.Text = "";
                R2C2.Text = "";
                R3C2.Text = "";
                R4C2.Text = "";
                R5C2.Text = "";
                foreach (var item in violet.takingCoursesY1)
                {
                    if(R1C2.Text == "" && item.Key == 1)
                    {
                        R1C2.Text += item.Value.code;
                    }
                    else if (R2C2.Text == "" && item.Key == 1)
                    {
                        R2C2.Text += item.Value.code;
                    }
                    else if (R3C2.Text == "" && item.Key == 1)
                    {
                        R3C2.Text += item.Value.code;
                    }
                    else if (R4C2.Text == "" && item.Key == 1)
                    {
                        R4C2.Text += item.Value.code;
                    }
                    else if (R5C2.Text == "" && item.Key == 1)
                    {
                        R5C2.Text += item.Value.code;
                    }
                }
            }
            else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 2"))
            {
                violet.enroll(2, selectedCourseToEnroll);
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                R1C2.Text = "";
                R2C2.Text = "";
                R3C2.Text = "";
                R4C2.Text = "";
                R5C2.Text = "";
                foreach (var item in violet.takingCoursesY1)
                {
                    if (R1C2.Text == "" && item.Key == 2)
                    {
                        R1C2.Text += item.Value.code;
                    }
                    else if (R2C2.Text == "" && item.Key == 2)
                    {
                        R2C2.Text += item.Value.code;
                    }
                    else if (R3C2.Text == "" && item.Key == 2)
                    {
                        R3C2.Text += item.Value.code;
                    }
                    else if (R4C2.Text == "" && item.Key == 2)
                    {
                        R4C2.Text += item.Value.code;
                    }
                    else if (R5C2.Text == "" && item.Key == 2)
                    {
                        R5C2.Text += item.Value.code;
                    }
                }
            }
            else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 3"))
            {
                violet.enroll(3, selectedCourseToEnroll);
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                R1C2.Text = "";
                R2C2.Text = "";
                R3C2.Text = "";
                R4C2.Text = "";
                R5C2.Text = "";
                foreach (var item in violet.takingCoursesY2)
                {
                    if (R1C2.Text == "" && item.Key == 1)
                    {
                        R1C2.Text += item.Value.code;
                    }
                    else if (R2C2.Text == "" && item.Key == 1)
                    {
                        R2C2.Text += item.Value.code;
                    }
                    else if (R3C2.Text == "" && item.Key == 1)
                    {
                        R3C2.Text += item.Value.code;
                    }
                    else if (R4C2.Text == "" && item.Key == 1)
                    {
                        R4C2.Text += item.Value.code;
                    }
                    else if (R5C2.Text == "" && item.Key == 1)
                    {
                        R5C2.Text += item.Value.code;
                    }
                }
            }
            else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 4"))
            {
                violet.enroll(4, selectedCourseToEnroll);
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                R1C2.Text = "";
                R2C2.Text = "";
                R3C2.Text = "";
                R4C2.Text = "";
                R5C2.Text = "";
                foreach (var item in violet.takingCoursesY2)
                {
                    if (R1C2.Text == "" && item.Key == 2)
                    {
                        R1C2.Text += item.Value.code;
                    }
                    else if (R2C2.Text == "" && item.Key == 2)
                    {
                        R2C2.Text += item.Value.code;
                    }
                    else if (R3C2.Text == "" && item.Key == 2)
                    {
                        R3C2.Text += item.Value.code;
                    }
                    else if (R4C2.Text == "" && item.Key == 2)
                    {
                        R4C2.Text += item.Value.code;
                    }
                    else if (R5C2.Text == "" && item.Key == 2)
                    {
                        R5C2.Text += item.Value.code;
                    }
                }
            }
            else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 5"))
            {
                violet.enroll(5, selectedCourseToEnroll);
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                R1C2.Text = "";
                R2C2.Text = "";
                R3C2.Text = "";
                R4C2.Text = "";
                R5C2.Text = "";
                foreach (var item in violet.takingCoursesY3)
                {
                    if (R1C2.Text == "" && item.Key == 1)
                    {
                        R1C2.Text += item.Value.code;
                    }
                    else if (R2C2.Text == "" && item.Key == 1)
                    {
                        R2C2.Text += item.Value.code;
                    }
                    else if (R3C2.Text == "" && item.Key == 1)
                    {
                        R3C2.Text += item.Value.code;
                    }
                    else if (R4C2.Text == "" && item.Key == 1)
                    {
                        R4C2.Text += item.Value.code;
                    }
                    else if (R5C2.Text == "" && item.Key == 1)
                    {
                        R5C2.Text += item.Value.code;
                    }
                }
            }
            else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 6"))
            {
                violet.enroll(6, selectedCourseToEnroll);
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                R1C2.Text = "";
                R2C2.Text = "";
                R3C2.Text = "";
                R4C2.Text = "";
                R5C2.Text = "";
                foreach (var item in violet.takingCoursesY3)
                {
                    if (R1C2.Text == "" && item.Key == 2)
                    {
                        R1C2.Text += item.Value.code;
                    }
                    else if (R2C2.Text == "" && item.Key == 2)
                    {
                        R2C2.Text += item.Value.code;
                    }
                    else if (R3C2.Text == "" && item.Key == 2)
                    {
                        R3C2.Text += item.Value.code;
                    }
                    else if (R4C2.Text == "" && item.Key == 2)
                    {
                        R4C2.Text += item.Value.code;
                    }
                    else if (R5C2.Text == "" && item.Key == 2)
                    {
                        R5C2.Text += item.Value.code;
                    }
                }
            }
            else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 7"))
            {
                violet.enroll(7, selectedCourseToEnroll);
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                R1C2.Text = "";
                R2C2.Text = "";
                R3C2.Text = "";
                R4C2.Text = "";
                R5C2.Text = "";
                foreach (var item in violet.takingCoursesY4)
                {
                    if (R1C2.Text == "" && item.Key == 1)
                    {
                        R1C2.Text += item.Value.code;
                    }
                    else if (R2C2.Text == "" && item.Key == 1)
                    {
                        R2C2.Text += item.Value.code;
                    }
                    else if (R3C2.Text == "" && item.Key == 1)
                    {
                        R3C2.Text += item.Value.code;
                    }
                    else if (R4C2.Text == "" && item.Key == 1)
                    {
                        R4C2.Text += item.Value.code;
                    }
                    else if (R5C2.Text == "" && item.Key == 1)
                    {
                        R5C2.Text += item.Value.code;
                    }
                }
            }
            else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 8"))
            {
                violet.enroll(8, selectedCourseToEnroll);
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                R1C2.Text = "";
                R2C2.Text = "";
                R3C2.Text = "";
                R4C2.Text = "";
                R5C2.Text = "";
                foreach (var item in violet.takingCoursesY4)
                {
                    if (R1C2.Text == "" && item.Key == 2)
                    {
                        R1C2.Text += item.Value.code;
                    }
                    else if (R2C2.Text == "" && item.Key == 2)
                    {
                        R2C2.Text += item.Value.code;
                    }
                    else if (R3C2.Text == "" && item.Key == 2)
                    {
                        R3C2.Text += item.Value.code;
                    }
                    else if (R4C2.Text == "" && item.Key == 2)
                    {
                        R4C2.Text += item.Value.code;
                    }
                    else if (R5C2.Text == "" && item.Key == 2)
                    {
                        R5C2.Text += item.Value.code;
                    }
                }
            }
        }

        private void semesterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            content = comboBoxItem.Content as string;
            if (content != null)
            {
                getSemester(content);
            }
        }

        public void getSemester(string semester)
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
                                else if (course.taking == true)
                                {
                                    if (R1C2.Text == "")
                                        R1C2.Text = course.code;
                                    else if (R2C2.Text == "")
                                        R2C2.Text = course.code;
                                    else if (R3C2.Text == "")
                                        R3C2.Text = course.code;
                                    else if (R4C2.Text == "")
                                        R4C2.Text = course.code;
                                    else if (R5C2.Text == "")
                                        R5C2.Text = course.code;
                                }
                                else if (course.completed == true)
                                {
                                    if (R1C3.Text == "")
                                        R1C3.Text = course.code;
                                    else if (R2C3.Text == "")
                                        R2C3.Text = course.code;
                                    else if (R3C3.Text == "")
                                        R3C3.Text = course.code;
                                    else if (R4C3.Text == "")
                                        R4C3.Text = course.code;
                                    else if (R5C3.Text == "")
                                        R5C3.Text = course.code;
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
                                }
                                else if (course.taking == true)
                                {
                                    if (R1C2.Text == "")
                                        R1C2.Text = course.code;
                                    else if (R2C2.Text == "")
                                        R2C2.Text = course.code;
                                    else if (R3C2.Text == "")
                                        R3C2.Text = course.code;
                                    else if (R4C2.Text == "")
                                        R4C2.Text = course.code;
                                    else if (R5C2.Text == "")
                                        R5C2.Text = course.code;
                                }
                                else if (course.completed == true)
                                {
                                    if (R1C3.Text == "")
                                        R1C3.Text = course.code;
                                    else if (R2C3.Text == "")
                                        R2C3.Text = course.code;
                                    else if (R3C3.Text == "")
                                        R3C3.Text = course.code;
                                    else if (R4C3.Text == "")
                                        R4C3.Text = course.code;
                                    else if (R5C3.Text == "")
                                        R5C3.Text = course.code;
                                }
                            }
                        }
                    }
                    return;
                case ("SEMESTER 3"):
                    clearTextBoxes();
                    foreach (var season in violet.majorProgram.year2)
                    {
                        if (season.Key == 1)
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
                                }
                                else if (course.taking == true)
                                {
                                    if (R1C2.Text == "")
                                        R1C2.Text = course.code;
                                    else if (R2C2.Text == "")
                                        R2C2.Text = course.code;
                                    else if (R3C2.Text == "")
                                        R3C2.Text = course.code;
                                    else if (R4C2.Text == "")
                                        R4C2.Text = course.code;
                                    else if (R5C2.Text == "")
                                        R5C2.Text = course.code;
                                }
                                else if (course.completed == true)
                                {
                                    if (R1C3.Text == "")
                                        R1C3.Text = course.code;
                                    else if (R2C3.Text == "")
                                        R2C3.Text = course.code;
                                    else if (R3C3.Text == "")
                                        R3C3.Text = course.code;
                                    else if (R4C3.Text == "")
                                        R4C3.Text = course.code;
                                    else if (R5C3.Text == "")
                                        R5C3.Text = course.code;
                                }
                            }
                        }
                    }
                    return;
                case ("SEMESTER 4"):
                    clearTextBoxes();
                    foreach (var season in violet.majorProgram.year2)
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
                                }
                                else if (course.taking == true)
                                {
                                    if (R1C2.Text == "")
                                        R1C2.Text = course.code;
                                    else if (R2C2.Text == "")
                                        R2C2.Text = course.code;
                                    else if (R3C2.Text == "")
                                        R3C2.Text = course.code;
                                    else if (R4C2.Text == "")
                                        R4C2.Text = course.code;
                                    else if (R5C2.Text == "")
                                        R5C2.Text = course.code;
                                }
                                else if (course.completed == true)
                                {
                                    if (R1C3.Text == "")
                                        R1C3.Text = course.code;
                                    else if (R2C3.Text == "")
                                        R2C3.Text = course.code;
                                    else if (R3C3.Text == "")
                                        R3C3.Text = course.code;
                                    else if (R4C3.Text == "")
                                        R4C3.Text = course.code;
                                    else if (R5C3.Text == "")
                                        R5C3.Text = course.code;
                                }
                            }
                        }
                    }
                    return;
                case ("SEMESTER 5"):
                    clearTextBoxes();
                    foreach (var season in violet.majorProgram.year3)
                    {
                        if (season.Key == 1)
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
                                }
                                else if (course.taking == true)
                                {
                                    if (R1C2.Text == "")
                                        R1C2.Text = course.code;
                                    else if (R2C2.Text == "")
                                        R2C2.Text = course.code;
                                    else if (R3C2.Text == "")
                                        R3C2.Text = course.code;
                                    else if (R4C2.Text == "")
                                        R4C2.Text = course.code;
                                    else if (R5C2.Text == "")
                                        R5C2.Text = course.code;
                                }
                                else if (course.completed == true)
                                {
                                    if (R1C3.Text == "")
                                        R1C3.Text = course.code;
                                    else if (R2C3.Text == "")
                                        R2C3.Text = course.code;
                                    else if (R3C3.Text == "")
                                        R3C3.Text = course.code;
                                    else if (R4C3.Text == "")
                                        R4C3.Text = course.code;
                                    else if (R5C3.Text == "")
                                        R5C3.Text = course.code;
                                }
                            }
                        }
                    }
                    return;
                case ("SEMESTER 6"):
                    clearTextBoxes();
                    foreach (var season in violet.majorProgram.year3)
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
                                }
                                else if (course.taking == true)
                                {
                                    if (R1C2.Text == "")
                                        R1C2.Text = course.code;
                                    else if (R2C2.Text == "")
                                        R2C2.Text = course.code;
                                    else if (R3C2.Text == "")
                                        R3C2.Text = course.code;
                                    else if (R4C2.Text == "")
                                        R4C2.Text = course.code;
                                    else if (R5C2.Text == "")
                                        R5C2.Text = course.code;
                                }
                                else if (course.completed == true)
                                {
                                    if (R1C3.Text == "")
                                        R1C3.Text = course.code;
                                    else if (R2C3.Text == "")
                                        R2C3.Text = course.code;
                                    else if (R3C3.Text == "")
                                        R3C3.Text = course.code;
                                    else if (R4C3.Text == "")
                                        R4C3.Text = course.code;
                                    else if (R5C3.Text == "")
                                        R5C3.Text = course.code;
                                }
                            }
                        }
                    }
                    return;
                case ("SEMESTER 7"):
                    clearTextBoxes();
                    foreach (var season in violet.majorProgram.year4)
                    {
                        if (season.Key == 1)
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
                                }
                                else if (course.taking == true)
                                {
                                    if (R1C2.Text == "")
                                        R1C2.Text = course.code;
                                    else if (R2C2.Text == "")
                                        R2C2.Text = course.code;
                                    else if (R3C2.Text == "")
                                        R3C2.Text = course.code;
                                    else if (R4C2.Text == "")
                                        R4C2.Text = course.code;
                                    else if (R5C2.Text == "")
                                        R5C2.Text = course.code;
                                }
                                else if (course.completed == true)
                                {
                                    if (R1C3.Text == "")
                                        R1C3.Text = course.code;
                                    else if (R2C3.Text == "")
                                        R2C3.Text = course.code;
                                    else if (R3C3.Text == "")
                                        R3C3.Text = course.code;
                                    else if (R4C3.Text == "")
                                        R4C3.Text = course.code;
                                    else if (R5C3.Text == "")
                                        R5C3.Text = course.code;
                                }
                            }
                        }
                    }
                    return;
                case ("SEMESTER 8"):
                    clearTextBoxes();
                    foreach (var season in violet.majorProgram.year4)
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
                                }
                                else if (course.taking == true)
                                {
                                    if (R1C2.Text == "")
                                        R1C2.Text = course.code;
                                    else if (R2C2.Text == "")
                                        R2C2.Text = course.code;
                                    else if (R3C2.Text == "")
                                        R3C2.Text = course.code;
                                    else if (R4C2.Text == "")
                                        R4C2.Text = course.code;
                                    else if (R5C2.Text == "")
                                        R5C2.Text = course.code;
                                }
                                else if (course.completed == true)
                                {
                                    if (R1C3.Text == "")
                                        R1C3.Text = course.code;
                                    else if (R2C3.Text == "")
                                        R2C3.Text = course.code;
                                    else if (R3C3.Text == "")
                                        R3C3.Text = course.code;
                                    else if (R4C3.Text == "")
                                        R4C3.Text = course.code;
                                    else if (R5C3.Text == "")
                                        R5C3.Text = course.code;
                                }
                            }
                        }
                    }
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
