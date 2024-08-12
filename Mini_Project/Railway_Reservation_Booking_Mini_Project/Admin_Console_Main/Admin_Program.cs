using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway_Reservation_Booking_Mini_Project;


namespace Admin_Console_Main
{
    class Admin_Program
    {
        static RailwayReservation_Booking_SystemEntities db = new RailwayReservation_Booking_SystemEntities();

        static tblTrain tr = new tblTrain();
        static tblClassDetail cd = new tblClassDetail();
        static tblBooking tb = new tblBooking();
        static tblCancellation tc = new tblCancellation();

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
            try
            {
                Console.WriteLine("*** Admin Login ***");
                Console.Write("Enter Admin Name: ");
                string Admin_Name = Console.ReadLine();
                Console.Write("Enter Password: ");
                int Admin_Password = Convert.ToInt32(Console.ReadLine());

                if (Admin_Name == "aadi" && Admin_Password == 4567)
                {
                    Console.WriteLine();
                    Console.WriteLine("____________________________________________");
                    Console.WriteLine("|  Option        | Description             |");
                    Console.WriteLine("____________________________________________");
                    Console.WriteLine("|  1             | Adding a  Train         |");
                    Console.WriteLine("|  2             | Modify a  Train         |");
                    Console.WriteLine("|  3             | Inactivate/Delete Train |");
                    Console.WriteLine("|  4             | Re-Activate Train       |");
                    Console.WriteLine("|  5             | Show Trains             |");
                    Console.WriteLine("|  6             | Show Bookings           |");
                    Console.WriteLine("|  7             | Show Cancellations      |");
                    Console.WriteLine("|  8             | Exit() to Login Menu()  |");
                    Console.WriteLine("|  9             | Exit()                  |");
                    Console.WriteLine("____________________________________________");
                    Console.WriteLine("Operations... By Admin... Happens here....");
                    Console.Write("Enter your option from above : ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            AddTrain();
                            
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
                        case 7:
                            ShowAllCancellations();
                            break;
                        case 8:
                            AdminLogin();
                            break;
                        case 9:
                            Environment.Exit(0);
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
                    AdminLogin();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occured : Please Select Option Wisely as Displayed above ", ex.Message);
                Console.WriteLine("Returning to Admin menu...");
                AdminLogin();

            }
            
        }
        

        // -------------------------- Adding Train ---------------------------------
        static void AddTrain()
        {

            try
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
                var classes = new string[] { "1AC", "2AC", "Sleeper" };
                foreach (var c in classes)
                {
                    cd.Train_No = tr.Train_No;
                    cd.Class_Name = c;
                    Console.Write($"Enter Total seats You want to keep {c} :");
                    cd.Total_Seats = int.Parse(Console.ReadLine());
                    Console.Write("Availble seats in the class are: ");
                    cd.Available_Seats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Amount for the Particular class: ");
                    cd.Fare = int.Parse(Console.ReadLine());

                    db.tblClassDetails.Add(cd);
                    db.SaveChanges();
                    Console.WriteLine();
                }
                Console.WriteLine("Train Has been Added Successfully by Admin...");
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured "+ ex.Message);
            }
        }

        // ---------------------- Modifying/Editing Train Data -------------------------

        public static void Modify_Train()
        {
            Console.Write("Enter Train No.: ");
            int train_No = int.Parse(Console.ReadLine());

            // Retrieve the train details from the database
            var tu = db.tblTrains.FirstOrDefault(t => t.Train_No == train_No);
            if (tu != null)
            {
                Console.Write("Enter Train Name: ");
                tu.Train_Name = Console.ReadLine();
                Console.Write("Enter Train Source Station: ");
                tu.Source_Station = Console.ReadLine();
                Console.Write("Enter Train Destination Station: ");
                tu.Destination_Station = Console.ReadLine();
                Console.Write("Enter Status: ");
                tu.Status = Console.ReadLine();

                db.SaveChanges();

                Console.WriteLine("Modified and Updated Train list As below...");
                Display_Train();
            }

            else
            {
                Console.WriteLine("Train do not exists ");
                AdminLogin();
            }
        }

        // ------------------ Deleting Train Data or setting Train Running Status INACTIVE --------------

