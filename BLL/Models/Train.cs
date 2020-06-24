using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class Train
    {
        public int Number { get; set; }
        
        public ICollection<City> Cities { get; set; }
        
        public ICollection<Day> Dates { get; set; }
        
        public ICollection<Carriage> Carriages { get; set; }
    }
}