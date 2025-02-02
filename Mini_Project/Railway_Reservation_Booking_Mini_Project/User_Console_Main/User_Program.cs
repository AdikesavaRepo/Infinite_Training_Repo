﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway_Reservation_Booking_Mini_Project;

namespace User_Console_Main
{
    class User_Program
    {
        static RailwayReservation_Booking_SystemEntities db = new RailwayReservation_Booking_SystemEntities();

        static tblTrain tr = new tblTrain();
        static tblClassDetail cd = new tblClassDetail();
        static tblBooking tb = new tblBooking();
        static tblCancellation tc = new tblCancellation();

        static void Main(string[] args)
        {
            Console.WriteLine("===WELCOME TO RAILWAY BOOKING SYSTEM - ADMIN===");

            Console.WriteLine("-------- You are Logged in as **USER** -----------");

            UserLogin();
        }

        static void UserLogin()
        {
            try
            {
                Console.WriteLine(" Please Choose Your Option to Perform:");
                Console.WriteLine("___________________________________");
                Console.WriteLine("|  Option  | Description          |");
                Console.WriteLine("___________________________________");
                Console.WriteLine("|  1       | Book Ticket          |");
                Console.WriteLine("|  2       | Print Ticket         |");
                Console.WriteLine("|  3       | Cancel Ticket        |");
                Console.WriteLine("|  4       | Show Bookings        |");
                Console.WriteLine("|  5       | Exit() - User Menu() |");
                Console.WriteLine("|  6       | Exit()               |");
                Console.WriteLine("___________________________________");
                Console.Write("Enter your choice of Operation : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You Entered Into Booking Page.. Please Continue Booking...");
                        Book_Ticket();
                        break;
                    case 2:
                        Console.WriteLine("Select Booking ID from below which you want to print");
                        Show_Bookings();
                        Print_Ticket();
                        break;
                    case 3:
                        Show_Bookings();
                        Cancel_Ticket();
                        break;
                    case 4:
                        Show_Bookings();
                        UserLogin();
                        break;
                    case 5:
                        UserLogin();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select Option Available above only!!!");
                        break;
                }
                Console.WriteLine("User operations go here...");
                Console.WriteLine("Returning to main menu...");
                Console.WriteLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("An Error Occured : Please Choose and select Wisely ",ex.Message);
                Console.WriteLine("Returning to User Menu");
                UserLogin();
            }
            
        }

