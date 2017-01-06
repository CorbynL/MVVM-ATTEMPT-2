using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;


namespace Engine.Model
{
   public class Player : LivingCreature
    {
        //Backing variables

        private int _currentHP;
        private int _maxHP;
        private int _experience;
        private int _gold;
        private string _playerClass;
        private int _level;
        private List <Quest> _currentQuests;
        private List<InventoryItem> _battleItems;
        private List<Ability> _playerAbilities;
        private Weapon _equipedWeapon;

        #region Properties
        
        public override int CurrentHP
        {
            get { return _currentHP; }
            set
            {
                _currentHP = value;
                OnPropertyChanged("CurrentHP");
                if(_currentHP <= 0) { OnPlayerKilled(); }
            }
        }

        public override int MaxHP
        {
            get { return _maxHP;  }
            set
            {
                _maxHP = value;
                OnPropertyChanged("MaxHP");
            }
        }

        public int Experience
        {
            get { return _experience; }
            set
            {
                _experience = value;
                OnPropertyChanged("Experience");
            }
        }
        
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public string PlayerClass
        {
            get { return _playerClass; }
            set
            {
                _playerClass = value;
                OnPropertyChanged("PlayerClass");
            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }

        public List <Quest> CurrentQuests
        {
            get { return _currentQuests; }
            set
            {
                _currentQuests = value;
                OnPropertyChanged("CurrentQuests");
            }
        }

        public List<InventoryItem> BattleItems
        {
            get { return _battleItems; }
            set
            {
                _battleItems = value;
                OnPropertyChanged("BattleItems");
                
            }
        }

        public List<Ability> PlayerAbilities
        {
            get { return _playerAbilities; }
            set
            {
                _playerAbilities = value;
                OnPropertyChanged("PlayerAbilities");
            }
        }

        public Weapon EquipedWeapon
        {
            get { return _equipedWeapon; }
            set
            {
                _equipedWeapon = value;
                OnPropertyChanged("EquipedWeapon");
            }
        }

        #endregion

        public EventHandler isAttacked;
        public EventHandler PlayerKilled;

        public Player(string name = "", int maxHP = 0, int currentHP = 0, int experience = 0, int gold = 0, string playerClass = "") :
            base(name, maxHP, currentHP)
        {
            Experience = experience;
            Gold = gold;
            PlayerClass = playerClass;
            CurrentQuests = new List<Quest>();
            PlayerAbilities = new List<Ability>();    
        }

        public Player()
        {
            CurrentQuests = new List<Quest>();
            PlayerAbilities = new List<Ability>();
        }

        public void OnPlayerKilled()
        {
            PlayerKilled?.Invoke(this, EventArgs.Empty);
        }
    }
  }
