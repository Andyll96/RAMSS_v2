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

        public static User violet;
        public List<Course> fullCurriculum;
        ComboBoxItem comboBoxItem;
        String content;
        Boolean droppingCourseBool = false;
        Boolean swapingCourseBool = false;

        Course swapingCourse = new Course();


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
                await new MessageDialog("Select a Semester Using the Drop Down Box on the Top Left of the Page", "Select a Semester").ShowAsync();
        }

        private async void dropButton_Click(object sender, RoutedEventArgs e)
        {
            if (droppingCourseBool == false)
            {
                droppingCourseBool = true;
                await new MessageDialog("Select a course, from the Taking Column, to Drop", "Drop a Course").ShowAsync();

                taking1.IsEnabled = !taking1.IsEnabled;
                taking2.IsEnabled = !taking2.IsEnabled;
                taking3.IsEnabled = !taking3.IsEnabled;
                taking4.IsEnabled = !taking4.IsEnabled;
                taking5.IsEnabled = !taking5.IsEnabled;
            }
        }

        private async void swapButton_Click(object sender, RoutedEventArgs e)
        {
            if (swapingCourseBool == false)
            {
                swapingCourseBool = true;
                await new MessageDialog("Select a course, from the Taking Column, to Swap", "Swap a Course").ShowAsync();

                taking1.IsEnabled = !taking1.IsEnabled;
                taking2.IsEnabled = !taking2.IsEnabled;
                taking3.IsEnabled = !taking3.IsEnabled;
                taking4.IsEnabled = !taking4.IsEnabled;
                taking5.IsEnabled = !taking5.IsEnabled;
            }
        }

        private void viewScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CourseSchedulePage), violet);
        }

        private async void courseList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (swapingCourseBool == true)
            {
                var selectedCourseToSwap = (Course)e.ClickedItem;
                if(content.ToUpper().Equals("SEMESTER 5"))
                {
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(1, swapingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(1, swapingCourse));

                    foreach (var item in violet.completedCoursesY1)
                    {
                        if (selectedCourseToSwap.code.Equals(item.Value.code))
                        {
                            await new MessageDialog("You've already taken this course", "Course Completed").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            return;
                        }
                    }
                    foreach (var item in violet.completedCoursesY2)
                    {
                        if (selectedCourseToSwap.code.Equals(item.Value.code))
                        {
                            await new MessageDialog("You've already taken this course", "Course Completed").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            return;
                        }
                    }
                    if (selectedCourseToSwap.prerequisites.Any()) //prereq test
                    {
                        List<Course> preReqsTaken = new List<Course>();
                        List<Course> alreadyTaken = new List<Course>();

                        foreach (var course in violet.completedCoursesY1)
                        {
                            foreach (var preReq in selectedCourseToSwap.prerequisites)
                            {
                                if (course.Value.code.Equals(preReq.code))
                                {
                                    preReqsTaken.Add(course.Value);
                                }
                            }
                        }

                        foreach (var course in violet.completedCoursesY2)
                        {
                            foreach (var preReq in selectedCourseToSwap.prerequisites)
                            {
                                if (course.Value.code.Equals(preReq.code))
                                {
                                    preReqsTaken.Add(course.Value);
                                }
                            }
                        }


                        if (!preReqsTaken.Any()) //If you haven't taken the preReqs Required
                        {
                            String str = null;
                            foreach (var item in selectedCourseToSwap.prerequisites)
                            {
                                str += item.code + ", ";
                            }
                            await new MessageDialog("Make sure you have these Courses: " + str, "Not Available").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                        }
                        else
                        {
                            violet.enroll(5, selectedCourseToSwap);
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            getSemester(content);
                        }
                    }
                    else
                    {
                        violet.enroll(5, selectedCourseToSwap);
                        enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                        getSemester(content);
                    }
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    swapingCourseBool = false;
                }
                else if (content.ToUpper().Equals("SEMESTER 6"))
                {
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(2, swapingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(2, swapingCourse));

                    foreach (var item in violet.completedCoursesY1)
                    {
                        if (selectedCourseToSwap.code.Equals(item.Value.code))
                        {
                            await new MessageDialog("You've already taken this course", "Course Completed").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            return;
                        }
                    }
                    foreach (var item in violet.completedCoursesY2)
                    {
                        if (selectedCourseToSwap.code.Equals(item.Value.code))
                        {
                            await new MessageDialog("You've already taken this course", "Course Completed").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            return;
                        }
                    }
                    if (selectedCourseToSwap.prerequisites.Any())
                    {
                        List<Course> preReqsTaken = new List<Course>();

                        foreach (var course in violet.completedCoursesY1)
                        {
                            foreach (var preReq in selectedCourseToSwap.prerequisites)
                            {
                                if (course.Value.code.Equals(preReq.code))
                                {
                                    preReqsTaken.Add(course.Value);
                                }
                            }
                        }

                        foreach (var course in violet.completedCoursesY2)
                        {
                            foreach (var preReq in selectedCourseToSwap.prerequisites)
                            {
                                if (course.Value.code.Equals(preReq.code))
                                {
                                    preReqsTaken.Add(course.Value);
                                }
                            }
                        }
                        if (!preReqsTaken.Any())
                        {
                            String str = null;
                            foreach (var item in selectedCourseToSwap.prerequisites)
                            {
                                str += item.code + ", ";
                            }
                            await new MessageDialog("Make sure you have these Courses: " + str, "Not Available").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                        }
                        else
                        {
                            violet.enroll(6, selectedCourseToSwap);
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            getSemester(content);
                        }
                    }
                    else
                    {
                        violet.enroll(6, selectedCourseToSwap);
                        enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                        getSemester(content);
                    }
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    swapingCourseBool = false;
                }
            }
            else
            {
                var selectedCourseToEnroll = (Course)e.ClickedItem;

                System.Diagnostics.Debug.WriteLine("selected Item: " + selectedCourseToEnroll.code);
                System.Diagnostics.Debug.WriteLine("semester: " + comboBoxItem.Content.ToString());

                if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 1"))
                {
                    await new MessageDialog("The selected semester has already been completed, therefore courses cannot be enrolled for this semester.", "Semester Already Complete").ShowAsync();
                    //violet.enroll(1, selectedCourseToEnroll);
                    enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                    getSemester(content);
                }
                else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 2"))
                {
                    await new MessageDialog("The selected semester has already been completed, therefore courses cannot be enrolled for this semester.", "Semester Already Complete").ShowAsync();
                    //violet.enroll(2, selectedCourseToEnroll);
                    enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                    getSemester(content);

                }
                else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 3"))
                {
                    await new MessageDialog("The selected semester has already been completed, therefore courses cannot be enrolled for this semester.", "Semester Already Complete").ShowAsync();
                    //violet.enroll(3, selectedCourseToEnroll);
                    enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                    getSemester(content);

                }
                else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 4"))
                {
                    await new MessageDialog("The selected semester has already been completed, therefore courses cannot be enrolled for this semester.", "Semester Already Complete").ShowAsync();
                    //violet.enroll(4, selectedCourseToEnroll);
                    enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                    getSemester(content);

                }
                else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 5"))
                {
                    foreach (var item in violet.completedCoursesY1)
                    {
                        if (selectedCourseToEnroll.code.Equals(item.Value.code))
                        {
                            await new MessageDialog("You've already taken this course", "Course Completed").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            return;
                        }
                    }
                    foreach (var item in violet.completedCoursesY2)
                    {
                        if (selectedCourseToEnroll.code.Equals(item.Value.code))
                        {
                            await new MessageDialog("You've already taken this course", "Course Completed").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            return;
                        }
                    }
                    if (selectedCourseToEnroll.prerequisites.Any()) //prereq test
                    {
                        List<Course> preReqsTaken = new List<Course>();
                        List<Course> alreadyTaken = new List<Course>();

                        foreach (var course in violet.completedCoursesY1)
                        {
                            foreach (var preReq in selectedCourseToEnroll.prerequisites)
                            {
                                if (course.Value.code.Equals(preReq.code))
                                {
                                    preReqsTaken.Add(course.Value);
                                }
                            }
                        }

                        foreach (var course in violet.completedCoursesY2)
                        {
                            foreach (var preReq in selectedCourseToEnroll.prerequisites)
                            {
                                if (course.Value.code.Equals(preReq.code))
                                {
                                    preReqsTaken.Add(course.Value);
                                }
                            }
                        }


                        if (!preReqsTaken.Any()) //If you haven't taken the preReqs Required
                        {
                            String str = null;
                            foreach (var item in selectedCourseToEnroll.prerequisites)
                            {
                                str += item.code + ", ";
                            }
                            await new MessageDialog("Make sure you have these Courses: " + str, "Not Available").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                        }
                        else
                        {
                            violet.enroll(5, selectedCourseToEnroll);
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            getSemester(content);
                        }
                    }
                    else
                    {
                        violet.enroll(5, selectedCourseToEnroll);
                        enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                        getSemester(content);
                    }
                }
                else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 6"))
                {
                    foreach (var item in violet.completedCoursesY1)
                    {
                        if (selectedCourseToEnroll.code.Equals(item.Value.code))
                        {
                            await new MessageDialog("You've already taken this course", "Course Completed").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            return;
                        }
                    }
                    foreach (var item in violet.completedCoursesY2)
                    {
                        if (selectedCourseToEnroll.code.Equals(item.Value.code))
                        {
                            await new MessageDialog("You've already taken this course", "Course Completed").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            return;
                        }
                    }
                    if (selectedCourseToEnroll.prerequisites.Any())
                    {
                        List<Course> preReqsTaken = new List<Course>();

                        foreach (var course in violet.completedCoursesY1)
                        {
                            foreach (var preReq in selectedCourseToEnroll.prerequisites)
                            {
                                if (course.Value.code.Equals(preReq.code))
                                {
                                    preReqsTaken.Add(course.Value);
                                }
                            }
                        }

                        foreach (var course in violet.completedCoursesY2)
                        {
                            foreach (var preReq in selectedCourseToEnroll.prerequisites)
                            {
                                if (course.Value.code.Equals(preReq.code))
                                {
                                    preReqsTaken.Add(course.Value);
                                }
                            }
                        }
                        if (!preReqsTaken.Any())
                        {
                            String str = null;
                            foreach (var item in selectedCourseToEnroll.prerequisites)
                            {
                                str += item.code + ", ";
                            }
                            await new MessageDialog("Make sure you have these Courses: " + str, "Not Available").ShowAsync();
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                        }
                        else
                        {
                            violet.enroll(6, selectedCourseToEnroll);
                            enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                            getSemester(content);
                        }
                    }
                    else
                    {
                        violet.enroll(6, selectedCourseToEnroll);
                        enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                        getSemester(content);
                    }


                }
                else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 7"))
                {
                    await new MessageDialog("This Semester is not available for Enrollment", "Not Available").ShowAsync();
                    //violet.enroll(7, selectedCourseToEnroll);
                    enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                    getSemester(content);

                }
                else if (comboBoxItem.Content.ToString().ToUpper().Equals("SEMESTER 8"))
                {
                    await new MessageDialog("This Semester is not available for Enrollment", "Not Available").ShowAsync();
                    //violet.enroll(8, selectedCourseToEnroll);
                    enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
                    getSemester(content);
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
            printMissing(semester);
            printTaking(semester);
            printCompleted(semester);
        }

        private void printMissing(string semester)
        {
            switch (semester.ToUpper())
            {
                case ("SEMESTER 1"):
                    clearMissingColumn();
                    foreach (var sem in violet.missingCoursesY1)
                    {
                        if (R1C1.Text == "" && sem.Key == 1)
                        {
                            R1C1.Text += sem.Value.code;
                        }
                        else if (R2C1.Text == "" && sem.Key == 1)
                        {
                            R2C1.Text += sem.Value.code;
                        }
                        else if (R3C1.Text == "" && sem.Key == 1)
                        {
                            R3C1.Text += sem.Value.code;
                        }
                        else if (R4C1.Text == "" && sem.Key == 1)
                        {
                            R4C1.Text += sem.Value.code;
                        }
                        else if (R5C1.Text == "" && sem.Key == 1)
                        {
                            R5C1.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 2"):
                    clearMissingColumn();
                    foreach (var sem in violet.missingCoursesY1)
                    {
                        if (R1C1.Text == "" && sem.Key == 2)
                        {
                            R1C1.Text += sem.Value.code;
                        }
                        else if (R2C1.Text == "" && sem.Key == 2)
                        {
                            R2C1.Text += sem.Value.code;
                        }
                        else if (R3C1.Text == "" && sem.Key == 2)
                        {
                            R3C1.Text += sem.Value.code;
                        }
                        else if (R4C1.Text == "" && sem.Key == 2)
                        {
                            R4C1.Text += sem.Value.code;
                        }
                        else if (R5C1.Text == "" && sem.Key == 2)
                        {
                            R5C1.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 3"):
                    clearMissingColumn();
                    foreach (var sem in violet.missingCoursesY2)
                    {
                        if (R1C1.Text == "" && sem.Key == 1)
                        {
                            R1C1.Text += sem.Value.code;
                        }
                        else if (R2C1.Text == "" && sem.Key == 1)
                        {
                            R2C1.Text += sem.Value.code;
                        }
                        else if (R3C1.Text == "" && sem.Key == 1)
                        {
                            R3C1.Text += sem.Value.code;
                        }
                        else if (R4C1.Text == "" && sem.Key == 1)
                        {
                            R4C1.Text += sem.Value.code;
                        }
                        else if (R5C1.Text == "" && sem.Key == 1)
                        {
                            R5C1.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 4"):
                    clearMissingColumn();
                    foreach (var sem in violet.missingCoursesY2)
                    {
                        if (R1C1.Text == "" && sem.Key == 2)
                        {
                            R1C1.Text += sem.Value.code;
                        }
                        else if (R2C1.Text == "" && sem.Key == 2)
                        {
                            R2C1.Text += sem.Value.code;
                        }
                        else if (R3C1.Text == "" && sem.Key == 2)
                        {
                            R3C1.Text += sem.Value.code;
                        }
                        else if (R4C1.Text == "" && sem.Key == 2)
                        {
                            R4C1.Text += sem.Value.code;
                        }
                        else if (R5C1.Text == "" && sem.Key == 2)
                        {
                            R5C1.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 5"):
                    clearMissingColumn();
                    foreach (var sem in violet.missingCoursesY3)
                    {
                        if (R1C1.Text == "" && sem.Key == 1)
                        {
                            R1C1.Text += sem.Value.code;
                        }
                        else if (R2C1.Text == "" && sem.Key == 1)
                        {
                            R2C1.Text += sem.Value.code;
                        }
                        else if (R3C1.Text == "" && sem.Key == 1)
                        {
                            R3C1.Text += sem.Value.code;
                        }
                        else if (R4C1.Text == "" && sem.Key == 1)
                        {
                            R4C1.Text += sem.Value.code;
                        }
                        else if (R5C1.Text == "" && sem.Key == 1)
                        {
                            R5C1.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 6"):
                    clearMissingColumn();
                    foreach (var sem in violet.missingCoursesY3)
                    {
                        if (R1C1.Text == "" && sem.Key == 2)
                        {
                            R1C1.Text += sem.Value.code;
                        }
                        else if (R2C1.Text == "" && sem.Key == 2)
                        {
                            R2C1.Text += sem.Value.code;
                        }
                        else if (R3C1.Text == "" && sem.Key == 2)
                        {
                            R3C1.Text += sem.Value.code;
                        }
                        else if (R4C1.Text == "" && sem.Key == 2)
                        {
                            R4C1.Text += sem.Value.code;
                        }
                        else if (R5C1.Text == "" && sem.Key == 2)
                        {
                            R5C1.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 7"):
                    clearMissingColumn();
                    foreach (var sem in violet.missingCoursesY4)
                    {
                        if (R1C1.Text == "" && sem.Key == 1)
                        {
                            R1C1.Text += sem.Value.code;
                        }
                        else if (R2C1.Text == "" && sem.Key == 1)
                        {
                            R2C1.Text += sem.Value.code;
                        }
                        else if (R3C1.Text == "" && sem.Key == 1)
                        {
                            R3C1.Text += sem.Value.code;
                        }
                        else if (R4C1.Text == "" && sem.Key == 1)
                        {
                            R4C1.Text += sem.Value.code;
                        }
                        else if (R5C1.Text == "" && sem.Key == 1)
                        {
                            R5C1.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 8"):
                    clearMissingColumn();
                    foreach (var sem in violet.missingCoursesY4)
                    {
                        if (R1C1.Text == "" && sem.Key == 2)
                        {
                            R1C1.Text += sem.Value.code;
                        }
                        else if (R2C1.Text == "" && sem.Key == 2)
                        {
                            R2C1.Text += sem.Value.code;
                        }
                        else if (R3C1.Text == "" && sem.Key == 2)
                        {
                            R3C1.Text += sem.Value.code;
                        }
                        else if (R4C1.Text == "" && sem.Key == 2)
                        {
                            R4C1.Text += sem.Value.code;
                        }
                        else if (R5C1.Text == "" && sem.Key == 2)
                        {
                            R5C1.Text += sem.Value.code;
                        }
                    }
                    break;
            }
        }

        private void printTaking(string semester)
        {
            switch (semester.ToUpper())
            {
                case ("SEMESTER 1"):
                    clearTakingColumn();
                    foreach (var sem in violet.takingCoursesY1)
                    {
                        if (R1C2.Text == "" && sem.Key == 1)
                        {
                            R1C2.Text += sem.Value.code;
                        }
                        else if (R2C2.Text == "" && sem.Key == 1)
                        {
                            R2C2.Text += sem.Value.code;
                        }
                        else if (R3C2.Text == "" && sem.Key == 1)
                        {
                            R3C2.Text += sem.Value.code;
                        }
                        else if (R4C2.Text == "" && sem.Key == 1)
                        {
                            R4C2.Text += sem.Value.code;
                        }
                        else if (R5C2.Text == "" && sem.Key == 1)
                        {
                            R5C2.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 2"):
                    clearTakingColumn();
                    foreach (var sem in violet.takingCoursesY1)
                    {
                        if (R1C2.Text == "" && sem.Key == 2)
                        {
                            R1C2.Text += sem.Value.code;
                        }
                        else if (R2C2.Text == "" && sem.Key == 2)
                        {
                            R2C2.Text += sem.Value.code;
                        }
                        else if (R3C2.Text == "" && sem.Key == 2)
                        {
                            R3C2.Text += sem.Value.code;
                        }
                        else if (R4C2.Text == "" && sem.Key == 2)
                        {
                            R4C2.Text += sem.Value.code;
                        }
                        else if (R5C2.Text == "" && sem.Key == 2)
                        {
                            R5C2.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 3"):
                    clearTakingColumn();
                    foreach (var sem in violet.takingCoursesY2)
                    {
                        if (R1C2.Text == "" && sem.Key == 1)
                        {
                            R1C2.Text += sem.Value.code;
                        }
                        else if (R2C2.Text == "" && sem.Key == 1)
                        {
                            R2C2.Text += sem.Value.code;
                        }
                        else if (R3C2.Text == "" && sem.Key == 1)
                        {
                            R3C2.Text += sem.Value.code;
                        }
                        else if (R4C2.Text == "" && sem.Key == 1)
                        {
                            R4C2.Text += sem.Value.code;
                        }
                        else if (R5C2.Text == "" && sem.Key == 1)
                        {
                            R5C2.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 4"):
                    clearTakingColumn();
                    foreach (var sem in violet.takingCoursesY2)
                    {
                        if (R1C2.Text == "" && sem.Key == 2)
                        {
                            R1C2.Text += sem.Value.code;
                        }
                        else if (R2C2.Text == "" && sem.Key == 2)
                        {
                            R2C2.Text += sem.Value.code;
                        }
                        else if (R3C2.Text == "" && sem.Key == 2)
                        {
                            R3C2.Text += sem.Value.code;
                        }
                        else if (R4C2.Text == "" && sem.Key == 2)
                        {
                            R4C2.Text += sem.Value.code;
                        }
                        else if (R5C2.Text == "" && sem.Key == 2)
                        {
                            R5C2.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 5"):
                    clearTakingColumn();
                    foreach (var sem in violet.takingCoursesY3)
                    {
                        if (R1C2.Text == "" && sem.Key == 1)
                        {
                            R1C2.Text += sem.Value.code;
                        }
                        else if (R2C2.Text == "" && sem.Key == 1)
                        {
                            R2C2.Text += sem.Value.code;
                        }
                        else if (R3C2.Text == "" && sem.Key == 1)
                        {
                            R3C2.Text += sem.Value.code;
                        }
                        else if (R4C2.Text == "" && sem.Key == 1)
                        {
                            R4C2.Text += sem.Value.code;
                        }
                        else if (R5C2.Text == "" && sem.Key == 1)
                        {
                            R5C2.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 6"):
                    clearTakingColumn();
                    foreach (var sem in violet.takingCoursesY3)
                    {
                        if (R1C2.Text == "" && sem.Key == 2)
                        {
                            R1C2.Text += sem.Value.code;
                        }
                        else if (R2C2.Text == "" && sem.Key == 2)
                        {
                            R2C2.Text += sem.Value.code;
                        }
                        else if (R3C2.Text == "" && sem.Key == 2)
                        {
                            R3C2.Text += sem.Value.code;
                        }
                        else if (R4C2.Text == "" && sem.Key == 2)
                        {
                            R4C2.Text += sem.Value.code;
                        }
                        else if (R5C2.Text == "" && sem.Key == 2)
                        {
                            R5C2.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 7"):
                    clearTakingColumn();
                    foreach (var sem in violet.takingCoursesY4)
                    {
                        if (R1C2.Text == "" && sem.Key == 1)
                        {
                            R1C2.Text += sem.Value.code;
                        }
                        else if (R2C2.Text == "" && sem.Key == 1)
                        {
                            R2C2.Text += sem.Value.code;
                        }
                        else if (R3C2.Text == "" && sem.Key == 1)
                        {
                            R3C2.Text += sem.Value.code;
                        }
                        else if (R4C2.Text == "" && sem.Key == 1)
                        {
                            R4C2.Text += sem.Value.code;
                        }
                        else if (R5C2.Text == "" && sem.Key == 1)
                        {
                            R5C2.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 8"):
                    clearTakingColumn();
                    foreach (var sem in violet.takingCoursesY4)
                    {
                        if (R1C2.Text == "" && sem.Key == 2)
                        {
                            R1C2.Text += sem.Value.code;
                        }
                        else if (R2C2.Text == "" && sem.Key == 2)
                        {
                            R2C2.Text += sem.Value.code;
                        }
                        else if (R3C2.Text == "" && sem.Key == 2)
                        {
                            R3C2.Text += sem.Value.code;
                        }
                        else if (R4C2.Text == "" && sem.Key == 2)
                        {
                            R4C2.Text += sem.Value.code;
                        }
                        else if (R5C2.Text == "" && sem.Key == 2)
                        {
                            R5C2.Text += sem.Value.code;
                        }
                    }
                    break;
            }
        }

        private void printCompleted(string semester)
        {
            switch (semester.ToUpper())
            {
                case ("SEMESTER 1"):
                    clearCompletedColumn();
                    foreach (var sem in violet.completedCoursesY1)
                    {
                        if (R1C3.Text == "" && sem.Key == 1)
                        {
                            R1C3.Text += sem.Value.code;
                        }
                        else if (R2C3.Text == "" && sem.Key == 1)
                        {
                            R2C3.Text += sem.Value.code;
                        }
                        else if (R3C3.Text == "" && sem.Key == 1)
                        {
                            R3C3.Text += sem.Value.code;
                        }
                        else if (R4C3.Text == "" && sem.Key == 1)
                        {
                            R4C3.Text += sem.Value.code;
                        }
                        else if (R5C3.Text == "" && sem.Key == 1)
                        {
                            R5C3.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 2"):
                    clearCompletedColumn();
                    foreach (var sem in violet.completedCoursesY1)
                    {
                        if (R1C3.Text == "" && sem.Key == 2)
                        {
                            R1C3.Text += sem.Value.code;
                        }
                        else if (R2C3.Text == "" && sem.Key == 2)
                        {
                            R2C3.Text += sem.Value.code;
                        }
                        else if (R3C3.Text == "" && sem.Key == 2)
                        {
                            R3C3.Text += sem.Value.code;
                        }
                        else if (R4C3.Text == "" && sem.Key == 2)
                        {
                            R4C3.Text += sem.Value.code;
                        }
                        else if (R5C3.Text == "" && sem.Key == 2)
                        {
                            R5C3.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 3"):
                    clearCompletedColumn();
                    foreach (var sem in violet.completedCoursesY2)
                    {
                        if (R1C3.Text == "" && sem.Key == 1)
                        {
                            R1C3.Text += sem.Value.code;
                        }
                        else if (R2C3.Text == "" && sem.Key == 1)
                        {
                            R2C3.Text += sem.Value.code;
                        }
                        else if (R3C3.Text == "" && sem.Key == 1)
                        {
                            R3C3.Text += sem.Value.code;
                        }
                        else if (R4C3.Text == "" && sem.Key == 1)
                        {
                            R4C3.Text += sem.Value.code;
                        }
                        else if (R5C3.Text == "" && sem.Key == 1)
                        {
                            R5C3.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 4"):
                    clearCompletedColumn();
                    foreach (var sem in violet.completedCoursesY2)
                    {
                        if (R1C3.Text == "" && sem.Key == 2)
                        {
                            R1C3.Text += sem.Value.code;
                        }
                        else if (R2C3.Text == "" && sem.Key == 2)
                        {
                            R2C3.Text += sem.Value.code;
                        }
                        else if (R3C3.Text == "" && sem.Key == 2)
                        {
                            R3C3.Text += sem.Value.code;
                        }
                        else if (R4C3.Text == "" && sem.Key == 2)
                        {
                            R4C3.Text += sem.Value.code;
                        }
                        else if (R5C3.Text == "" && sem.Key == 2)
                        {
                            R5C3.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 5"):
                    clearCompletedColumn();
                    foreach (var sem in violet.completedCoursesY3)
                    {
                        if (R1C3.Text == "" && sem.Key == 1)
                        {
                            R1C3.Text += sem.Value.code;
                        }
                        else if (R2C3.Text == "" && sem.Key == 1)
                        {
                            R2C3.Text += sem.Value.code;
                        }
                        else if (R3C3.Text == "" && sem.Key == 1)
                        {
                            R3C3.Text += sem.Value.code;
                        }
                        else if (R4C3.Text == "" && sem.Key == 1)
                        {
                            R4C3.Text += sem.Value.code;
                        }
                        else if (R5C3.Text == "" && sem.Key == 1)
                        {
                            R5C3.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 6"):
                    clearCompletedColumn();
                    foreach (var sem in violet.completedCoursesY3)
                    {
                        if (R1C3.Text == "" && sem.Key == 2)
                        {
                            R1C3.Text += sem.Value.code;
                        }
                        else if (R2C3.Text == "" && sem.Key == 2)
                        {
                            R2C3.Text += sem.Value.code;
                        }
                        else if (R3C3.Text == "" && sem.Key == 2)
                        {
                            R3C3.Text += sem.Value.code;
                        }
                        else if (R4C3.Text == "" && sem.Key == 2)
                        {
                            R4C3.Text += sem.Value.code;
                        }
                        else if (R5C3.Text == "" && sem.Key == 2)
                        {
                            R5C3.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 7"):
                    clearCompletedColumn();
                    foreach (var sem in violet.completedCoursesY4)
                    {
                        if (R1C3.Text == "" && sem.Key == 1)
                        {
                            R1C3.Text += sem.Value.code;
                        }
                        else if (R2C3.Text == "" && sem.Key == 1)
                        {
                            R2C3.Text += sem.Value.code;
                        }
                        else if (R3C3.Text == "" && sem.Key == 1)
                        {
                            R3C3.Text += sem.Value.code;
                        }
                        else if (R4C3.Text == "" && sem.Key == 1)
                        {
                            R4C3.Text += sem.Value.code;
                        }
                        else if (R5C3.Text == "" && sem.Key == 1)
                        {
                            R5C3.Text += sem.Value.code;
                        }
                    }
                    break;
                case ("SEMESTER 8"):
                    clearCompletedColumn();
                    foreach (var sem in violet.completedCoursesY4)
                    {
                        if (R1C3.Text == "" && sem.Key == 2)
                        {
                            R1C3.Text += sem.Value.code;
                        }
                        else if (R2C3.Text == "" && sem.Key == 2)
                        {
                            R2C3.Text += sem.Value.code;
                        }
                        else if (R3C3.Text == "" && sem.Key == 2)
                        {
                            R3C3.Text += sem.Value.code;
                        }
                        else if (R4C3.Text == "" && sem.Key == 2)
                        {
                            R4C3.Text += sem.Value.code;
                        }
                        else if (R5C3.Text == "" && sem.Key == 2)
                        {
                            R5C3.Text += sem.Value.code;
                        }
                    }
                    break;
            }
        }

        private void clearMissingColumn()
        {
            R1C1.Text = "";
            R2C1.Text = "";
            R3C1.Text = "";
            R4C1.Text = "";
            R5C1.Text = "";
        }

        private void clearTakingColumn()
        {
            R1C2.Text = "";
            R2C2.Text = "";
            R3C2.Text = "";
            R4C2.Text = "";
            R5C2.Text = "";
        }

        private void clearCompletedColumn()
        {
            R1C3.Text = "";
            R2C3.Text = "";
            R3C3.Text = "";
            R4C3.Text = "";
            R5C3.Text = "";
        }

        private async void taking1_Click(object sender, RoutedEventArgs e)
        {
            if (droppingCourseBool == true)
            {
                String droppingCode = R1C2.Text;
                Course droppingCourse = new Course();
                foreach (var match in violet.majorProgram.curriculum)
                {
                    if (match.code.Equals(droppingCode))
                    {
                        droppingCourse = match;
                    }
                }
                if (content.ToUpper().Equals("SEMESTER 5"))
                {
                    System.Diagnostics.Debug.WriteLine("Found match: " + droppingCourse.code);
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(1, droppingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(1, droppingCourse));
                    getSemester("SEMESTER 5");
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    await new MessageDialog("Course has been dropped", "Dropped").ShowAsync();
                    droppingCourseBool = false;
                }
                else if (content.ToUpper().Equals("SEMESTER 6"))
                {
                    System.Diagnostics.Debug.WriteLine("Found match: " + droppingCourse.code);
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(2, droppingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(2, droppingCourse));
                    getSemester("SEMESTER 6");
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    await new MessageDialog("Course has been dropped", "Dropped").ShowAsync();
                    droppingCourseBool = false;
                }
            }
            else if (swapingCourseBool == true)
            {
                String swapingCode = R1C2.Text;
                foreach (var match in violet.majorProgram.curriculum)
                {
                    if (match.code.Equals(swapingCode))
                    {
                        swapingCourse = match;
                    }
                }
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
            }
        }

        private async void taking2_Click(object sender, RoutedEventArgs e)
        {
            if (droppingCourseBool == true)
            {
                String droppingCode = R2C2.Text;
                Course droppingCourse = new Course();
                foreach (var match in violet.majorProgram.curriculum)
                {
                    if (match.code.Equals(droppingCode))
                    {
                        droppingCourse = match;
                    }
                }
                if (content.ToUpper().Equals("SEMESTER 5"))
                {
                    System.Diagnostics.Debug.WriteLine("Found match: " + droppingCourse.code);
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(1, droppingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(1, droppingCourse));
                    getSemester("SEMESTER 5");
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    await new MessageDialog("Course has been dropped", "Dropped").ShowAsync();
                    droppingCourseBool = false;
                }
                else if (content.ToUpper().Equals("SEMESTER 6"))
                {
                    System.Diagnostics.Debug.WriteLine("Found match: " + droppingCourse.code);
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(2, droppingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(2, droppingCourse));
                    getSemester("SEMESTER 6");
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    await new MessageDialog("Course has been dropped", "Dropped").ShowAsync();
                    droppingCourseBool = false;
                }
            }
            else if (swapingCourseBool == true)
            {
                String swapingCode = R2C2.Text;
                foreach (var match in violet.majorProgram.curriculum)
                {
                    if (match.code.Equals(swapingCode))
                    {
                        swapingCourse = match;
                    }
                }
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
            }
        }

        private async void taking3_Click(object sender, RoutedEventArgs e)
        {
            if (droppingCourseBool == true)
            {
                String droppingCode = R3C2.Text;
                Course droppingCourse = new Course();
                foreach (var match in violet.majorProgram.curriculum)
                {
                    if (match.code.Equals(droppingCode))
                    {
                        droppingCourse = match;
                    }
                }
                if (content.ToUpper().Equals("SEMESTER 5"))
                {
                    System.Diagnostics.Debug.WriteLine("Found match: " + droppingCourse.code);
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(1, droppingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(1, droppingCourse));
                    getSemester("SEMESTER 5");
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    await new MessageDialog("Course has been dropped", "Dropped").ShowAsync();
                    droppingCourseBool = false;
                }
                else if (content.ToUpper().Equals("SEMESTER 6"))
                {
                    System.Diagnostics.Debug.WriteLine("Found match: " + droppingCourse.code);
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(2, droppingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(2, droppingCourse));
                    getSemester("SEMESTER 6");
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    await new MessageDialog("Course has been dropped", "Dropped").ShowAsync();
                    droppingCourseBool = false;
                }
            }
            else if (swapingCourseBool == true)
            {
                String swapingCode = R3C2.Text;
                foreach (var match in violet.majorProgram.curriculum)
                {
                    if (match.code.Equals(swapingCode))
                    {
                        swapingCourse = match;
                    }
                }
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
            }
        }

        private async void taking4_Click(object sender, RoutedEventArgs e)
        {
            if (droppingCourseBool == true)
            {
                String droppingCode = R4C2.Text;
                Course droppingCourse = new Course();
                foreach (var match in violet.majorProgram.curriculum)
                {
                    if (match.code.Equals(droppingCode))
                    {
                        droppingCourse = match;
                    }
                }
                if (content.ToUpper().Equals("SEMESTER 5"))
                {
                    System.Diagnostics.Debug.WriteLine("Found match: " + droppingCourse.code);
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(1, droppingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(1, droppingCourse));
                    getSemester("SEMESTER 5");
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    await new MessageDialog("Course has been dropped", "Dropped").ShowAsync();
                    droppingCourseBool = false;
                }
                else if (content.ToUpper().Equals("SEMESTER 6"))
                {
                    System.Diagnostics.Debug.WriteLine("Found match: " + droppingCourse.code);
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(2, droppingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(2, droppingCourse));
                    getSemester("SEMESTER 6");
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    await new MessageDialog("Course has been dropped", "Dropped").ShowAsync();
                    droppingCourseBool = false;
                }
            }
            else if (swapingCourseBool == true)
            {
                String swapingCode = R4C2.Text;
                foreach (var match in violet.majorProgram.curriculum)
                {
                    if (match.code.Equals(swapingCode))
                    {
                        swapingCourse = match;
                    }
                }
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
            }
        }

        private async void taking5_Click(object sender, RoutedEventArgs e)
        {
            if (droppingCourseBool == true)
            {
                String droppingCode = R5C2.Text;
                Course droppingCourse = new Course();
                foreach (var match in violet.majorProgram.curriculum)
                {
                    if (match.code.Equals(droppingCode))
                    {
                        droppingCourse = match;
                    }
                }
                if (content.ToUpper().Equals("SEMESTER 5"))
                {
                    System.Diagnostics.Debug.WriteLine("Found match: " + droppingCourse.code);
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(1, droppingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(1, droppingCourse));
                    getSemester("SEMESTER 5");
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    await new MessageDialog("Course has been dropped", "Dropped").ShowAsync();
                    droppingCourseBool = false;
                }
                else if (content.ToUpper().Equals("SEMESTER 6"))
                {
                    System.Diagnostics.Debug.WriteLine("Found match: " + droppingCourse.code);
                    violet.takingCoursesY3.Remove(new KeyValuePair<int, Course>(2, droppingCourse));
                    violet.missingCoursesY3.Add(new KeyValuePair<int, Course>(2, droppingCourse));
                    getSemester("SEMESTER 6");
                    taking1.IsEnabled = !taking1.IsEnabled;
                    taking2.IsEnabled = !taking2.IsEnabled;
                    taking3.IsEnabled = !taking3.IsEnabled;
                    taking4.IsEnabled = !taking4.IsEnabled;
                    taking5.IsEnabled = !taking5.IsEnabled;
                    await new MessageDialog("Course has been dropped", "Dropped").ShowAsync();
                    droppingCourseBool = false;
                }
            }
            else if (swapingCourseBool == true)
            {
                String swapingCode = R5C2.Text;
                foreach (var match in violet.majorProgram.curriculum)
                {
                    if (match.code.Equals(swapingCode))
                    {
                        swapingCourse = match;
                    }
                }
                enrollmentView.IsPaneOpen = !enrollmentView.IsPaneOpen;
            }
        }
    }
}