        public static void Delete_Train()
        {
            Console.WriteLine("You cannot delete the train Permanently, but can set set the status to inactive");
            Display_Train();
            Console.Write("Enter the Train Number: ");
            int train_No = int.Parse(Console.ReadLine());

            // Retrieve the train details from the database
            var td = db.tblTrains.FirstOrDefault(t => t.Train_No == train_No);
            if (td != null)
            {
                // Soft delete by updating the status to "Inactive"
                td.Status = "InActive";
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

        // --------------- Re-Activating Train Running Status To ACTIVE --------------------

        static void Activate_Train(int trainNo)
        {
            // Retrieve the train from the database
            var trainact = db.tblTrains.FirstOrDefault(t => t.Train_No == trainNo);
            if (trainact != null)
            {
                if (trainact.Status == "Active")
                {
                    Console.WriteLine("Selected Train is Already Running and active state");
                }
                else
                {
                    // Activate the train by setting its status to "Active"
                    trainact.Status = "Active";
                    db.SaveChanges();
                    Console.WriteLine("Selected Train is now set to Active and ready to run successfully");
                }
            }
            else
            {
                Console.WriteLine("Selected Train number not exist or not available currently");
            }
        }

        // ------------- Showing All Available Trains -----------------------------

        static void Display_Train()
        {
            var trains = db.tblTrains.ToList();

            // Display the table header
            Console.WriteLine("__________________________________________________________________________________________________________");
            Console.WriteLine("-- Train No  -- Train Name                             -- Source              -- Destination      -- Status   --");
            Console.WriteLine("__________________________________________________________________________________________________________");

            foreach (var tr in trains)
            {
                Console.WriteLine($"-- {tr.Train_No,-9} -- {tr.Train_Name,-37} -- {tr.Source_Station,-12} -- {tr.Destination_Station,-16} -- {tr.Status,-8} --");
            }

            // End the table with a bottom border
            Console.WriteLine("__________________________________________________________________________________________________________");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

        }

        // ----------- Showing All Bookings In Bookings Table -------------------------

        static void ShowAllBookings()
        {
            var Bookings = db.tblBookings.ToList();

            Console.WriteLine("All Bookings:");
            Console.WriteLine("__________________________________________________________________________________________________________");
            Console.WriteLine("-- Booking ID -- Passenger Name       -- Train No -- Class Name -- Travel Date -- Tickets Count -- Total Amount --");
            Console.WriteLine("__________________________________________________________________________________________________________");

            foreach (var b in Bookings)
            {
                Console.WriteLine($"-- {b.Booking_ID,-11} -- {b.Passenger_Name,-20} -- {b.Train_No,-8} -- {b.Class_Name,-10} -- {b.Travel_Date,-12:d} -- {b.Tickets_Count,-13} -- {b.Total_Amount,-13} --");
            }

            Console.WriteLine("__________________________________________________________________________________________________________"); ;
        }

        static void ShowAllCancellations()
        {
            var Cancellations = db.tblCancellations.ToList();

            Console.WriteLine("All Cancellations:");
            Console.WriteLine("______________________________________________________________________________________________________________");
            Console.WriteLine("| Cancellation ID | Booking ID       | Passanger Name | Train_No | Class_Name | Tickets Count | DateOfCancel |");
            Console.WriteLine("______________________________________________________________________________________________________________");

            foreach (var c in Cancellations)
            {
                Console.WriteLine($"| {c.Cancellation_ID,-11} | {c.Booking_ID,-11} | {c.Passenger_Name,-20} | {c.Train_No,-8} | {c.Class_Name,-10} | {c.Tickets_Count,-12:d} | {c.DateOf_Cancel,-13} |");
            }

            Console.WriteLine("__________________________________________________________________________________________________________"); ;
        }

        // --------------- Showing All Trains data in Trains Table

        static void ShowAllTrains()
        {
            var Trains = db.tblTrains.ToList();

            Console.WriteLine("All Trains:");
            Console.WriteLine("__________________________________________________________________________________________________________________");
            Console.WriteLine("-- Train No  -- Train Name                             -- Source              -- Destination      -- Status   --");
            Console.WriteLine("__________________________________________________________________________________________________________________");
            db.sp_Display_Train();
            db.SaveChanges();
            foreach (var t in Trains)
            {
                Console.WriteLine($"-- {t.Train_No,-9} -- {t.Train_Name,-37} -- {t.Source_Station,-12} -- {t.Destination_Station,-16} -- {t.Status,-8} --");
            }

            Console.WriteLine("__________________________________________________________________________________________________________________");
        }


    }
}
