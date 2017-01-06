using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine.Model
{
  public  class Location : INotifyPropertyChanged
    {
        private Location[] _currentDirections;
        private List<Monster> _locationMonsters;
        private bool _canEnter;

        public string ActionString { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }       
        public Quest[] AvailableQuests { get; set; }
        public List<Monster> LocationMonsters
        {
            get { return _locationMonsters; }
            set
            {
                _locationMonsters = value;
                OnPropertyChanged("LocationMonsters");
            }
        }
        public Location[] CurrentDirections
        {
            get { return _currentDirections; }
            set
            {
                _currentDirections = value;
                OnPropertyChanged("CurrentDirections");
            }
        }
        public bool CanEnter
        {
            get { return _canEnter; }
            set
            {
                _canEnter = value;
                OnPropertyChanged("CanEnter");
            }
        }

        public Location(string name = "", string description = "", int id = 0)
        {
            Name = name;
            Description = description;
            ID = id;
            CurrentDirections = new Location[] { };
            LocationMonsters = new List<Monster>();
            AvailableQuests = new Quest[] { };
            ActionString = "Travel";
            CanEnter = false;
        }

        public Location()
        {
            CurrentDirections = new Location[] { };
            LocationMonsters = new List<Monster>();
            AvailableQuests = new Quest[] { };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
