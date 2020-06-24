using System;
using System.Collections.Generic;
using System.Configuration;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public sealed class TicketsDbContext : DbContext
    {
       
        public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public TicketsDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost;Database=TicketsDb;Trusted_Connection=True;");
        }
        
        public DbSet<TrainEntity> TrainEntities { get; set; }
        public DbSet<TicketEntity> TicketEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var c1 = new CityEntity { Id = 1, Name = "Kyiv"};
            var c2 = new CityEntity { Id = 2, Name = "Lviv"};
            var c3 = new CityEntity { Id = 3, Name = "Zhytomyr"};
            var c4 = new CityEntity { Id = 4, Name = "Chernivtsi"};
            var c5 = new CityEntity { Id = 5, Name = "Sumy"};

            var d1 = new DayEntity { Id = 1, Date = DateTime.Today};
            var d2 = new DayEntity { Id = 2, Date = DateTime.Today.AddDays(1)};
            var d3 = new DayEntity { Id = 3, Date = DateTime.Today.AddDays(2)};

            var s1 = new SeatEntity {Id = 1, IsTaken = false, Number = 1, CarriageEntityId = 1};
            var s2 = new SeatEntity {Id = 2, IsTaken = false, Number = 2, CarriageEntityId = 1};
            var s3 = new SeatEntity {Id = 3, IsTaken = false, Number = 3, CarriageEntityId = 1};
            var s4 = new SeatEntity {IsTaken = false, Number = 1, Id = 4, CarriageEntityId = 2};
            var s5 = new SeatEntity {IsTaken = false, Number = 2, Id = 5, CarriageEntityId = 2};
            var s6 = new SeatEntity {IsTaken = false, Number = 3, Id = 6, CarriageEntityId = 2};
            var s7 = new SeatEntity {IsTaken = false, Number = 1, Id = 7, CarriageEntityId = 3};
            var s8 = new SeatEntity {IsTaken = false, Number = 2, Id = 8, CarriageEntityId = 3};
            var s9 = new SeatEntity {IsTaken = false, Number = 3, Id = 9, CarriageEntityId = 3};
            var s10 = new SeatEntity {IsTaken = false, Number = 1, Id = 10, CarriageEntityId = 4};
            var s11 = new SeatEntity {IsTaken = false, Number = 2, Id = 11, CarriageEntityId = 4};
            var s12 = new SeatEntity {IsTaken = false, Number = 3, Id = 12, CarriageEntityId = 4};

            var ct1 = new CitiesTrains{ TrainEntityId = 1, CityEntityId = 1, Id = 1};
            var ct2 = new CitiesTrains{ TrainEntityId = 1, CityEntityId = 2, Id = 2};
            var ct3 = new CitiesTrains{ TrainEntityId = 1, CityEntityId = 3, Id = 3};
            var ct4 = new CitiesTrains{ TrainEntityId = 1, CityEntityId = 4, Id = 4};
            var ct5 = new CitiesTrains{ TrainEntityId = 2, CityEntityId = 1, Id = 5};
            var ct6 = new CitiesTrains{ TrainEntityId = 2, CityEntityId = 3, Id = 6};
            var ct7 = new CitiesTrains{ TrainEntityId = 2, CityEntityId = 5, Id = 7};
            
            var dt1 = new DaysTrains{ TrainEntityId = 1, DayId = 1, Id = 1};
            var dt2 = new DaysTrains{ TrainEntityId = 1, DayId = 2, Id = 2};
            var dt3 = new DaysTrains{ TrainEntityId = 1, DayId = 3, Id = 3};
            var dt4 = new DaysTrains{ TrainEntityId = 2, DayId = 1, Id = 4};
            var dt5 = new DaysTrains{ TrainEntityId = 2, DayId = 3, Id = 5};

            var car1 = new CarriageEntity {Id = 1, TrainId = 1, Class = CarriageClass.First, Number = 1,};
            var car2 = new CarriageEntity {Id = 2, TrainId = 1, Class = CarriageClass.Second, Number = 2,};
            var car3 = new CarriageEntity {Id = 3, TrainId = 2, Class = CarriageClass.Second, Number = 1,};
            var car4 = new CarriageEntity {Id = 4, TrainId = 2, Class = CarriageClass.Business, Number = 2,};

            var train1 = new TrainEntity {Id = 1, Number = 1};
            var train2 = new TrainEntity {Id = 2, Number = 2};

            modelBuilder.Entity<TrainEntity>().HasData(train1, train2);
            modelBuilder.Entity<CarriageEntity>().HasData(car1, car2, car3, car4);
            modelBuilder.Entity<SeatEntity>().HasData(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12);
            modelBuilder.Entity<DayEntity>().HasData(d1, d2, d3);
            modelBuilder.Entity<CityEntity>().HasData(c1, c2, c3, c4, c5);
            modelBuilder.Entity<DaysTrains>().HasData(dt1, dt2, dt3, dt4, dt5);
            modelBuilder.Entity<CitiesTrains>().HasData(ct1, ct2, ct3, ct4, ct5, ct6, ct7);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}