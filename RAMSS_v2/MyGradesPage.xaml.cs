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

        public MyGradesPage()
        {
            this.InitializeComponent();
            
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
    }
}
