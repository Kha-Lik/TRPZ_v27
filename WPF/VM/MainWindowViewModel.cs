using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using BLL;
using BLL.Models;
using TRPZ_v27.Annotations;

namespace TRPZ_v27
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ITrainService _trainService;
        private readonly ICarriageService _carriageService;
        private readonly ITicketService _ticketService;
        private readonly ISeatService _seatService;

        private ICollection<Train> _trains;
        private ICollection<Carriage> _carriages;
        private ICollection<Seat> _seats;

        private Train _train;
        private Carriage _carriage;
        private Seat _seat;
        private string _sourceCity;
        private string _destinationCity;
        private DateTime _date;
        private CarriageClass _class;
        private string _passenger;
        private Int64 _ticketNum;

        private RelayCommand _findTrainsCommand;
        private RelayCommand _findCarriagesCommand;
        private RelayCommand _takeTicketCommand;

        public MainWindowViewModel(ITrainService trainService, ICarriageService carriageService, ITicketService ticketService, ISeatService seatService)
        {
            _trainService = trainService;
            _carriageService = carriageService;
            _ticketService = ticketService;
            _seatService = seatService;

            Date = DateTime.Today;
        }

        public ICollection<Train> Trains
        {
            get => _trains;
            set
            {
                _trains = value;
                OnPropertyChanged(nameof(Trains));
            }
        }

        public ICollection<Carriage> Carriages
        {
            get => _carriages;
            set
            {
                _carriages = value;
                OnPropertyChanged(nameof(Carriages));
            }
        }

        public ICollection<Seat> Seats
        {
            get => _seats;
            set
            {
                _seats = value;
                OnPropertyChanged(nameof(Seats));
            }
        }

        public Train SelectedTrain
        {
            get => _train;
            set
            {
                _train = value;
                OnPropertyChanged(nameof(SelectedTrain));
            }
        } 
        
        public Carriage SelectedCarriage
        {
            get => _carriage;
            set
            {
                _carriage = value;
                OnPropertyChanged(nameof(SelectedCarriage));
                Seats = value.Seats.Where(s => !s.IsTaken).ToList();
            }
        } 
        
        public Seat SelectedSeat
        {
            get => _seat;
            set
            {
                _seat = value;
                OnPropertyChanged(nameof(SelectedSeat));
            }
        }

        public string SourceCity
        {
            get => _sourceCity;
            set
            {
                _sourceCity = value;
                OnPropertyChanged(nameof(SourceCity));
            }
        }
        
        public string DestinationCity
        {
            get => _destinationCity;
            set
            {
                _destinationCity = value;
                OnPropertyChanged(nameof(DestinationCity));
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public CarriageClass Class
        {
            get => _class;
            set
            {
                _class = value;
                OnPropertyChanged(nameof(Class));
            }
        }
        
        public string Passenger
        {
            get => _passenger;
            set
            {
                _passenger = value;
                OnPropertyChanged(nameof(Passenger));
            }
        }

        public long TicketNum
        {
            get => _ticketNum;
            set
            {
                _ticketNum = value;
                OnPropertyChanged(nameof(TicketNum));
            }
        }

        public ICollection<CarriageClass> Classes => 
            Enum.GetValues(typeof(CarriageClass)).Cast<CarriageClass>().ToList<CarriageClass>();

        public RelayCommand FindTrainsCommand => _findTrainsCommand ??= new RelayCommand(o =>
        {
            Trains = _trainService.GetSpecifiedTrains(SourceCity, DestinationCity, Date);
        }, o => CheckCitiesAndDate());

        public RelayCommand FindCarriagesCommand => _findCarriagesCommand ??= new RelayCommand(o =>
        {
            Carriages = _carriageService.GetSpecifiedCarriages(Class, SelectedTrain);
        }, o => CheckTrainAndClass());

        public RelayCommand TakeTicketCommand => _takeTicketCommand ??= new RelayCommand(o =>
        {
            var ticket = new Ticket
            {
                CarriageNumber = SelectedCarriage.Number,
                Date = Date.Date,
                Destination = DestinationCity,
                Passenger = Passenger,
                Seat = SelectedSeat.Number,
                Source = SourceCity,
                TrainNumber = SelectedTrain.Number
            };
            TicketNum = _ticketService.TakeTicket(ticket).Number;
            _seatService.TakeSeat(SelectedSeat);
            Seats = SelectedCarriage.Seats.Where(s => !s.IsTaken).ToList();
        }, o => CheckTicket());

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool CheckCitiesAndDate()
        {
            return SourceCity != null && 
                   DestinationCity != null && 
                   Date != default;
        }

        private bool CheckTrainAndClass()
        {
            return SelectedTrain != null && 
                   Class != default;
        }

        private bool CheckTicket()
        {
            return CheckCitiesAndDate() && 
                   CheckTrainAndClass() && 
                   Passenger != null && 
                   SelectedSeat != null &&
                   SelectedCarriage != null;
        }
    }
}