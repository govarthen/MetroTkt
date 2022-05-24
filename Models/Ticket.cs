using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public int Price { get; set; }

        public DateTime JryDate
        {
            get { return DateTime.Now; }
            set
            {
                value = DateTime.Now;
            }
        }

        public Ticket()
        {
        }

        public Ticket(string source, string destination, int price)
        {            
            Source = source;
            Destination = destination;
            Price = price;            
        }

        
    }
}
