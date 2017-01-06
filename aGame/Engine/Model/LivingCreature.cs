using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine.Model
{
    public class LivingCreature: INotifyPropertyChanged
    {
        private string _name;
        private int _maxHP;
        private int _currentHP;

        #region Properties

        public virtual string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public virtual int MaxHP
        {
            get { return _maxHP; }
            set
            {
                _maxHP = value;
                OnPropertyChanged("MaxHP");
            }
        }
        public virtual int CurrentHP
        {
            get { return _currentHP; }
            set
            {
                _currentHP = value;
                OnPropertyChanged("CurrentHP");
            }
        }
        #endregion 

        public event PropertyChangedEventHandler PropertyChanged;

        public LivingCreature(string name = "", int maxHP = 0, int currentHP = 0)
        {
            Name = name;
            MaxHP = maxHP;
            CurrentHP = currentHP;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
