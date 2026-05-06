using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Event_Manager
{
    // Generic class
    public class RegistrationManager<T> where T : Registration
    {
        // Collection to store registrations 
        private List<T> registrations = new List<T>();

        public void AddRegistration(T registration)
        {
            registrations.Add(registration);
        }

        // FIX 1: Changed return type from void to string
        public string DisplayAllRegistrations()
        {
            string output = "";

            if (registrations.Count == 0)
            {
                output = "No registrations have been found!!!";
                return output;
            }

            foreach (T registration in registrations)
            {
                output += registration.DisplayDetails();
            }

            return output;
        }

        // FIX 2: Changed return type from void to string, and built an output variable
        public string DisplayMatchingRegistrations(RegistrationCriteria criteria) // Delegate is being passed as a parameter 
        {
            string output = "";
            bool found = false;

            foreach (T registration in registrations)
            {
                if (criteria(registration)) // Calling the delegate 
                {
                    // Accumulate the strings to display in your WPF text box
                    output += registration.DisplayDetails();
                    found = true;
                }
            }

            if (!found)
            {
                // Replaced Console.WriteLine with standard string output for WPF
                output = "No matching registrations have been found.";
            }

            return output;
        }

        public double CalculateTotalFees()
        {
            double total = 0;

            foreach (T registration in registrations)
            {
                total += registration.Fee;
            }

            return total;
        }

        public int CountMatchingRegistrations(RegistrationCriteria criteria)
        {
            int count = 0;

            foreach (T registration in registrations)
            {
                if (criteria(registration))
                {
                    count++;
                }
            }

            return count;
        }
    }
}