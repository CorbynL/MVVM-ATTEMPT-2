using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Model;
using System.ComponentModel;

namespace Engine.ViewModel
{
  public  class GameSession : INotifyPropertyChanged
    {

        private object _selecteditem;
        private Location _currentLocation;
        private List<Quest> _activeQuests;
        //properties

        public int DamageDone { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public World CurrentWorld { get; private set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged("CurrentLocation");
            }
        }
        public List<Quest> ActiveQuests
        {
            get { return _activeQuests; }
            set
            {
                _activeQuests = value;
                OnPropertyChanged("ActiveQuest");
            }
        }
        public Monster CurrentMonster { get; private set; }
        public object selectedItem
        {
            get { return _selecteditem; }
            set {
                _selecteditem = value;
                OnPropertyChanged("selectedItem");

            }
        }
        public string Message { get; private set; }

        //events

        public event PropertyChangedEventHandler PropertyChanged;
        public EventHandler PlayerAttacking;
        public EventHandler PlayerAttacked;
        public EventHandler LocationChange;
        public EventHandler MessagePublished;


        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentWorld = new World();
            CurrentMonster = new Monster();
            ActiveQuests = new List<Quest>();
            CurrentLocation = new Location();

            CurrentPlayer.PlayerKilled += HandlePlayerKilled;
            CurrentMonster.MonsterKilled += HandleMonsterKilled;
            CurrentMonster.isAttacked += HandleMonsterAttacked;
            LocationChange += HandleLocationChanged;
            UpdateQuestEventHandles();

            CurrentLocation = CurrentWorld.GameLocations[0];
            CurrentLocation.LocationMonsters.Add(CurrentWorld.GameMonsters[1]);
            CurrentPlayer.EquipedWeapon = new Weapon("dsf", "asd", "asd", 20, 11, 1);
        }

        private void UpdateQuestEventHandles()
        {
            if(ActiveQuests != null)
            foreach(Quest quest in ActiveQuests)
            {
                quest.QuestCompleted += HandleQuestComplete;
            }
        }

        public void HandleMonsterAttacked(object sender, EventArgs e)
        {
            
            Random Damage = new Random();
            int DamagePoints = Damage.Next(CurrentPlayer.EquipedWeapon.MinDamage, CurrentPlayer.EquipedWeapon.MaxDamage);
            DamageDone = DamagePoints;
            CurrentMonster.MonsterKilled += HandleMonsterKilled;
            OnPlayerAttacking();
            CurrentMonster.CurrentHP =- DamagePoints;

        }
        public void HandlePlayerAttacked(object sender, EventArgs e)
        {

            Random Damage = new Random();
            int DamagePoints = Damage.Next(CurrentMonster.MinDamage, CurrentMonster.MaxDamage);
            DamagePoints = DamageDone;
            CurrentPlayer.CurrentHP =- DamagePoints;
        }
        public void HandlePlayerKilled(object sender, EventArgs e)
        {
        
        }
        public void HandleMonsterKilled(object sender, EventArgs e)
        {
            CurrentPlayer.Experience += CurrentMonster.ExperienceReward;
            CurrentPlayer.Gold += CurrentMonster.GoldReward;

            CurrentLocation.LocationMonsters.Remove(CurrentMonster);
        }
        public void HandleQuestComplete(object sender, EventArgs e)
        {
        
        }
        public void HandleBattleScreenOpened(object sender, EventArgs e)
        {
            CurrentMonster = (Monster)selectedItem;
        }
        public void HandleLocationChanged(object sender, EventArgs e)
        {
            Location location = (Location)selectedItem;

            if (location.CanEnter) { CurrentLocation = (Location)selectedItem; }
            else
            {
                Message = "Cannot Enter this location at this time";
                OnMessagePublished();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void OnLocationChanged()
        {
            LocationChange?.Invoke(this, EventArgs.Empty);
        }
        public void OnPlayerAttacking()
        {
            PlayerAttacking?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnMessagePublished()
        {
            MessagePublished?.Invoke(this, EventArgs.Empty);
        }
    }
}
