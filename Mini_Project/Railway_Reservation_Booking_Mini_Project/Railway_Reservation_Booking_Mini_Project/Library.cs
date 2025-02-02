﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_Booking_Mini_Project
{
    public class Library
    {
        static RailwayReservation_Booking_SystemEntities db = new RailwayReservation_Booking_SystemEntities();

        // ----- Entity Model ----
        // 1. Data First Approach( Existing database) : Relations are simply mapped to classes as Models
        // -----

        //This is a library class

        // It has all the Packages and Models

        // Tables -- 4
        //  1) Table Trains (tblTrains) -- stores trains data
        //  2) Table Class Details (tblClassDetails) -- stores Trains Classes types and Fares
        //  3) Table Bookings (tblBookings) -- Stores all User Booking data
        //  4) Table Cancellations (tblCancellations) -- Stores all User Cancellation data

        // Stores Procedures -- 8
        //  1) Adding Train Details (sp_AddTrain)
        //  2) Adding Class Details To above Trains (sp_AddClass_Details)
        //  3) Displaying Trains Data (sp_Display_Train)
        //  4) Displaying Classes Data (sp_Display_Class)
        //  5) Displaying AvailableTrains (sp_GetAvaulableTrains)
        //  6) Storing Train Running Status (sp_TrainStatus)
        //  7) Let User Book Ticket and store data (sp_BookingTrain_Ticket)
        //  8) Let User Cancel The Ticket , Update status is inactive in bookkings table (sp_Cancel_Ticket)

        // Admin Console
         // 1)Add a Train
         // 2)Inactivate The Train
         // 3)Re-Activate The Train
         // 4)See All Trains
         // 5)See All Bookings Done by USER
         // 6)See All Cancellations Done By USER

        // User Console
         // 1)Book A Ticket
         // 2)Cancel A Ticket
         // 3)Print A Ticket
         // 4)See All Bookings



        // MiNI Project CASE STUDY points
            
        //    1) User and Admin Accesses
        //    2) Admin can Add, Remove, Activate The Train Status
        //    3) User can only able to book Tickets Min>1 and Max<=3
        //    4) Booking Date > Current Date
        //    5) Update seats Count if User Cancels Booking
        //    6) Capture Cancelled Tickets in Cancellation Table
        //    7) Check Train Status Before Booking
        //    8) Booked Tickets enter into Booking Table

    }
}