        public static void Book_Ticket()
        {
            try
            {
                Console.Write("Enter Source Station: ");
                string Source_Station= Console.ReadLine();

                Console.Write("Enter Destination Station: ");
                string Destination_Station = Console.ReadLine();

                db.sp_GetAvailableTrains(Source_Station,Destination_Station);
                db.SaveChanges();

                Console.WriteLine("Available Trains are as Below: ");


                Display_Train();

                TicketClass_Details();
                Console.WriteLine(" Select Required types of Class ");
                Console.WriteLine("Please Select/Choose accordingly");



                Console.Write("Re-Verify The Train Number :  ");
                int Train_No = Convert.ToInt32(Console.ReadLine());

                // Check if the train is active before proceeding with the booking
                var train = db.tblTrains.FirstOrDefault(t => t.Train_No == Train_No && t.Status == "Active");
                if (train == null)
                {
                    Console.WriteLine("Sorry! This train is not running at this time or The Train Does not Exist");
                    Console.WriteLine(" Returning to User Menu or HOME");
                    UserLogin();
                    return;
                }

                Console.Write("Enter Passenger Name: ");
                string Passenger_Name = Console.ReadLine();

                Console.Write("Enter Class Name: ");
                string Class_Name = Console.ReadLine();

                

                Console.Write("Enter Date of Travel (YYYY-MM-DD): ");
                DateTime Travel_Date = Convert.ToDateTime(Console.ReadLine());

                // validate date
                DateTime Current_Date = DateTime.Now;
                if (Travel_Date.Date < Current_Date.Date)
                {
                    Console.WriteLine("*********************************");
                    Console.WriteLine("Sorry!!! The Booking is failed ...");
                    Console.WriteLine(".......Travel Date must be Today or Future Dates ..........");
                    Console.WriteLine("*********************************");
                    Console.WriteLine("Returning to Main Menu or User Menu");
                    UserLogin();
                }

                Console.Write("Enter Number of Tickets: ");
                int Tickets_Count = Convert.ToInt32(Console.ReadLine());

                // validate tickets
                if (Tickets_Count < 1 || Tickets_Count > 3)
                {
                    Console.WriteLine("*********************************");
                    Console.WriteLine("Sorry!!! The Booking is failed ...");
                    Console.WriteLine(".......Minimum Number of Tickets to Book is 1 and Maximum is 3.........");
                    Console.WriteLine("*********************************");
                    Console.WriteLine("Returning to Main Menu or User Menu");
                    UserLogin();
                }

                // Proceed Booking if all good
                db.sp_BookingTrain_Ticket(Train_No, Passenger_Name, Class_Name, Travel_Date, Tickets_Count);
                db.SaveChanges();

                // Retrieve the booking ID after successful booking
                var booking = db.tblBookings.OrderByDescending(b => b.Booking_ID).FirstOrDefault();
                if (booking != null)
                {
                    Console.WriteLine("Congratulations!!!Ticket Booked Successfully! Your Booking ID is: " + booking.Booking_ID);
                    Console.WriteLine("Wishing You a Safe and Happy Journey");
                    Console.WriteLine(" Returning to User Menu or HOME");
                    UserLogin();
                }
                else
                {
                    Console.WriteLine("Ticket Booked Successfully!");
                    Console.WriteLine("Wishing You a Safe and Happy Journey");
                    Console.WriteLine(" Returning to User Menu or HOME");
                    UserLogin();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine("An error occurred while Booking .. Please Try Again Later ");
                Console.WriteLine(" Returning to User Menu or HOME");
                UserLogin();
            }
        }

        static void Print_Ticket()
        {
            Console.Write("Enter Booking ID:");
            int Booking_ID = int.Parse(Console.ReadLine());
            Console.WriteLine($"The E-Ticket for Booking ID {Booking_ID} is Avaialable Below: ");

            var booking = db.tblBookings.FirstOrDefault(b => b.Booking_ID == Booking_ID);
            if (booking != null)
            {
                Console.WriteLine(" _________________________________________________________");
                Console.WriteLine(" |             E - TICKET                                 ");
                Console.WriteLine(" _________________________________________________________");
                Console.WriteLine($"| Booking ID: {booking.Booking_ID}                       ");
                Console.WriteLine($"| Passenger Name: {booking.Passenger_Name}               ");
                Console.WriteLine($"| Train Number: {booking.Train_No}                       ");
                Console.WriteLine($"| Class Name: {booking.Class_Name}                       ");
                Console.WriteLine($"| Date of Travel: {booking.Travel_Date}                  ");
                Console.WriteLine($"| Number of Tickets: {booking.Tickets_Count}             ");
                Console.WriteLine($"| Total Amount: {booking.Total_Amount}                   ");
                Console.WriteLine($"| Status: {booking.Status}                               ");
                Console.WriteLine(" _________________________________________________________");

                Console.WriteLine("Booking has been successfully done");
                Console.WriteLine(" Wishing You A safe and Happy Journey...");

                Console.WriteLine(" Returning to User Menu or HOME");
                UserLogin();


            }
            else
            {
                Console.WriteLine("Booking not found.");
                Console.WriteLine(" Returning to User Menu or HOME");
                UserLogin();
            }
        }

        static void Cancel_Ticket()
        {
            Console.Write("Enter Booking ID for Which You want to Cancel: ");
            int Booking_ID = int.Parse(Console.ReadLine());

            // Retrieve the booking details from the database
            var bookingToDelete = db.tblBookings.FirstOrDefault(b => b.Booking_ID == Booking_ID);
            if (bookingToDelete != null)
            {
                Console.Write("Enter Passenger Name:");
                string Passenger_Name = Console.ReadLine();

                Console.Write("Enter Train Number:");
                int Train_No = int.Parse(Console.ReadLine());

                Console.Write("Enter Class Name:");
                string Class_Name = Console.ReadLine();

                Console.Write("Enter Number of Tickets to Cancel:");
                int Tickets_Count = int.Parse(Console.ReadLine());

                try
                {

                    // Call the stored procedure to cancel the ticket
                    db.sp_Cancel_Ticket(Booking_ID, Passenger_Name, Train_No, Class_Name, Tickets_Count);
                    db.SaveChanges();
                    Console.WriteLine("-------- Ticket Cancelled Successfully! ---------------");
                    Console.WriteLine(" Returning to User Menu or HOME");
                    UserLogin();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.WriteLine(" Returning to User Menu or HOME");
                    UserLogin();
                }
            }
            else
            {
                Console.WriteLine("  SORRY!!! Booking not found with given Booking ID.");
                Console.WriteLine(" Returning to User Menu or HOME");
                UserLogin();
            }
        }

        static void Display_Train()
        {
            var trains = db.tblTrains.ToList();


            Console.WriteLine("________________________________________________________________________________________________________________");
            Console.WriteLine("-- Train No             -- Train Name                 -- Source Station       -- Destination Station     -- Status   --");
            Console.WriteLine("_______________________________________________________________________________________________________________");

            foreach (var tr in trains)
            {
                Console.WriteLine($"-- {tr.Train_No,-20} -- {tr.Train_Name,-20}  -- {tr.Source_Station,-20} -- {tr.Destination_Station,-20}    -- {tr.Status,-8} --");
            }

            Console.WriteLine("________________________________________________________________________________________________________________");

        }

        static void TicketClass_Details()
        {

            Console.Write("Enter Train Number according to class you want to travel: ");
            tr.Train_No = int.Parse(Console.ReadLine());
            var trainVal = db.tblClassDetails.Where(t => t.Train_No == tr.Train_No).ToList();


            foreach (var Class_Detail in trainVal)
            {
                Console.WriteLine($"Train_No: {Class_Detail.Train_No}, Class_Name: {Class_Detail.Class_Name}, Total_Seats: {Class_Detail.Total_Seats}, Available_Seats: {Class_Detail.Available_Seats}, Fare: {Class_Detail.Fare}");
            }
            Console.WriteLine("__________________________________________________________________________________________________________________________________________________________________________________________________");

        }

        static void Show_Bookings()
        {
            var allBookings = db.tblBookings.ToList();

            Console.WriteLine("All Bookings:");
            Console.WriteLine("______________________________________________________________________________________________________________________________");
            Console.WriteLine("-- Booking ID -- Passenger Name       -- Train No -- Class Name -- Travel Date -- Tickets Count -- Total Amount -- Status of Booking --");
            Console.WriteLine("______________________________________________________________________________________________________________________________");

            foreach (var booking in allBookings)
            {
                Console.WriteLine($"-- {booking.Booking_ID,-11} -- {booking.Passenger_Name,-20} -- {booking.Train_No,-8} -- {booking.Class_Name,-10} -- {booking.Travel_Date,-12:d} -- {booking.Tickets_Count,-13} -- {booking.Total_Amount,-13} -- {booking.Status,-13}");
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        }


    }
}
