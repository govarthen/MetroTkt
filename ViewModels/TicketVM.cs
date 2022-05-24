using Metro.Commands;
using Metro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Metro.ViewModels
{
    internal class TicketVM : VMBase
    {

        #region Properties

        private Ticket _ticket;
        private ObservableCollection<Ticket> _tickets;
        
        private ICommand _AddCommand;
        private ICommand _SearchCommand;
        private ICommand _RefreshCmd;

        private string _SearchTxt;
        private string _SearchCmb;

        public String SearchTxt
        {
            get 
            { 
                return _SearchTxt; 
            }
            set 
            { 
                    _SearchTxt = value;
                    NotifyPropertyChanged("SearchTxt");
            }
        }

        public String SearchCmb
        {
            get 
            { 
                return _SearchCmb; 
            }
            set
            {
                _SearchCmb = value;
                NotifyPropertyChanged("SearchCmb");
            }
        }


        public Ticket Ticket
        {
            get
            {
                return _ticket;
            }
            set
            {
                _ticket = value;
                NotifyPropertyChanged("Ticket");
            }
        }
        public ObservableCollection<Ticket> Tickets
        {
            get
            {
                return _tickets;
            }
            set
            {
                _tickets = value;
                NotifyPropertyChanged("Tickets");
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new RelayCommand(param => this.Submit(), null);
                }
                return _AddCommand;
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new RelayCommand(param => this.Search(), null);
                }
                return _SearchCommand;
            }
        }

        public ICommand RefreshCmd
        {
            get
            {
                if (_RefreshCmd == null)
                {
                    _RefreshCmd = new RelayCommand(param => this.Refresh(), null);
                }
                return _RefreshCmd;
            }
        }

        #endregion

        #region Constructor
        public TicketVM()
        {
            Ticket = new Ticket();
            Tickets = new ObservableCollection<Ticket>();

            Tickets.CollectionChanged += new NotifyCollectionChangedEventHandler(Tickets_CollectionChanged);

            this.LoadTickets();
        }
        //Whenever new item is added to the collection, am explicitly calling notify property changed  
        void Tickets_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Tickets");
        }

        #endregion

        #region Page_Events
        private void Submit()
        {
            Ticket.JryDate = DateTime.Today.Date;

            Tickets.Add(Ticket);

            Ticket = new Ticket();
        }

        private void Search()
        {
            IEnumerable<Ticket> liSearchData;

            if (this.SearchCmb == "Source")
            {
                 liSearchData = from t in Tickets
                                   where t.Source.ToLower() == this.SearchTxt.ToLower()
                                   select t;
            }
            else
            {
                 liSearchData = from t in Tickets
                                   where t.Destination.ToLower() == this.SearchTxt.ToLower()
                                   select t;
            }           
                       

            Tickets = new ObservableCollection<Ticket>(liSearchData);
        }

        private void Refresh()
        {
            Ticket = new Ticket();
            Tickets = new ObservableCollection<Ticket>();

            this.SearchCmb = "";
            this.SearchTxt = "";
            this.LoadTickets();
        }

        #endregion

        #region Private Methods

        private void LoadTickets()
        {
            this.Tickets.Add(new Ticket("Uppal", "JNTU", 90));
            this.Tickets.Add(new Ticket("Koti", "Gachibowli", 40));
            this.Tickets.Add(new Ticket("Ameerpet", "JNTU", 20));
            this.Tickets.Add(new Ticket("Miyapur", "Uppal", 60));
        }

        #endregion

    }
}
