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
    public sealed partial class MyGradesPage : Page
    {
        Double class1Grade;
        Double class2Grade;
        Double class3Grade;
        Double class4Grade;
        Double class5Grade;
        Double totalTemp = 0;
        Double counter = 0;

        public static User violet;

        public MyGradesPage()
        {
            this.InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            violet = (User)e.Parameter;
            
        }

        private double getGrade(String grade)
        {
            switch (grade)
            {
                case ("A+"):
                    counter++;
                    return 4.33;
                case ("A"):
                    counter++;
                    return 4;
                case ("A-"):
                    counter++;
                    return 3.67;
                case ("B+"):
                    counter++;
                    return 3.33;
                case ("B"):
                    counter++;
                    return 3.00;
                case ("B-"):
                    counter++;
                    return 2.67;
                case ("C+"):
                    counter++;
                    return 2.33;
                case ("C"):
                    counter++;
                    return 2.00;
                case ("C-"):
                    counter++;
                    return 1.67;
                case ("D+"):
                    counter++;
                    return 1.33;
                case ("D"):
                    counter++;
                    return 1.00;
                case ("D-"):
                    counter++;
                    return 0.67;
                case ("F"):
                    counter++;
                    return 0;
                case (""):
                    counter--;
                    return 0;
                default:
                    counter = 0;
                    return -1;
            }
        }

        private double getGrade2(String grade, ref int leCounter)
        {
            switch (grade)
            {
                case ("A+"):
                    leCounter++;
                    return 4.33;
                case ("A"):
                    leCounter++;
                    return 4;
                case ("A-"):
                    leCounter++;
                    return 3.67;
                case ("B+"):
                    leCounter++;
                    return 3.33;
                case ("B"):
                    leCounter++;
                    return 3.00;
                case ("B-"):
                    leCounter++;
                    return 2.67;
                case ("C+"):
                    leCounter++;
                    return 2.33;
                case ("C"):
                    leCounter++;
                    return 2.00;
                case ("C-"):
                    leCounter++;
                    return 1.67;
                case ("D+"):
                    leCounter++;
                    return 1.33;
                case ("D"):
                    leCounter++;
                    return 1.00;
                case ("D-"):
                    leCounter++;
                    return 0.67;
                case ("F"):
                    leCounter++;
                    return 0;
                case (""):
                    leCounter--;
                    return 0;
                default:
                    leCounter = 0;
                    return -1;
            }
        }

        private void recalculateGrade()
        {
            System.Diagnostics.Debug.WriteLine("Class 1:" + class1Grade);
            System.Diagnostics.Debug.WriteLine("Class 2:" + class2Grade);
            System.Diagnostics.Debug.WriteLine("Class 3:" + class3Grade);
            System.Diagnostics.Debug.WriteLine("Class 4:" + class4Grade);
            System.Diagnostics.Debug.WriteLine("Class 5:" + class5Grade);
            totalTemp = class1Grade + class2Grade + class3Grade + class4Grade + class5Grade;
            System.Diagnostics.Debug.WriteLine("totalTemp:" + totalTemp);
            System.Diagnostics.Debug.WriteLine("counter" + counter);
            projectedGPATextBlock.Text = "Projected GPA:            " + Math.Round((totalTemp / counter),2);

        }

        private void class1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            if (content != null)
            {
                class1Grade = getGrade(content);
                recalculateGrade();
            }
            else if(content == null)
            {
                class1Grade = 0;
            }
        }

        private void class2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            if (content != null)
            {
                class2Grade = getGrade(content);
                recalculateGrade();
            }
            else
            {
                class1Grade = 0;
            }
        }

        private void class3ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            if (content != null)
            {
                class3Grade = getGrade(content);
                recalculateGrade();
            }
            else
            {
                class1Grade = 0;
            }
        }

        private void class4ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            if (content != null)
            {
                class4Grade = getGrade(content);
                recalculateGrade();
            }
            else
            {
                class1Grade = 0;
            }
        }

        private void class5ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            if (content != null)
            {
                class5Grade = getGrade(content);
                recalculateGrade();
            }
            else
            {
                class1Grade = 0;
            }
        }

        private void semesterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            if(content != null)
            {
                System.Diagnostics.Debug.WriteLine(content);

                if (content.ToUpper().Equals("SEMESTER 1"))
                {
                    clearBoard();
                    int numClasses = 0;
                    double totalGrade = 0;
                    foreach (var course in violet.completedCoursesY1)
                    {
                        if (course.Key == 1)
                        {
                            totalGrade += getGrade2(course.Value.grade, ref numClasses);
                            
                            if (R1C1.Text == "" && R1C2.Text == "" && R1C3.Text == "" && R1C4.Text == "")
                            {
                                R1C1.Text = course.Value.code;
                                R1C2.Text = course.Value.description;
                                R1C3.Text = course.Value.unit.ToString();
                                R1C4.Text = course.Value.grade;
                            }
                            else if (R2C1.Text == "" && R2C2.Text == "" && R2C3.Text == "" && R2C4.Text == "")
                            {
                                R2C1.Text = course.Value.code;
                                R2C2.Text = course.Value.description;
                                R2C3.Text = course.Value.unit.ToString();
                                R2C4.Text = course.Value.grade;
                            }
                            else if (R3C1.Text == "" && R3C2.Text == "" && R3C3.Text == "" && R3C4.Text == "")
                            {
                                R3C1.Text = course.Value.code;
                                R3C2.Text = course.Value.description;
                                R3C3.Text = course.Value.unit.ToString();
                                R3C4.Text = course.Value.grade;
                            }
                            else if (R4C1.Text == "" && R4C2.Text == "" && R4C3.Text == "" && R4C4.Text == "")
                            {
                                R4C1.Text = course.Value.code;
                                R4C2.Text = course.Value.description;
                                R4C3.Text = course.Value.unit.ToString();
                                R4C4.Text = course.Value.grade;
                            }
                            else if (R5C1.Text == "" && R5C2.Text == "" && R5C3.Text == "" && R5C4.Text == "")
                            {
                                R5C1.Text = course.Value.code;
                                R5C2.Text = course.Value.description;
                                R5C3.Text = course.Value.unit.ToString();
                                R5C4.Text = course.Value.grade;
                            }
                        }
                    }
                    GPATextBlock.Text = "GPA:            " + Math.Round((totalGrade / numClasses), 2);
                    if (Math.Round((totalGrade / numClasses), 2) >= 1.67)
                        statusTextBlock.Text = "Probationary Status: Clear";
                    else if (Double.IsNaN(Math.Round((totalGrade / numClasses), 2)))
                        statusTextBlock.Text = "Probationary Status: ";
                    else
                        statusTextBlock.Text = "Probationary Status: Probation";
                }
                else if (content.ToUpper().Equals("SEMESTER 2"))
                {
                    clearBoard();
                    int numClasses = 0;
                    double totalGrade = 0;
                    foreach (var course in violet.completedCoursesY1)
                    {
                        if (course.Key == 2)
                        {
                            totalGrade += getGrade2(course.Value.grade, ref numClasses);

                            if (R1C1.Text == "" && R1C2.Text == "" && R1C3.Text == "" && R1C4.Text == "")
                            {
                                R1C1.Text = course.Value.code;
                                R1C2.Text = course.Value.description;
                                R1C3.Text = course.Value.unit.ToString();
                                R1C4.Text = course.Value.grade;
                            }
                            else if (R2C1.Text == "" && R2C2.Text == "" && R2C3.Text == "" && R2C4.Text == "")
                            {
                                R2C1.Text = course.Value.code;
                                R2C2.Text = course.Value.description;
                                R2C3.Text = course.Value.unit.ToString();
                                R2C4.Text = course.Value.grade;
                            }
                            else if (R3C1.Text == "" && R3C2.Text == "" && R3C3.Text == "" && R3C4.Text == "")
                            {
                                R3C1.Text = course.Value.code;
                                R3C2.Text = course.Value.description;
                                R3C3.Text = course.Value.unit.ToString();
                                R3C4.Text = course.Value.grade;
                            }
                            else if (R4C1.Text == "" && R4C2.Text == "" && R4C3.Text == "" && R4C4.Text == "")
                            {
                                R4C1.Text = course.Value.code;
                                R4C2.Text = course.Value.description;
                                R4C3.Text = course.Value.unit.ToString();
                                R4C4.Text = course.Value.grade;
                            }
                            else if (R5C1.Text == "" && R5C2.Text == "" && R5C3.Text == "" && R5C4.Text == "")
                            {
                                R5C1.Text = course.Value.code;
                                R5C2.Text = course.Value.description;
                                R5C3.Text = course.Value.unit.ToString();
                                R5C4.Text = course.Value.grade;
                            }
                        }
                    }
                    GPATextBlock.Text = "GPA:            " + Math.Round((totalGrade / numClasses), 2);
                    if (Math.Round((totalGrade / numClasses), 2) >= 1.67)
                        statusTextBlock.Text = "Probationary Status: Clear";
                    else if (Double.IsNaN(Math.Round((totalGrade / numClasses), 2)))
                        statusTextBlock.Text = "Probationary Status: ";
                    else
                        statusTextBlock.Text = "Probationary Status: Probation";
                }
                else if (content.ToUpper().Equals("SEMESTER 3"))
                {
                    clearBoard();
                    int numClasses = 0;
                    double totalGrade = 0;
                    foreach (var course in violet.completedCoursesY2)
                    {
                        if (course.Key == 1)
                        {
                            totalGrade += getGrade2(course.Value.grade, ref numClasses);

                            if (R1C1.Text == "" && R1C2.Text == "" && R1C3.Text == "" && R1C4.Text == "")
                            {
                                R1C1.Text = course.Value.code;
                                R1C2.Text = course.Value.description;
                                R1C3.Text = course.Value.unit.ToString();
                                R1C4.Text = course.Value.grade;
                            }
                            else if (R2C1.Text == "" && R2C2.Text == "" && R2C3.Text == "" && R2C4.Text == "")
                            {
                                R2C1.Text = course.Value.code;
                                R2C2.Text = course.Value.description;
                                R2C3.Text = course.Value.unit.ToString();
                                R2C4.Text = course.Value.grade;
                            }
                            else if (R3C1.Text == "" && R3C2.Text == "" && R3C3.Text == "" && R3C4.Text == "")
                            {
                                R3C1.Text = course.Value.code;
                                R3C2.Text = course.Value.description;
                                R3C3.Text = course.Value.unit.ToString();
                                R3C4.Text = course.Value.grade;
                            }
                            else if (R4C1.Text == "" && R4C2.Text == "" && R4C3.Text == "" && R4C4.Text == "")
                            {
                                R4C1.Text = course.Value.code;
                                R4C2.Text = course.Value.description;
                                R4C3.Text = course.Value.unit.ToString();
                                R4C4.Text = course.Value.grade;
                            }
                            else if (R5C1.Text == "" && R5C2.Text == "" && R5C3.Text == "" && R5C4.Text == "")
                            {
                                R5C1.Text = course.Value.code;
                                R5C2.Text = course.Value.description;
                                R5C3.Text = course.Value.unit.ToString();
                                R5C4.Text = course.Value.grade;
                            }
                        }
                    }
                    GPATextBlock.Text = "GPA:            " + Math.Round((totalGrade / numClasses), 2);
                    if (Math.Round((totalGrade / numClasses), 2) >= 1.67)
                        statusTextBlock.Text = "Probationary Status: Clear";
                    else if (Double.IsNaN(Math.Round((totalGrade / numClasses), 2)))
                        statusTextBlock.Text = "Probationary Status: ";
                    else
                        statusTextBlock.Text = "Probationary Status: Probation";
                }
                else if (content.ToUpper().Equals("SEMESTER 4"))
                {
                    clearBoard();
                    int numClasses = 0;
                    double totalGrade = 0;
                    foreach (var course in violet.completedCoursesY2)
                    {
                        if (course.Key == 2)
                        {
                            totalGrade += getGrade2(course.Value.grade, ref numClasses);

                            if (R1C1.Text == "" && R1C2.Text == "" && R1C3.Text == "" && R1C4.Text == "")
                            {
                                R1C1.Text = course.Value.code;
                                R1C2.Text = course.Value.description;
                                R1C3.Text = course.Value.unit.ToString();
                                R1C4.Text = course.Value.grade;
                            }
                            else if (R2C1.Text == "" && R2C2.Text == "" && R2C3.Text == "" && R2C4.Text == "")
                            {
                                R2C1.Text = course.Value.code;
                                R2C2.Text = course.Value.description;
                                R2C3.Text = course.Value.unit.ToString();
                                R2C4.Text = course.Value.grade;
                            }
                            else if (R3C1.Text == "" && R3C2.Text == "" && R3C3.Text == "" && R3C4.Text == "")
                            {
                                R3C1.Text = course.Value.code;
                                R3C2.Text = course.Value.description;
                                R3C3.Text = course.Value.unit.ToString();
                                R3C4.Text = course.Value.grade;
                            }
                            else if (R4C1.Text == "" && R4C2.Text == "" && R4C3.Text == "" && R4C4.Text == "")
                            {
                                R4C1.Text = course.Value.code;
                                R4C2.Text = course.Value.description;
                                R4C3.Text = course.Value.unit.ToString();
                                R4C4.Text = course.Value.grade;
                            }
                            else if (R5C1.Text == "" && R5C2.Text == "" && R5C3.Text == "" && R5C4.Text == "")
                            {
                                R5C1.Text = course.Value.code;
                                R5C2.Text = course.Value.description;
                                R5C3.Text = course.Value.unit.ToString();
                                R5C4.Text = course.Value.grade;
                            }
                        }
                    }
                    GPATextBlock.Text = "GPA:            " + Math.Round((totalGrade / numClasses), 2);
                    if (Math.Round((totalGrade / numClasses), 2) >= 1.67)
                        statusTextBlock.Text = "Probationary Status: Clear";
                    else if (Double.IsNaN(Math.Round((totalGrade / numClasses), 2)))
                        statusTextBlock.Text = "Probationary Status: ";
                    else
                        statusTextBlock.Text = "Probationary Status: Probation";
                }
                else if (content.ToUpper().Equals("SEMESTER 5"))
                {
                    clearBoard();
                    int numClasses = 0;
                    double totalGrade = 0;
                    foreach (var course in violet.completedCoursesY3)
                    {
                        if (course.Key == 1)
                        {
                            totalGrade += getGrade2(course.Value.grade, ref numClasses);
                            if (R1C1.Text == "" && R1C2.Text == "" && R1C3.Text == "" && R1C4.Text == "")
                            {
                                R1C1.Text = course.Value.code;
                                R1C2.Text = course.Value.description;
                                R1C3.Text = course.Value.unit.ToString();
                                R1C4.Text = course.Value.grade;
                            }
                            else if (R2C1.Text == "" && R2C2.Text == "" && R2C3.Text == "" && R2C4.Text == "")
                            {
                                R2C1.Text = course.Value.code;
                                R2C2.Text = course.Value.description;
                                R2C3.Text = course.Value.unit.ToString();
                                R2C4.Text = course.Value.grade;
                            }
                            else if (R3C1.Text == "" && R3C2.Text == "" && R3C3.Text == "" && R3C4.Text == "")
                            {
                                R3C1.Text = course.Value.code;
                                R3C2.Text = course.Value.description;
                                R3C3.Text = course.Value.unit.ToString();
                                R3C4.Text = course.Value.grade;
                            }
                            else if (R4C1.Text == "" && R4C2.Text == "" && R4C3.Text == "" && R4C4.Text == "")
                            {
                                R4C1.Text = course.Value.code;
                                R4C2.Text = course.Value.description;
                                R4C3.Text = course.Value.unit.ToString();
                                R4C4.Text = course.Value.grade;
                            }
                            else if (R5C1.Text == "" && R5C2.Text == "" && R5C3.Text == "" && R5C4.Text == "")
                            {
                                R5C1.Text = course.Value.code;
                                R5C2.Text = course.Value.description;
                                R5C3.Text = course.Value.unit.ToString();
                                R5C4.Text = course.Value.grade;
                            }
                        }
                    }
                    GPATextBlock.Text = "GPA:            " + Math.Round((totalGrade / numClasses), 2);
                    if (Math.Round((totalGrade / numClasses), 2) >= 1.67)
                        statusTextBlock.Text = "Probationary Status: Clear";
                    else if (Double.IsNaN(Math.Round((totalGrade / numClasses), 2)))
                        statusTextBlock.Text = "Probationary Status: ";
                    else
                        statusTextBlock.Text = "Probationary Status: Probation";
                }
                else if (content.ToUpper().Equals("SEMESTER 6"))
                {
                    clearBoard();
                    int numClasses = 0;
                    double totalGrade = 0;
                    foreach (var course in violet.completedCoursesY3)
                    {
                        if (course.Key == 2)
                        {
                            totalGrade += getGrade2(course.Value.grade, ref numClasses);

                            if (R1C1.Text == "" && R1C2.Text == "" && R1C3.Text == "" && R1C4.Text == "")
                            {
                                R1C1.Text = course.Value.code;
                                R1C2.Text = course.Value.description;
                                R1C3.Text = course.Value.unit.ToString();
                                R1C4.Text = course.Value.grade;
                            }
                            else if (R2C1.Text == "" && R2C2.Text == "" && R2C3.Text == "" && R2C4.Text == "")
                            {
                                R2C1.Text = course.Value.code;
                                R2C2.Text = course.Value.description;
                                R2C3.Text = course.Value.unit.ToString();
                                R2C4.Text = course.Value.grade;
                            }
                            else if (R3C1.Text == "" && R3C2.Text == "" && R3C3.Text == "" && R3C4.Text == "")
                            {
                                R3C1.Text = course.Value.code;
                                R3C2.Text = course.Value.description;
                                R3C3.Text = course.Value.unit.ToString();
                                R3C4.Text = course.Value.grade;
                            }
                            else if (R4C1.Text == "" && R4C2.Text == "" && R4C3.Text == "" && R4C4.Text == "")
                            {
                                R4C1.Text = course.Value.code;
                                R4C2.Text = course.Value.description;
                                R4C3.Text = course.Value.unit.ToString();
                                R4C4.Text = course.Value.grade;
                            }
                            else if (R5C1.Text == "" && R5C2.Text == "" && R5C3.Text == "" && R5C4.Text == "")
                            {
                                R5C1.Text = course.Value.code;
                                R5C2.Text = course.Value.description;
                                R5C3.Text = course.Value.unit.ToString();
                                R5C4.Text = course.Value.grade;
                            }
                        }
                    }
                    GPATextBlock.Text = "GPA:            " + Math.Round((totalGrade / numClasses), 2);
                    if (Math.Round((totalGrade / numClasses), 2) >= 1.67)
                        statusTextBlock.Text = "Probationary Status: Clear";
                    else if (Double.IsNaN(Math.Round((totalGrade / numClasses), 2)))
                        statusTextBlock.Text = "Probationary Status: ";
                    else
                        statusTextBlock.Text = "Probationary Status: Probation";
                }
                else if (content.ToUpper().Equals("SEMESTER 7"))
                {
                    clearBoard();
                    int numClasses = 0;
                    double totalGrade = 0;
                    foreach (var course in violet.completedCoursesY4)
                    {
                        if (course.Key == 1)
                        {
                            totalGrade += getGrade2(course.Value.grade, ref numClasses);

                            if (R1C1.Text == "" && R1C2.Text == "" && R1C3.Text == "" && R1C4.Text == "")
                            {
                                R1C1.Text = course.Value.code;
                                R1C2.Text = course.Value.description;
                                R1C3.Text = course.Value.unit.ToString();
                                R1C4.Text = course.Value.grade;
                            }
                            else if (R2C1.Text == "" && R2C2.Text == "" && R2C3.Text == "" && R2C4.Text == "")
                            {
                                R2C1.Text = course.Value.code;
                                R2C2.Text = course.Value.description;
                                R2C3.Text = course.Value.unit.ToString();
                                R2C4.Text = course.Value.grade;
                            }
                            else if (R3C1.Text == "" && R3C2.Text == "" && R3C3.Text == "" && R3C4.Text == "")
                            {
                                R3C1.Text = course.Value.code;
                                R3C2.Text = course.Value.description;
                                R3C3.Text = course.Value.unit.ToString();
                                R3C4.Text = course.Value.grade;
                            }
                            else if (R4C1.Text == "" && R4C2.Text == "" && R4C3.Text == "" && R4C4.Text == "")
                            {
                                R4C1.Text = course.Value.code;
                                R4C2.Text = course.Value.description;
                                R4C3.Text = course.Value.unit.ToString();
                                R4C4.Text = course.Value.grade;
                            }
                            else if (R5C1.Text == "" && R5C2.Text == "" && R5C3.Text == "" && R5C4.Text == "")
                            {
                                R5C1.Text = course.Value.code;
                                R5C2.Text = course.Value.description;
                                R5C3.Text = course.Value.unit.ToString();
                                R5C4.Text = course.Value.grade;
                            }
                        }
                    }
                    GPATextBlock.Text = "GPA:            " + Math.Round((totalGrade / numClasses), 2);
                    if (Math.Round((totalGrade / numClasses), 2) >= 1.67)
                        statusTextBlock.Text = "Probationary Status: Clear";
                    else if (Double.IsNaN(Math.Round((totalGrade / numClasses), 2)))
                        statusTextBlock.Text = "Probationary Status: ";
                    else
                        statusTextBlock.Text = "Probationary Status: Probation";
                }
                else if (content.ToUpper().Equals("SEMESTER 8"))
                {
                    clearBoard();
                    int numClasses = 0;
                    double totalGrade = 0;
                    foreach (var course in violet.completedCoursesY4)
                    {
                        if (course.Key == 2)
                        {
                            totalGrade += getGrade2(course.Value.grade, ref numClasses);

                            if (R1C1.Text == "" && R1C2.Text == "" && R1C3.Text == "" && R1C4.Text == "")
                            {
                                R1C1.Text = course.Value.code;
                                R1C2.Text = course.Value.description;
                                R1C3.Text = course.Value.unit.ToString();
                                R1C4.Text = course.Value.grade;
                            }
                            else if (R2C1.Text == "" && R2C2.Text == "" && R2C3.Text == "" && R2C4.Text == "")
                            {
                                R2C1.Text = course.Value.code;
                                R2C2.Text = course.Value.description;
                                R2C3.Text = course.Value.unit.ToString();
                                R2C4.Text = course.Value.grade;
                            }
                            else if (R3C1.Text == "" && R3C2.Text == "" && R3C3.Text == "" && R3C4.Text == "")
                            {
                                R3C1.Text = course.Value.code;
                                R3C2.Text = course.Value.description;
                                R3C3.Text = course.Value.unit.ToString();
                                R3C4.Text = course.Value.grade;
                            }
                            else if (R4C1.Text == "" && R4C2.Text == "" && R4C3.Text == "" && R4C4.Text == "")
                            {
                                R4C1.Text = course.Value.code;
                                R4C2.Text = course.Value.description;
                                R4C3.Text = course.Value.unit.ToString();
                                R4C4.Text = course.Value.grade;
                            }
                            else if (R5C1.Text == "" && R5C2.Text == "" && R5C3.Text == "" && R5C4.Text == "")
                            {
                                R5C1.Text = course.Value.code;
                                R5C2.Text = course.Value.description;
                                R5C3.Text = course.Value.unit.ToString();
                                R5C4.Text = course.Value.grade;
                            }
                        }
                    }
                    GPATextBlock.Text = "GPA:            " + Math.Round((totalGrade / numClasses), 2);
                    System.Diagnostics.Debug.WriteLine(Math.Round((totalGrade / numClasses), 2));
                    if (Math.Round((totalGrade / numClasses), 2) >= 1.67)
                        statusTextBlock.Text = "Probationary Status: Clear";
                    else if (Double.IsNaN( Math.Round((totalGrade / numClasses), 2)))
                        statusTextBlock.Text = "Probationary Status: ";
                    else
                        statusTextBlock.Text = "Probationary Status: Probation";

                }

            }

        }


        private void clearBoard()
        {
            R1C1.Text = "";
            R1C2.Text = "";
            R1C3.Text = "";
            R1C4.Text = "";
            R2C1.Text = "";
            R2C2.Text = "";
            R2C3.Text = "";
            R2C4.Text = "";
            R3C1.Text = "";
            R3C2.Text = "";
            R3C3.Text = "";
            R3C4.Text = "";
            R4C1.Text = "";
            R4C2.Text = "";
            R4C3.Text = "";
            R4C4.Text = "";
            R5C1.Text = "";
            R5C2.Text = "";
            R5C3.Text = "";
            R5C4.Text = "";
            statusTextBlock.Text = "";
            GPATextBlock.Text = "";
        }


    }
}
