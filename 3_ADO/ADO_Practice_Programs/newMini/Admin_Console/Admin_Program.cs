﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using newMini;


namespace Admin_Console
{
    class Admin_Program
    {
        static MiniProjectPracticeEntities db = new MiniProjectPracticeEntities();
        static tblTrain tr = new tblTrain();
        static tblClassDetail cd = new tblClassDetail();
        static void Main(string[] args)
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("===WELCOME TO RAILWAY BOOKING SYSTEM - ADMIN===");
           
            Console.WriteLine("-------- You are Logging in as **ADMIN** -----------");

            AdminLogin();
            Console.ReadLine();
        }

        static void AdminLogin()
        {
            Console.WriteLine("*** Admin Login ***");
            Console.Write("Enter Admin Name: ");
            string Admin_Name = Console.ReadLine();
            Console.Write("Enter Password: ");

            // Hide password input
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                // Ignore any key other than Backspace and Enter
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password.Append(key.KeyChar);
                    Console.Write("*"); // Print asterisk for each character entered
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b"); // Clear the character and move the cursor back
                }
            } while (key.Key != ConsoleKey.Enter);

            int Admin_Password;
            if (int.TryParse(password.ToString(), out Admin_Password))
            {
                Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                if (Admin_Name == "aadi" && Admin_Password == 4567)
                {
                    // Admin operations menu
                    Console.WriteLine();
                    Console.WriteLine("____________________________________________");
                    Console.WriteLine("|  Option        | Description             |");
                    Console.WriteLine("____________________________________________");
                    Console.WriteLine("|  1             | Add Train               |");
                    Console.WriteLine("|  2             | Modify Train            |");
                    Console.WriteLine("|  3             | Inactivate/Delete Train |");
                    Console.WriteLine("|  4             | Re-Activate Train       |");
                    Console.WriteLine("|  5             | Show Trains             |");
                    Console.WriteLine("|  6             | Show Bookings           |");
                    Console.WriteLine("____________________________________________");
                    Console.WriteLine("Operations... By Admin... Happens here....");
                    Console.Write("Enter your option from above : ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            AddTrain();
                            Console.WriteLine("Train Has been Added Successfully by Admin...");
                            Display_Train();
                            break;
                        case 2:
                            Console.WriteLine("Modyfing/Editing the Train Details...");
                            Display_Train();
                            Modify_Train();
                            break;
                        case 3:
                            Console.WriteLine("Partial Deletion Only happens here...");
                            Delete_Train();
                            Display_Train();
                            break;
                        case 4:
                            //Console.WriteLine("Please enter the Train Number to activate:");
                            Display_Train();
                            Console.WriteLine("Enter Train Number from above list which you want to Activate:");
                            int trainNoToActivate = int.Parse(Console.ReadLine());
                            Activate_Train(trainNoToActivate);
                            Display_Train();
                            break;
                        case 5:
                            ShowAllTrains();
                            break;
                        case 6:
                            ShowAllBookings();
                            break;

                        default:
                            Console.WriteLine("Entered Choice/Option is invalid!!... Please Select Valid Option Only...");
                            break;
                    }

                    Console.WriteLine("Returning to main menu...");
                    Console.WriteLine("Verify you are Admin");
                    AdminLogin();
                }
                else
                {
                   
                    Console.WriteLine("\n...Oooops...... Invalid admin credentials, your access to Admin Console is Denied");
                    Console.WriteLine("Returning to Admin Menu");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid password ... Please try again later");
                Console.WriteLine("Returning to main menu...");
            }
        }


        //---------------------AddTrain--------------------------
        static void AddTrain()
        {

            Console.Write("Enter Train Number : ");
            tr.Train_No = int.Parse(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            tr.Train_Name = Console.ReadLine();
            Console.Write("Enter Source Station: ");
            tr.Source_Station = Console.ReadLine();
            Console.Write("Enter Destination Station: ");
            tr.Destination_Station = Console.ReadLine();
            tr.Status = "Active";
            db.tblTrains.Add(tr);
            db.SaveChanges();
            var classname = new string[] { "1AC", "2AC", "Sleeper" };
            foreach (var ClassName in classname)
            {
                cd.Train_No = tr.Train_No;
                cd.Class_Name = ClassName;
                Console.Write($"Enter Total seats {ClassName} :");
                cd.Total_Seats = int.Parse(Console.ReadLine());
                Console.Write("Availble seats: ");
                cd.Available_Seats = int.Parse(Console.ReadLine());
                Console.Write("Enter Fare Amount: ");
                cd.Fare = int.Parse(Console.ReadLine());

                db.tblClassDetails.Add(cd);
                db.SaveChanges();
                Console.WriteLine();
            }
        }




        //----------------------------Display Trains-------------------------------------------------------------------------------
        static void Display_Train()
        {
            var trains = db.tblTrains.ToList();

            // Display the table header
            Console.WriteLine("__________________________________________________________________________________________________________");
            Console.WriteLine("| Train No  | Train Name                             | Source              | Destination      | Status   |");
            Console.WriteLine("__________________________________________________________________________________________________________");

            foreach (var tr in trains)
            {
                Console.WriteLine($"| {tr.Train_No,-9} | {tr.Train_Name,-37} | {tr.Source_Station,-12} | {tr.Destination_Station,-16} | {tr.Status,-8} |");
            }

            // End the table with a bottom border
            Console.WriteLine("__________________________________________________________________________________________________________");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

        }







        static void Activate_Train(int trainNo)
        {
            // Retrieve the train from the database
            var trainToActivate = db.tblTrains.FirstOrDefault(t => t.Train_No == trainNo);
            if (trainToActivate != null)
            {
                if (trainToActivate.Status == "Active")
                {
                    Console.WriteLine("Selected Train is Already Running and active state");
                }
                else
                {
                    // Activate the train by setting its status to "Active"
                    trainToActivate.Status = "Active";
                    db.SaveChanges();
                    Console.WriteLine("Selected Train is now set to Active and ready to run successfully");
                }
            }
            else
            {
                Console.WriteLine("Selected Train number not exist or not available currently" );
            }
        }
        public static void Modify_Train()
        {
            Console.Write("Enter Train No.: ");
            int train_No = int.Parse(Console.ReadLine());

            // Retrieve the train details from the database
            var trainToUpdate = db.tblTrains.FirstOrDefault(t => t.Train_No == train_No);
            if (trainToUpdate != null)
            {
                Console.Write("Enter Train Name: ");
                trainToUpdate.Train_Name = Console.ReadLine();
                Console.Write("Enter Train Source Station: ");
                trainToUpdate.Source_Station = Console.ReadLine();
                Console.Write("Enter Train Destination Station: ");
                trainToUpdate.Destination_Station = Console.ReadLine();
                Console.Write("Enter Status: ");
                trainToUpdate.Status = Console.ReadLine();
                // Update the train in the database

                db.SaveChanges();
       

                Console.WriteLine("Modified and Updated Train list As below...");

                Display_Train();
                
                //AdminLogin();
            }

            else
            {
                Console.WriteLine("Train do not exists ");
                AdminLogin();
            }
        }
        public static void Delete_Train()
        {
            Console.WriteLine("You cannot delete the train Permanently, but can set set the status to inactive");
            Display_Train();
            Console.Write("Enter the Train Number: ");
            int train_No = int.Parse(Console.ReadLine());

            // Retrieve the train details from the database
            var trainToDelete = db.tblTrains.FirstOrDefault(t => t.Train_No == train_No);
            if (trainToDelete != null)
            {
                // Soft delete by updating the status to "Inactive"
                trainToDelete.Status = "InActive";
                db.SaveChanges();
                Console.WriteLine("Train  status has been set to Inactive and not running curently");
                Display_Train();
                AdminLogin();
            }
            else
            {
                Console.WriteLine("Selected Train does not exist.. Please Try Again...");
                AdminLogin();
            }
        }

        static void ShowAllBookings()
        {
            var allBookings = db.tblBookings.ToList();

            Console.WriteLine("All Bookings:");
            Console.WriteLine("__________________________________________________________________________________________________________");
            Console.WriteLine("| Booking ID | Passenger Name       | Train No | Class Name | Travel Date | Tickets Count | Total Amount |");
            Console.WriteLine("__________________________________________________________________________________________________________");

            foreach (var booking in allBookings)
            {
                Console.WriteLine($"| {booking.Booking_ID,-11} | {booking.Passenger_Name,-20} | {booking.Train_No,-8} | {booking.Class_Name,-10} | {booking.Travel_Date,-12:d} | {booking.Tickets_Count,-13} | {booking.Total_Amount,-13} |");
            }

            Console.WriteLine("__________________________________________________________________________________________________________"); ;
        }

        static void ShowAllTrains()
        {
            var allTrains = db.tblTrains.ToList();

            Console.WriteLine("All Trains:");
            Console.WriteLine("__________________________________________________________________________________________________________________");
            Console.WriteLine("| Train No  | Train Name                             | Source              | Destination      | Status   |");
            Console.WriteLine("__________________________________________________________________________________________________________________");
            db.sp_Display_Train();
            db.SaveChanges();
            foreach (var train in allTrains)
            {
                Console.WriteLine($"| {train.Train_No,-9} | {train.Train_Name,-37} | {train.Source_Station,-12} | {train.Destination_Station,-16} | {train.Status,-8} |");
            }

            Console.WriteLine("__________________________________________________________________________________________________________________");
        }
    }
}
