﻿using System;

namespace DAL.Entities
{
    public class TicketEntity : BaseEntity
    {
        public long Number { get; set; }
        public string Passenger { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int TrainNumber { get; set; }
        public int CarriageNumber { get; set; }
        public int Seat { get; set; }
    }
}