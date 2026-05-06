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
        RegistrationManager<Registration> manager = new RegistrationManager<Registration>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Create a Instance of Registration
            Registration registration = new Registration();

            registration.EmployeeName = txtEmployeeName.Text;
            registration.EventName = txtEventName.Text;
            registration.Department = txtDepartment.Text;

            if (!double.TryParse(txtFee.Text, out double fee))
            {
                MessageBox.Show("Please Enter a Valid Fee",
                    "Fee Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            if (!int.TryParse(txtDaysAttending.Text, out int daysAttending))
            {
                MessageBox.Show("Please Enter a Valid Number of Days",
                    "Days Attending Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            registration.Fee = fee;
            registration.DaysAttending = daysAttending;

            manager.AddRegistration(registration);

            MessageBox.Show("Registration has been successfully Completed!");


        }

        private void btnFilterDepartment_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Clear();

            DisplayHeading("FILTER BY DEPARTMENT");

            string selectedDepartment = txtFilterDepartment.Text;

            txtOutput.AppendText(manager.DisplayMatchingRegistrations(delegate (Registration r)
            {
                return r.Department.ToUpper() == selectedDepartment.ToUpper();
            }));



        }

        private void btnDisplayAll_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Clear();

            DisplayHeading("ALL REGISTRATIONS");
            txtOutput.AppendText(manager.DisplayAllRegistrations());

        }

        private void btnNeedsApproval_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Clear();

            DisplayHeading("REGISTRATIONS REQUIRING APPROVAL");
                txtOutput.AppendText(manager.DisplayMatchingRegistrations(delegate (Registration r) // Anonymous Method 
                {
                    return r.NeedsApproval();
                }));

        }

        private void btnSummary_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Clear();

            DisplayHeading("SUMMARY");

            txtOutput.AppendText("Total Fees Collected R" + manager.CalculateTotalFees() + "\n");

            // FIX: Added AppendText right here!
            txtOutput.AppendText("Total Registrations Requiring Approval: " +
                manager.CountMatchingRegistrations(delegate (Registration r)
                {
                    return r.NeedsApproval();
                }));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextFields();
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