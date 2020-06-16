using System;
using System.Collections.Generic;
using System.Configuration;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL
{
    [Serializable]
    public class InMemoryStorage : IInMemoryStorage
    {
        [NonSerialized]
        private ISerializer _serializer;
        [NonSerialized]
        private readonly string _path = ConfigurationManager.AppSettings.Get("SerializationPath");

        public InMemoryStorage(ISerializer serializer)
        {
            _serializer = serializer;

            var storage = _serializer.Deserialize(_path) as InMemoryStorage;
            Trains = storage.Trains;
            Tickets = storage.Tickets;


            /*var train1 = new TrainEntity
            {
            Number = 1, 
            Carriages = new List<CarriageEntity>
            {
                new CarriageEntity
                {
                    Class = CarriageClass.First,
                    Number = 1,
                    Seats = new List<SeatEntity>
                    {
                        new SeatEntity
                        {
                            IsTaken = false, Number = 1
                        },
                        new SeatEntity
                        {
                            IsTaken = false, Number = 2
                        },
                        new SeatEntity
                        {
                            IsTaken = false, Number = 3
                        }
                    }
                },
                new CarriageEntity
                {
                    Class = CarriageClass.Second,
                    Number = 2,
                    Seats = new List<SeatEntity>
                    {
                        new SeatEntity
                        {
                            IsTaken = false, Number = 1
                        },
                        new SeatEntity
                        {
                            IsTaken = false, Number = 2
                        },
                        new SeatEntity
                        {
                            IsTaken = false, Number = 3
                        }
                    }
                }
            },
            Cities = new List<string>
            {
                "Kyiv", "Lviv", "Zhytomyr", "Chernivtsi"
            },
            Dates = new List<DateTime>
            {
                new DateTime(2020, 6, 16),
                new DateTime(2020, 6, 17),
                new DateTime(2020, 6, 20)
            }
        };
        
            var train2 = new TrainEntity
            {
            Number = 1, 
            Carriages = new List<CarriageEntity>
            {
                new CarriageEntity
                {
                    Class = CarriageClass.Second,
                    Number = 1,
                    Seats = new List<SeatEntity>
                    {
                        new SeatEntity
                        {
                            IsTaken = false, Number = 1
                        },
                        new SeatEntity
                        {
                            IsTaken = false, Number = 2
                        },
                        new SeatEntity
                        {
                            IsTaken = false, Number = 3
                        }
                    }
                },
                new CarriageEntity
                {
                    Class = CarriageClass.Business,
                    Number = 2,
                    Seats = new List<SeatEntity>
                    {
                        new SeatEntity
                        {
                            IsTaken = false, Number = 1
                        },
                        new SeatEntity
                        {
                            IsTaken = false, Number = 2
                        },
                        new SeatEntity
                        {
                            IsTaken = false, Number = 3
                        }
                    }
                }
            },
            Cities = new List<string>
            {
                "Kyiv", "Sumy", "Zhytomyr"
            },
            Dates = new List<DateTime>
            {
                new DateTime(2020, 6, 18),
                new DateTime(2020, 6, 20),
                new DateTime(2020, 6, 24)
            }
        };
        
            Trains.Add(train1);
            Trains.Add(train2);*/

        }

        public ICollection<TrainEntity> Trains { get; set; } = new List<TrainEntity>();
        
        public ICollection<TicketEntity> Tickets { get; set; } = new List<TicketEntity>();
        
        public void Save()
        {
            _serializer.Serialize(_path, this);
        }
        
    }
}