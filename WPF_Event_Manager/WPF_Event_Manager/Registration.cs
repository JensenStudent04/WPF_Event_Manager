using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Event_Manager
{
    public class Registration
    {
        public string EmployeeName { get; set; }
        public string EventName { get; set; }
        public string Department { get; set; }
        public double Fee { get; set; }
        public int DaysAttending { get; set; }

        // Prompt the user for details 
        //public void CaptureDetails()
        //{
        //    Console.Write("Enter employee name: ");
        //    EmployeeName = Console.ReadLine();

        //    Console.Write("Enter event name: ");
        //    EventName = Console.ReadLine();

        //    Console.Write("Enter department: ");
        //    Department = Console.ReadLine();

        //    Console.Write("Enter registration fee: ");
        //    Fee = Convert.ToDouble(Console.ReadLine());

        //    Console.Write("Enter number of days attending: ");
        //    DaysAttending = Convert.ToInt32(Console.ReadLine());
        //}

        // Display all Details
        public string DisplayDetails()
        {
            //Create a Variable to hold our Display 
            string output = "";
            output += new string('*', 50) + "\n";
            output += new string('*', 50) + "\n";
            output += "Employee Name   : " + EmployeeName + "\n";
            output += "Event Name      : " + EventName + "\n";
            output += "Department      : " + Department + "\n";
            output += "Fee             : R" + Fee + "\n";
            output += "Days Attending  : " + DaysAttending + "\n";
            output += "Needs Approval  : " + (NeedsApproval() ? "Yes" : "No") + "\n"; // Ternary Operator
            output += new string('*', 50) + "\n";


            return output;
        }

        public bool NeedsApproval()
        {
            return Fee > 2000 || DaysAttending > 3;
        }
    }
}