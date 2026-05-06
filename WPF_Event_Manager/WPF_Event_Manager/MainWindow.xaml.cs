using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Event_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///  // Delegate
    public delegate bool RegistrationCriteria(Registration registration);
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Create a Instance of Registration
            Registration registration = new Registration();

        }

        private void btnFilterDepartment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDisplayAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNeedsApproval_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSummary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        public void DisplayHeading(string heading)
        {
            string title = " " + heading + " ";
            string stars = new string('*', title.Length);

            txtOutput.AppendText("\n");
            txtOutput.AppendText(stars);
            txtOutput.AppendText(title);
            txtOutput.AppendText(stars);
        }

        //Create a Method which clears textboxes and text
        private void ClearTextFields()
        {
            txtOutput.Clear();
            txtEmployeeName.Clear();
            txtEventName.Clear();
            txtFilterDepartment.Clear();
            txtDaysAttending.Clear();
            txtFee.Clear();

        }

        private void txtOutput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}